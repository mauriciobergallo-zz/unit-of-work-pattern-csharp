using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public interface INotificationSystemAdapter
    {
        Task NotifyPurchase(Purchase purchase);
    }
}