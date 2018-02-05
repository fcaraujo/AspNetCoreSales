using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepository { get; }
        void Save();
    }    
}
