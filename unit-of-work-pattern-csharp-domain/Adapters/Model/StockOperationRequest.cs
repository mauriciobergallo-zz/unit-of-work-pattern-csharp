using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters.Model
{
    public class StockOperationRequest
    {
        public Product Product { get; set; }
        public double Count { get; set; }
    }
}