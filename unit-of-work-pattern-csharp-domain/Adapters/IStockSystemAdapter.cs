using System;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters.Model;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public interface IStockSystemAdapter
    {
        Task<StockOperationResult> RegisterPurchase(StockOperationRequest request);
        Task<StockOperationResult> RollbackPurchase(Guid operationId);
    }
}