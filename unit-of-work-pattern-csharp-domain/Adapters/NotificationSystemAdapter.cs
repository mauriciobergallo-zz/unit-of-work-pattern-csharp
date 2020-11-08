using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters
{
    public class NotificationSystemAdapter : INotificationSystemAdapter
    {
        public Task NotifyPurchase(Purchase purchase)
        {
            throw new System.NotImplementedException();
        }
    }
}