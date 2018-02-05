using ANC.Sales.Data.Context;
using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _ctx;
        private IGenericRepository<Product> _productRepository;

        // TODO: implement a list of generic repositories

        public UnitOfWork(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new GenericRepository<Product>(_ctx);
            }
        }
        
        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}