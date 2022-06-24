using Appointment.Data;
using Appointment.Services;
using Appointment.Services.Interfaces;
using Appointment.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppoinmentTimeServices _appoinmentTimeServices;
        public AppointmentController(ApplicationDbContext db
            , UserManager<IdentityUser> userManager, 
            IAppoinmentTimeServices appoinmentTimeServices)
        {
            _appoinmentTimeServices = appoinmentTimeServices;
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(SD.Role_Admin))
            {
                var appointmentTimes =  _appoinmentTimeServices.StartAndEnd(-365, +365);
                return View(appointmentTimes);
            }
            else
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var appointmentTimes = _appoinmentTimeServices.StartAndEnd(-365, +365, user);
                return View(appointmentTimes);

            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Models.AppointmentTime appointment)
        {
            var user = _db.ApplicationUsers
                .FirstOrDefault(item => item.UserName == HttpContext.User.Identity.Name);
            appointment.UserId = user.Id;
            appointment.User = user;
            if (appointment.AppontmentTime > DateTime.Now)
            {
                Result result = await _appoinmentTimeServices.CreateAsync(appointment);
                if (result == Result.Success)
                {
                    TempData["success"] = "با موفقیت ثبت شد";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "در ثبت شدن مشکل ایجاد شد";
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "زمان مدل باید از امروز به بعد باشد");
            }

            
            return View(appointment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appoinmentTimeServices.RemoveAsync(id);
            if(result == Result.Success)
            {
                TempData["success"] = "با موفقیت حذف شد";
                return RedirectToAction("Index");
            }
            TempData["error"] = "با موفقیت حذف نشد";
            return RedirectToAction("Index");
        }
    }
}
