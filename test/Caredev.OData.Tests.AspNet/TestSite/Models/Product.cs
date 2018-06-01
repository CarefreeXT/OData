using Caredev.Mego.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    [Table("Products")]
    public class Product
    {

        [Key, Identity]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public bool IsValid { get; set; }

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [Relationship(typeof(OrderDetail), "OrderId", "Id", "ProductId", "Id")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
