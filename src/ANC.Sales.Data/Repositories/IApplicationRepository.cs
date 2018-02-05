using System.Collections.Generic;
using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public interface IApplicationRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}