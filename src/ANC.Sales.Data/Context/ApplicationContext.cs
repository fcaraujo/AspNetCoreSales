using System;
using ANC.Sales.Data.Entities;
using ANC.Sales.Data.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANC.Sales.Data.Context
{
    public class ApplicationContext : DbContext
    {
        #region Ctor

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        #endregion Ctor


        #region DbSets

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        #endregion DbSets
        
        
        #region Context Configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: is this necessary?
            // base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("AspNetCoreSales");

            // TODO: unify entity configuration
            modelBuilder.Entity<Product>(e => {
                e.ToTable("Product");

                ProductMap.Configure(e);
            });
            
            modelBuilder.Entity<Order>(OrderMap.Configure);

            // TODO: create an extension/lambda call to get all mappings configuration
        }

        #endregion Context Configuration
    }
}