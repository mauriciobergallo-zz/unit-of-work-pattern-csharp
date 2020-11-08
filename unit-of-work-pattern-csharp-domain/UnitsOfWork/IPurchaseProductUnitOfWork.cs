using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;
using UnitOfWorkPatternCSharp.Domain.UnitsOfWork.Model;

namespace UnitOfWorkPatternCSharp.Domain.UnitsOfWork
{
    public interface IPurchaseProductUnitOfWork
    {
        Task<PurchaseOperationResult> ExecuteAsync(PurchaseOperation operation);
    }
}