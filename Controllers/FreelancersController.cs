using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data;
using WorkloadApp.Data.Services;
using WorkloadApp.Data.Static;
using WorkloadApp.Models;

namespace WorkloadApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FreelancersController : Controller
    {
        private readonly IFreelancersService _service;

        public FreelancersController(IFreelancersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Manage()
        {
            var allFreelancers = await _service.GetAllAsync();
            return View(allFreelancers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserId,ProfilePicURL,FreelancerName,FreelancerBio")]Freelancer freelancer)
        {
            if(!ModelState.IsValid)
            {
                return View(freelancer);
            }
            await _service.AddAsync(freelancer);
            return RedirectToAction("Manage");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null)
            {
                return View("Empty");
            }
            return View(serviceDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null)
            {
                return View("NotFound");
            }
            return View(serviceDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Freelancer freelancer)
        {
            freelancer.FreelancerId = id;
            if (!ModelState.IsValid)
            {
                return View(freelancer);
            }
            await _service.UpdateAsync(id, freelancer);
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var freelancerDetails = await _service.GetByIdAsync(id);

            if (freelancerDetails == null) return View("NotFound");
            return View(freelancerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var freelancerDetails = await _service.GetByIdAsync(id);
            if (freelancerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Profile(int id)
        {
            var freelancerDetails = await _service.GetByIdAsync(id);

            if (freelancerDetails == null) return View("NotFound");
            return View(freelancerDetails);
        }
    }
}
