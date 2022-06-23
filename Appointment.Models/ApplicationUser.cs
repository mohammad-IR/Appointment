using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "وقت مورد نظر")]
        public DateTime DateOfAccount { get; set; }
    }
}
