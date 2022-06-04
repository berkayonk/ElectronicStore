using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.ViewModels
{
    public class ProductDropDownViewModel
    {
        public ProductDropDownViewModel()
        {
            producers = new List<Producer>();
            sellers = new List<Seller>();
            warranties = new List<Warranty>();
        }

        public List<Producer> producers { get; set; }
        public List<Seller> sellers { get; set; }
        public List<Warranty> warranties { get; set; }
    }
}
