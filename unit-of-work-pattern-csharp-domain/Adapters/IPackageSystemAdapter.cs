using System;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public interface IPackageSystemAdapter
    {
        Task<StockOperationResult> RegisterPurchaseToDeliver(PackageOperationRequest request);
        Task<StockOperationResult> RollbackPurchaseToDeliver(Guid operationId);
    }
}