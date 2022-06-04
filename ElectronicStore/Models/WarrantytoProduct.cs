using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Models
{
    public class WarrantytoProduct
    {
        public int productID { get; set; }
        public Product product { get; set; }

        public int Id { get; set; }
        public Warranty warranty { get; set; }
    }
}
