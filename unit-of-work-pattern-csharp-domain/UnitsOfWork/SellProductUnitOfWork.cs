using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters;
using UnitOfWorkPatternCSharp.Domain.Model;
using UnitOfWorkPatternCSharp.Domain.Repositories;
using UnitOfWorkPatternCSharp.Domain.UnitsOfWork.Model;

namespace UnitOfWorkPatternCSharp.Domain.UnitsOfWork
{
    public class SellProductUnitOfWork : ISellProductUnitOfWork
    {
        private readonly IStockSystemAdapter _stockSystemAdapter;
        private readonly IPackageSystemAdapter _packageSystemAdapter;
        private readonly INotificationSystemAdapter _notificationSystemAdapter;
        private readonly ISellRepository _sellRepository;

        private readonly IDictionary<string, List<object>> _changesToRollback;
        
        public SellProductUnitOfWork(IStockSystemAdapter stockSystemAdapter, IPackageSystemAdapter packageSystemAdapter, INotificationSystemAdapter notificationSystemAdapter, ISellRepository sellRepository)
        {
            _stockSystemAdapter = stockSystemAdapter;
            _packageSystemAdapter = packageSystemAdapter;
            _notificationSystemAdapter = notificationSystemAdapter;
            _sellRepository = sellRepository;
            
            _changesToRollback = new Dictionary<string, List<object>>();
        }

        public async Task<SellOperationResult> ExecuteAsync(SellOperation operation)
        {
            try
            {
                if (!await CommitAsync())
                {
                    // ToDo: Mark a flag or something to execute a FallBack Job.
                }
                return new SellOperationResult();
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

        private async Task<bool> CommitAsync()
        {
            return true;
        }

        private async Task<bool> RollbackAsync()
        {
            return true;
        }
    }
}