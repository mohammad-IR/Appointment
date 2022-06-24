using Appointment.Models;
using Appointment.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Services.Interfaces
{
    public interface IAppoinmentTimeServices
    {
        public  List<Models.AppointmentTime> StartAndEnd(int start, int end, IdentityUser user = null);
        public  List<Models.AppointmentTime> ForOneUser(IdentityUser user);
        public List<Models.AppointmentTime> ToDay(DateTime date, IdentityUser user = null);
        public List<Models.AppointmentTime> DateDay(DateTime date, IdentityUser user = null);
        public List<Models.AppointmentTime> PhoneNumber(string phoneNumber);
        public   Task<Result> CreateAsync(Models.AppointmentTime appointment);
        public  Task<Result> RemoveAsync(int id);
    }
}
