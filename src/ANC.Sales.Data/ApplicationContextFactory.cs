using ANC.Sales.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ANC.Sales.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile("appsettings.json")
            // .Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();

            // var connectionString = configuration.GetConnectionString("DefaultConnection");
            // builder.UseSqlServer(connectionString);

            // TODO: configure string connection
            builder.UseSqlite(string.Empty);

            return new ApplicationContext(builder.Options);
        }
    }
}