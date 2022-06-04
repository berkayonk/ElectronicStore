using ElectronicStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Producer Picture")]
        [Required(ErrorMessage = "Producer picture is required!")]
        public string producerPictureURL { get; set; }

        [Display(Name = "Producer Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be betwween 3 to 40 characters!")]
        public string producerName { get; set; }

        [Display(Name = "Producer Description")]
        [Required(ErrorMessage = "Producer description is required!")]
        public string producerDescription { get; set; }

        // Relationships
        public List<Product> products { get; set; } // Producer has more than 1 product
    }
}
