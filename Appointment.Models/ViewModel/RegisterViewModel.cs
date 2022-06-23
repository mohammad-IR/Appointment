using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name ="نام"), Required(ErrorMessage="نام را وارد نکردید")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی"), Required(ErrorMessage="نام خانوادگی رو وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "ایمیل"), Required(ErrorMessage="ایمیل را وارد کنید"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "تلفن همراه"), Required(ErrorMessage="تلفن را وارد کنید "), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "پسورد"), Required(ErrorMessage="در وارد کردن پسورد دقت کنید "), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار پسورد"), Required(ErrorMessage= "در وارد کردن پسورد دقت کنید "), DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfig { get; set; }

    }
}
