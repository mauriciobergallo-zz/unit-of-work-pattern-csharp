using System;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters.Model;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public class StockSystemAdapter : IStockSystemAdapter
    {
        public async Task<StockOperationResult> RegisterPurchase(StockOperationRequest request)
        {
            return new StockOperationResult()
            {
                Id = Guid.NewGuid(),
                Message = string.Empty,
                Name = "RegisterSell",
                IsCorrect = true
            };
        }

        public async Task<StockOperationResult> RollbackPurchase(Guid operationId)
        {
            return new StockOperationResult()
            {
                Id = operationId,
                Message = "An error has occurred trying to rollback the operation",
                Name = "RollbackSell",
                IsCorrect = false
            };
        }
    }
}