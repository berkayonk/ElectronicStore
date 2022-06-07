using ElectronicStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Cart
{
    public class ShoppingCart
    {
        public DatabaseContext Context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public ShoppingCart(DatabaseContext context)
        {
            Context = context;
        }

        // Check Session
        public static ShoppingCart getShoppingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<DatabaseContext>();

            string cartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartID);
            return new ShoppingCart(context) { ShoppingCartId = cartID };
        }

        public void addItemToCart(Product product)
        {
            var shoppingCartItem = Context.shoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                Context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            Context.SaveChanges();
        }

        public void removeItemFromCart(Product product)
        {
            var shoppingCartItem = Context.shoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    Context.shoppingCartItems.Remove(shoppingCartItem);
                }                
            }
            Context.SaveChanges();
        }

        public List<ShoppingCartItem> getShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = Context.shoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(p => p.Product).ToList());
        }

        public double getShoppingCartTotal()
        {
            var total = Context.shoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(p => p.Product.productPrice * p.Amount).Sum();
            return total;
        }

        public async Task clearShoppingCartAsync()
        {
             var item = await Context.shoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).ToListAsync();
            Context.shoppingCartItems.RemoveRange(item);
            await Context.SaveChangesAsync();
        }
    }
}
