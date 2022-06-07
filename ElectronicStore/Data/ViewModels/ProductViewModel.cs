using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [Display(Name = "Product Description")]
        public string productDescription { get; set; }

        [Required(ErrorMessage = "Price is required(Turkish Lira)!")]
        [Display(Name = "Product Price")]
        public double productPrice { get; set; }

        [Required(ErrorMessage = "Picture url is required!")]
        [Display(Name = "Product Picture URL")]
        public string productPictureURL { get; set; }

        [Required(ErrorMessage = "List date is required!")]
        [Display(Name = "Product Lise Date")]
        public DateTime producyListDate { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [Display(Name = "Product Category")]
        public ProductCategory productCategory { get; set; }

        // Warranty
        [Required(ErrorMessage = "Warranty is required!")]
        [Display(Name = "Select warranty")]
        public List<int> warrantyIDs { get; set; }

        // Seller
        [Required(ErrorMessage = "Seller is required!")]
        [Display(Name = "Select Seller")]
        public int sellerID { get; set; }

        // Producer
        [Required(ErrorMessage = "Producer is required!")]
        [Display(Name = "Select Producer")]
        public int producerID { get; set; }
    }
}
