using ElectronicStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly DatabaseContext context;

        public OrdersService(DatabaseContext Context)
        {
            context = Context;
        }

        public async Task<List<Order>> getOrdersByUserIDAsync(string userID)
        {
            var order = await context.Orders.Include(o => o.orderItems).ThenInclude(p => p.Product).Where(u => u.UserId == userID).ToListAsync();
            return order;
        }


        public async Task storeOrderAsync(List<ShoppingCartItem> cartItems, string userID, string UserEmail)
        {
            var order = new Order()
            {
                UserId = userID,
                Email = UserEmail
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            foreach(var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.productPrice
                };
                await context.orderItems.AddAsync(orderItem);
            }
            await context.SaveChangesAsync();
        }
    }
}
