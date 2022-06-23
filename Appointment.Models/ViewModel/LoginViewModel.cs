using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="ایمیل"), Required(ErrorMessage="ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "پسورد"), Required(ErrorMessage="رمز را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "به خاطر اسپاردن رمز")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
