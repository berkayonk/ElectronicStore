using ElectronicStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Models
{
    public class Warranty:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Warranty Picture")]
        [Required(ErrorMessage = "Warranty picture is required!")]
        public string warrantyPictureURL { get; set; }

        [Display(Name = "Warranty Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be betwween 3 to 40 characters!")]
        [Required(ErrorMessage = "Warranty name is required!")]
        public string warrantyName { get; set; }

        [Display(Name = "Warranty Description")]
        [Required(ErrorMessage = "Warranty description is required!")]
        public string warrantyDescription { get; set; }

        // Relationships
        public List<WarrantytoProduct> warrantytoProducts { get; set; } // Warranty has more than 1 product
    }
}
