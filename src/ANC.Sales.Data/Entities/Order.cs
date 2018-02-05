using System;
using System.Collections.Generic;

namespace ANC.Sales.Data.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}