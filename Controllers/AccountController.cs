using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkloadApp.Data;
using WorkloadApp.Data.Services;
using WorkloadApp.Data.Static;
using WorkloadApp.Data.ViewModels;
using WorkloadApp.Models;

namespace WorkloadApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IServicesService _service;
        private readonly IFreelancersService _freelancer;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IServicesService service, IFreelancersService freelancer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
            _freelancer = freelancer;
        }

        public IActionResult Login() => View(new LoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passcheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passcheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Services");
                    }
                }
                TempData["Error"] = "Wrong credentails.";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentails.";
            return View(loginVM);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Freelance()
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                if (User.IsInRole("Freelancer"))
                {
                    var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var freelancerAcc = await _freelancer.GetByUserIdAsync(user);

                    if (freelancerAcc != null )
                    {
                        var services = await _service.GetByFreelanceIdAsync(freelancerAcc.FreelancerId);
                        return View(services);
                    }
                    return RedirectToAction("Index", "Services");
                }
                else
                {
                    return RedirectToAction("BecomeFreelancer");
                }
            }
            return RedirectToAction("Index", "Services");
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Email adress already in use.";
                return View(registerVM);
            }

            var newuser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var result = await _userManager.CreateAsync(newuser, registerVM.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newuser, UserRoles.User);
            }
            return View("RegisterCompleted");
        }

        public IActionResult BecomeFreelancer() => View(new FreelancerVM());

        [HttpPost]
        public async Task<IActionResult> BecomeFreelancer(FreelancerVM freelancerVM)
        {
            if (!ModelState.IsValid) return View(freelancerVM);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var freelancerAcc = await _freelancer.GetByUserIdAsync(userId);
            if (freelancerAcc != null)
            {
                TempData["Error"] = "Your account is already a freelancer.";
                return View(freelancerVM);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // Handle the case where the user cannot be found
                return NotFound();
            }

            var newFreelancer = new Freelancer()
            {
                UserId = userId,
                ProfilePicURL = freelancerVM.ProfilePicURL,
                FreelancerName = freelancerVM.FreelancerName,
                FreelancerBio = freelancerVM.FreelancerBio
            };

            await _freelancer.AddAsync(newFreelancer);
            var success = await _freelancer.GetByIdAsync(newFreelancer.FreelancerId);
            if (success == null)
            {
                // Handle the case where adding the freelancer fails
                TempData["Error"] = "Failed to become a freelancer.";
                return View(freelancerVM);
            }

            // Add the Freelancer role to the user
            var addToRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.Freelancer);
            if (!addToRoleResult.Succeeded)
            {
                // Handle the case where adding the role to the user fails
                TempData["Error"] = "Failed to assign the Freelancer role.";
                return View(freelancerVM);
            }

            return View("NowFreelancer");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Services");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
