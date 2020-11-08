using System;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> FindById(Guid id);
        Task<Purchase> Upsert(Purchase entity);
        Task Remove(Guid id);
    }
}