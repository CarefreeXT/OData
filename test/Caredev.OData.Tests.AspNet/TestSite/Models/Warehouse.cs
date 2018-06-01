using Caredev.Mego.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    [Table("Warehouses")]
    public class Warehouse
    {
        [Key, Column(nameof(Id), Order = 1)]
        public int Id { get; set; }

        [Key, Column(nameof(Number), Order = 2)]
        public int Number { get; set; }

        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Address { get; set; }
    }
}
