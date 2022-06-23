using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public DateTime AppontmentTime { get; set; }

    }
}
