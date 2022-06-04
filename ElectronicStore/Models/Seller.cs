using ElectronicStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Models
{
    public class Seller:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Seller Picture")]
        [Required(ErrorMessage = "Seller picture is required!")]
        public string sellerPictureURL { get; set; }

        [Display(Name = "Seller Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be betwween 3 to 40 characters!")]
        public string sellerName { get; set; }

        [Display(Name = "Seller Description")]
        [Required(ErrorMessage = "Seller description is required!")]
        public string sellerDescription { get; set; }

        // Relationships
        public List<Product> products { get; set; } // Seller has more than 1 product
    }
}
