using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;
using UnitOfWorkPatternCSharp.Domain.UnitsOfWork.Model;

namespace UnitOfWorkPatternCSharp.Domain.UnitsOfWork
{
    public interface ISellProductUnitOfWork
    {
        Task<SellOperationResult> ExecuteAsync(SellOperation operation);
    }
}