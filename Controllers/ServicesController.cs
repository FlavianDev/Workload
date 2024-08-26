using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkloadApp.Data;
using WorkloadApp.Data.Services;
using WorkloadApp.Data.Static;
using WorkloadApp.Data.ViewModels;
using WorkloadApp.Models;

namespace WorkloadApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ServicesController : Controller
    {
        private readonly IServicesService _service;
        private readonly IFreelancersService _freelancer;

        public ServicesController(IServicesService service, IFreelancersService freelancer)
        {
            _service = service;
            _freelancer = freelancer;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allServices = await _service.GetAllAsync();
            return View(allServices);
        }

        public async Task<IActionResult> Manage()
        {
            var allServices = await _service.GetAllAsync();
            return View(allServices);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var serviceCities = await _service.GetParameters();
            ViewBag.Cities = new SelectList(serviceCities.Cities, "CityId", "CityName");
            if (User.IsInRole("Freelancer")) 
            {
                return View();
            }
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(NewServiceVM data)
        {
            if (User.IsInRole("Freelancer"))
            {
                var freelancerAcc = await _freelancer.GetByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                data.FreelancerId = freelancerAcc.FreelancerId;
                if (!ModelState.IsValid)
                {
                    var serviceCities = await _service.GetParameters();
                    ViewBag.Cities = new SelectList(serviceCities.Cities, "CityId", "CityName");
                    return View(data);
                }
                await _service.AddAsync(data);
            
                return RedirectToAction("Freelance", "Account");
            }
            if (User.IsInRole("Admin"))
            {
                if (!ModelState.IsValid)
                {
                    var serviceCities = await _service.GetParameters();
                    ViewBag.Cities = new SelectList(serviceCities.Cities, "CityId", "CityName");
                    return View(data);
                }
                await _service.AddAsync(data);

                return RedirectToAction("Manage");
            }
            return RedirectToAction("Index", "Services");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null)
            {
                return View("NotFound");
            }
            if (serviceDetails.ServiceActive == false)
            {
                return View("NotFound");
            }
            return View(serviceDetails);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Edit(int id)
        {
            var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewServiceVM()
            {
                ServiceId = serviceDetails.ServiceId,
                FreelancerId = serviceDetails.FreelancerId,
                ServiceName = serviceDetails.ServiceName,
                ServiceDescription = serviceDetails.ServiceDescription,
                ServicePicURL = serviceDetails.ServicePicURL,
                ServiceUM = serviceDetails.ServiceUM,
                ServiceActive = serviceDetails.ServiceActive,
                ServicePrice = serviceDetails.ServicePrice,
                Cities_ServicesIds = serviceDetails.Cities_Services.Select(n => n.CityId).ToList()
            };
            var serviceCities = await _service.GetParameters();
            ViewBag.Cities = new SelectList(serviceCities.Cities, "CityId", "CityName");
            serviceDetails.Cities_Services.Select(n => n.CityId).ToList();

            if (User.IsInRole("Freelancer"))
            {
                var freelancerAcc = await _freelancer.GetByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                if (serviceDetails.Freelancer.FreelancerId == freelancerAcc.FreelancerId)
                {
                    return View(response);
                }
                return RedirectToAction("AccessDenied", "Account");
            }
            if (User.IsInRole("Admin"))
            {
                return View(response);
            }
            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(int id, NewServiceVM service)
        {
            var serviceDetails = await _service.GetByIdAsync(id);
            if (serviceDetails == null) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _service.UpdateAsync(service);
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Manage));
            }
            return RedirectToAction("Freelance", "Account");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            /*var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null) return View("NotFound");
            return View(serviceDetails);*/
            var serviceDetails = await _service.GetByIdAsync(id);

            if (serviceDetails == null)
            {
                return View("NotFound");
            }
            if (User.IsInRole("Freelancer"))
            {
                var freelancerAcc = await _freelancer.GetByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (serviceDetails.Freelancer.FreelancerId == freelancerAcc.FreelancerId)
                {
                    return View(serviceDetails);
                }
                return RedirectToAction("AccessDenied", "Account");
            }
            if (User.IsInRole("Admin"))
            {
                return View(serviceDetails);
            }
            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost, ActionName("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var serviceDetails = await _service.GetByIdAsync(id);
            if (serviceDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Manage));
            }
            return RedirectToAction("Freelance", "Account");
        }
    }
}
