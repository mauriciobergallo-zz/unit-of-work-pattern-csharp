using System;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Adapters.Model
{
    public class PackageOperationRequest
    {
        public Purchase Purchase { get; set; }
        public Guid StockOperationId { get; set; }
    }
}