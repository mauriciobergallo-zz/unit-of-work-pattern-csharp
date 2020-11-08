using System;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Adapters.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public class PackageSystemAdapter : IPackageSystemAdapter
    {
        public Task<StockOperationResult> RegisterPurchaseToDeliver(PackageOperationRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<StockOperationResult> RollbackPurchaseToDeliver(Guid operationId)
        {
            throw new NotImplementedException();
        }
    }
}