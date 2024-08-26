using System.Collections.Generic;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task<List<Order>> GetOrdersByServiceIdAsync(int serviceId);
    }
}
