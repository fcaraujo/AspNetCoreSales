using System.Collections.Generic;
using System.Linq;
using ANC.Sales.Data.Context;
using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContext _ctx;

        public ApplicationRepository(ApplicationContext ctx)
        {
            _ctx = ctx;            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                       .OrderBy(p => p.Title)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}