using Caredev.Mego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    public class OrderManageEntities : DbContext
    {
        public OrderManageEntities()
            : base(nameof(OrderManageEntities))
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
