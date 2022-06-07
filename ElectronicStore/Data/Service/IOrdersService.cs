using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public interface IOrdersService
    {
        Task storeOrderAsync(List<ShoppingCartItem> cartItems, string userID, string userEmail);
        Task<List<Order>> getOrdersByUserIDAsync(string userID);
    }
}
