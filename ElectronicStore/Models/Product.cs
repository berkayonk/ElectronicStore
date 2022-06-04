using ElectronicStore.Data;
using ElectronicStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Models
{
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; }
        public string productPictureURL { get; set; }
        public DateTime producyListDate { get; set; }
        public ProductCategory productCategory { get; set; }

        // Relationships
        public List<WarrantytoProduct> warrantytoProducts { get; set; }

        // Seller
        public int sellerID { get; set; }
        [ForeignKey("sellerID")]
        public Seller sellers { get; set; }
        

        // Producer
        public int producerID { get; set; }
        [ForeignKey("producerID")]
        public Producer producers { get; set; }
        
    }
}
