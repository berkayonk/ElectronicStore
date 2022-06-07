using ElectronicStore.Data.Cart;
using ElectronicStore.Data.Service;
using ElectronicStore.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductService ProductService;
        private readonly ShoppingCart ShoppingCart;
        private readonly IOrdersService OrdersService;

        public OrdersController(IProductService productService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            ProductService = productService;
            ShoppingCart = shoppingCart;
            OrdersService = ordersService;
        }

        public IActionResult shoppingCart()
        {
            var items = ShoppingCart.getShoppingCartItems();
            ShoppingCart.shoppingCartItems = items;

            var result = new ShoppingCatViewModel()
            {
                shoppingCart = ShoppingCart,
                shoppingCartTotal = ShoppingCart.getShoppingCartTotal()
            };

            return View(result);
        }

        // Adding product to shopping cart
        public async Task<RedirectToActionResult> addToShoppingCart(int id)
        {
            var item = await ProductService.GetByIDAsync(id);

            if(item != null)
            {
                ShoppingCart.addItemToCart(item);
            }
            return RedirectToAction(nameof(shoppingCart));
        }

        // Removing product from shopping cart
        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await ProductService.GetByIDAsync(id);

            if (item != null)
            {
                ShoppingCart.removeItemFromCart(item);
            }
            return RedirectToAction(nameof(shoppingCart));
        }

        // Complete order by deleting every item
        public async Task<IActionResult> CompleteOrder()
        {
            var item = ShoppingCart.getShoppingCartItems();
            string userID = "";
            string userEmail = "";

            await OrdersService.storeOrderAsync(item, userID, userEmail);
            await ShoppingCart.clearShoppingCartAsync();
            return View("OrderComplete");
        }
    }
}
