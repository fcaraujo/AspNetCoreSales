using ANC.Sales.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANC.Sales.Data.Map
{
    public static class OrderMap
    {
        public static void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}