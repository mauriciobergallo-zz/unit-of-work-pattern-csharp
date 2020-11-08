using System;

namespace UnitOfWorkPatternCSharp.Domain.Model
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public long Count { get; set; }
        public User Seller { get; set; }
        public User Buyer { get; set; }
        public long Total { get; set; }
        public Guid StockSystemOperationId { get; set; }
        public Guid DeliverySystemOperationId { get; set; }
    }
}