using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkloadApp.Data.Cart;
using WorkloadApp.Data.Services;
using WorkloadApp.Data.ViewModels;
using WorkloadApp.Models;

namespace WorkloadApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IServicesService servicesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _servicesService = servicesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;

        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public async Task<IActionResult> ServiceOrders(int serviceId)
        {
            var orders = await _ordersService.GetOrdersByServiceIdAsync(serviceId);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _servicesService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> ChangeDetails(int id)
        {
            var items = _shoppingCart.GetShoppingCartItemById(id);
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeDetails(int id, ShoppingCartItem shoppingCartItem)
        {
            shoppingCartItem.ShoppingCartItemId = id;
            if (!ModelState.IsValid)
            {
                return View(shoppingCartItem);
            }
            await _shoppingCart.UpdateShoppingCartItem(shoppingCartItem);
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _servicesService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                var items = _shoppingCart.GetShoppingCartItems();
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string userEmail = User.FindFirstValue(ClaimTypes.Email);

                await _ordersService.StoreOrderAsync(items, userId, userEmail);
                await _shoppingCart.ClearShoppingCartAsync();
                return View("OrderCompleted");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
