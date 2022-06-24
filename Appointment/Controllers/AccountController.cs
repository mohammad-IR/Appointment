using Appointment.Data;
using Appointment.Models;
using Appointment.Models.ViewModel;
using Appointment.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            //HttpContext.Current.Request.Url.Scheme
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result =  _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: true).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    if (user.ReturnUrl != null)
                    {
                        return LocalRedirect(user.ReturnUrl);

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    
                }

            }
            return View(user);
        }
        

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.
                            CreateAsync(new ApplicationUser()
                            {
                                UserName = user.Email,
                                Email = user.Email,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                PhoneNumber = user.PhoneNumber,
                                DateOfAccount = DateTime.Now
                            }, user.Password);
                if (result.Succeeded)
                {
                    var userRegistered = _db.ApplicationUsers.FirstOrDefault(item => item.Email == user.Email);
                    await _userManager.AddToRoleAsync(userRegistered, SD.Role_User);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "باید مقادیر تلفن و ایمیل یکتا باشند");

                }

            }
            return View(user);
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            var users = _db.ApplicationUsers;
            return View(users);
        }   
    }
}
