
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ANC.Sales.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ANC.Sales.Data.Context
{
    public class ApplicationSeeder
    {
        private readonly ApplicationContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public ApplicationSeeder(ApplicationContext ctx, IHostingEnvironment hosting)
        {
            this._ctx = ctx;
            this._hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            // Add some products
            if (!_ctx.Products.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "SeedData/products.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IOrderedEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                // Add an order
                if (!_ctx.Orders.Any())
                {
                    var order = new Order()
                    {
                        OrderDate = DateTime.Now,
                        OrderNumber = "12345",
                        Items = new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Product = products.First(),
                                Quantity = 5,
                                UnitPrice = products.First().Price
                            }
                        }
                    };

                    _ctx.Orders.Add(order);
                    _ctx.SaveChanges();
                }
            }

        }
    }
}