using System;

namespace UnitOfWorkPatternCSharp.Domain.Adapters.Model
{
    public class StockOperationResult
    {
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}