using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkPatternCSharp.Domain.Model;

namespace UnitOfWorkPatternCSharp.Domain.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly List<Purchase> _database;

        public PurchaseRepository()
        {
            _database = new List<Purchase>()
            {
                new Purchase()
                {
                    Id = Guid.Parse("d3e7936f-7861-4620-9d86-5a4c4194cf54"),
                    Product = new Product()
                    {
                        Id = Guid.Parse("07e3c8d5-28f9-42d9-8a48-4538cae0f58e"),
                        Name = "Product #1"
                    },
                    Buyer = new User()
                    {
                        Id = Guid.Parse("88420c3d-306e-4b44-ae24-56eb74d278ca"),
                        FirstName = "John",
                        LastName = "Doe"
                    },
                    Seller = new User()
                    {
                        Id = Guid.Parse("b3db0944-909c-4fa2-8edd-6300df456ed8"),
                        FirstName = "Jane",
                        LastName = "Doe"
                    },
                    Count = 3,
                    Total = 1500
                }
            };
        }

        public Task<Purchase> FindById(Guid id)
        {
            return Task.FromResult(_database.FirstOrDefault(x => x.Id == id));
        }

        public Task<Purchase> Upsert(Purchase entity)
        {
            _database.RemoveAll(x => x.Id == entity.Id);
            _database.Add(entity);

            return Task.FromResult(entity);
        }

        public Task Remove(Guid id)
        {
            _database.RemoveAll(x => x.Id == id);
            return Task.CompletedTask;
        }
    }
}