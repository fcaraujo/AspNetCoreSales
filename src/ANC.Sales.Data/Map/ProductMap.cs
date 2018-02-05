using ANC.Sales.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANC.Sales.Data.Map
{
    public static class ProductMap
    {
        public static void Configure(EntityTypeBuilder<Product> entity)
        {
            // TODO: discover an away to call ToTable here
            
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Title)
                  .HasColumnName("Title")
                  .IsRequired();

            // TODO: review these properties/methods
            // entity.Property(e => e.Title)
            //     .ValueGeneratedOnAddOrUpdate()
            //     .IsConcurrencyToken();
        }
    }    
}