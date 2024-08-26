using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data.Static;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByServiceIdAsync(int serviceId)
        {
            var ordersQuery = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Service).Include(n => n.User)
                //.Where(n => n.OrderItems.Any(n => n.ServiceId == serviceId))
                .ToListAsync();

            Console.WriteLine(ordersQuery);
            return ordersQuery;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Service).Include(n => n.User).ToListAsync();
            
            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                UserEmail = userEmail
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ServiceId = item.Service.ServiceId,
                    Details = item.Details,
                    OrderId = order.OrderId,
                    Price = item.Service.ServicePrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
