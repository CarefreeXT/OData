using Caredev.Mego.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key, Identity]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int? ProductId { get; set; }

        public Guid Key { get; set; } = Guid.NewGuid();

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [ConcurrencyCheck]
        public int Discount { get; set; }

        [ForeignKey("OrderId", "Id")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId", "Id")]
        public virtual Product Product { get; set; }
    }
}
