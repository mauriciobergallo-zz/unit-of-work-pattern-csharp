using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters;
using UnitOfWorkPatternCSharp.Domain.Adapters.Model;
using UnitOfWorkPatternCSharp.Domain.Model;
using UnitOfWorkPatternCSharp.Domain.Repositories;
using UnitOfWorkPatternCSharp.Domain.UnitsOfWork.Model;

namespace UnitOfWorkPatternCSharp.Domain.UnitsOfWork
{
    public class PurchaseProductUnitOfWork : IPurchaseProductUnitOfWork
    {
        private const string RegisteredStockOperation = "RegisteredStockOperation";
        private const string RegisteredDeliveryOperation = "RegisteredDeliveryOperation";
        
        private readonly IStockSystemAdapter _stockSystemAdapter;
        private readonly IPackageSystemAdapter _packageSystemAdapter;
        private readonly INotificationSystemAdapter _notificationSystemAdapter;
        private readonly IPurchaseRepository _purchaseRepository;

        private readonly IDictionary<string, Purchase> _changesToRollback;
        
        public PurchaseProductUnitOfWork(IStockSystemAdapter stockSystemAdapter, IPackageSystemAdapter packageSystemAdapter, INotificationSystemAdapter notificationSystemAdapter, IPurchaseRepository sellRepository)
        {
            _stockSystemAdapter = stockSystemAdapter;
            _packageSystemAdapter = packageSystemAdapter;
            _notificationSystemAdapter = notificationSystemAdapter;
            _purchaseRepository = sellRepository;
            
            _changesToRollback = new Dictionary<string, Purchase>();
        }

        public async Task<PurchaseOperationResult> ExecuteAsync(PurchaseOperation operation)
        {
            try
            {
                // 1 - We store the purchase into the DB.
                await _purchaseRepository.Upsert(operation.Purchase);
                
                //2 - We ask the Stock System to start his own process.
                var stockOperationRequest = new StockOperationRequest()
                {
                    Product = operation.Purchase.Product,
                    Count = operation.Purchase.Count
                };
                var stockOperationResult = await _stockSystemAdapter.RegisterPurchase(stockOperationRequest);
                if (!stockOperationResult.IsCorrect)
                    throw new Exception("Not able to do the Stock Operation.");
                
                operation.Purchase.StockSystemOperationId = stockOperationResult.Id;
                _changesToRollback.Add(RegisteredStockOperation, operation.Purchase);
                
                // 3 - We ask to the Delivery System to start his own process with the Stock Operation Id
                var packageOperationRequest = new PackageOperationRequest()
                {
                    Purchase = operation.Purchase,
                    StockOperationId = operation.Purchase.StockSystemOperationId
                };
                var packageOperationResult =  await _packageSystemAdapter.RegisterPurchaseToDeliver(packageOperationRequest);
                if (!packageOperationResult.IsCorrect)
                    throw new Exception("Not able to do the Delivery Operation.");

                operation.Purchase.DeliverySystemOperationId = packageOperationResult.Id;
                _changesToRollback.Add(RegisteredDeliveryOperation, operation.Purchase);
                
                // 4 - We trigger the notifications
                await _notificationSystemAdapter.NotifyPurchase(operation.Purchase);
                
                await _purchaseRepository.Upsert(operation.Purchase);
                
                if (!await CommitAsync())
                {
                    // ToDo: Mark a flag or something to execute a FallBack Job.
                }
                
                return new PurchaseOperationResult();
            }
            catch (Exception e)
            {
                if (!await RollbackAsync())
                {
                    // ToDo: Mark a flag or something to execute a FallBack Job.
                }

                throw e;
            }
        }

        private Task<bool> CommitAsync()
        {
            _changesToRollback.Clear();
            return Task.FromResult(true);
        }

        private async Task<bool> RollbackAsync()
        {
            foreach (var item in _changesToRollback)
            {
                switch (item.Key)
                {
                    case RegisteredStockOperation:
                        await _stockSystemAdapter.RollbackPurchase(item.Value.StockSystemOperationId);
                        
                        break;
                    case RegisteredDeliveryOperation:
                        await _packageSystemAdapter.RollbackPurchaseToDeliver(item.Value.DeliverySystemOperationId);
                        
                        break;
                }
            }
            
            _changesToRollback.Clear();
            return true;
        }
    }
}