using ElectronicStore.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.ViewModels
{
    public class ShoppingCatViewModel
    {
        public ShoppingCart shoppingCart { get; set; }
        public double shoppingCartTotal { get; set; }
    }
}
