using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.UnitsOfWork.Model
{
    public class SellOperation
    {
        public Product ProductToSell { get; set; }
        public User Buyer { get; set; }
        public User Seller { get; set; }
        public double Price { get; set; }
    }
}