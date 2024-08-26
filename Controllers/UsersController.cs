using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data;
using WorkloadApp.Data.Services;
using WorkloadApp.Models;

namespace WorkloadApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Manage()
        {
            var allUsers = await _service.GetAllAsync();
            return View(allUsers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserEmail,UserPassword,IsFreelancer,FreelancerId")] ApplicationUser user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.AddAsync(user);
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Details(string id)
        {
            var userDetails = await _service.GetByIdAsync(id);

            if (userDetails == null)
            {
                return View("NotFound");
            }
            return View(userDetails);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var userDetails = await _service.GetByIdAsync(id);

            if (userDetails == null)
            {
                return View("NotFound");
            }
            return View(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ApplicationUser user)
        {
            user.Id = id;
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.UpdateAsync(id, user);
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userDetails = await _service.GetByIdAsync(id);

            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
        
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Manage));
        }
    }
}
