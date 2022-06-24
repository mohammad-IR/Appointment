using Appointment.Data;
using Appointment.Models;
using Appointment.Services.Interfaces;
using Appointment.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Services
{
    public class AppoinmentTimeServices : IAppoinmentTimeServices
    {
        private readonly ApplicationDbContext _db;
        public AppoinmentTimeServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public  List<Models.AppointmentTime> StartAndEnd(int start, int end, IdentityUser user = null) 
        {
            if (user == null)
            {
                return _db.AppointmentTimes.Where(item =>
                item.AppontmentTime > DateTime.Now.AddDays(start) &&
                item.AppontmentTime < DateTime.Now.AddDays(end)
                ).Include(item => item.User).ToList();
            }
            else
            {
                return _db.AppointmentTimes.Where(item =>
                   item.AppontmentTime.Day > DateTime.Now.AddDays(start).Day &&
                   item.AppontmentTime.Day < DateTime.Now.AddDays(end).Day
                   ).
                   Include(item => item.User).
                   Where(item => item.UserId == user.Id).ToList();

            }
            return new List<Models.AppointmentTime>();
        }
        public  List<Models.AppointmentTime> DateDay(DateTime date, IdentityUser user = null)
        {
            if (user == null) {
                return _db.AppointmentTimes
                        .Where((item) => item.AppontmentTime == date)
                        .Include(item => item.User).
                        ToList();
            }
            else
            {
                return _db.AppointmentTimes.
                    Where((item) => item.AppontmentTime == date)
                    .Include(item => item.User)
                    .Where(item => item.UserId == user.Id).
                    ToList();
            }
        }
        public  List<Models.AppointmentTime> ToDay(DateTime date, IdentityUser user = null)
        {
            if (user == null)
            {
                return _db.AppointmentTimes
                    .Where((item) => item.AppontmentTime == DateTime.Now)
                    .Include(item => item.User)
                    .ToList();
            }
            else
            {
                return _db.AppointmentTimes
                    .Where((item) => item.AppontmentTime == DateTime.Now).Include(item => item.User)
                    .Where(item => item.UserId == user.Id)
                    .ToList();
            }
        }
        public List<Models.AppointmentTime> ForOneUser(IdentityUser user)
        {
            return _db.AppointmentTimes.
                Where((item) => item.UserId == user.Id).
                Include(item => item.User)
                .ToList();
        }
        public async Task<Result> RemoveAsync(int id)
        {
            try
            {
                var appointment = _db.AppointmentTimes.FirstOrDefault(item => item.Id == id);
                _db.AppointmentTimes.Remove(appointment);
                await _db.SaveChangesAsync();
                return Result.Success;
            }
            catch(Exception ex)
            {
                return Result.Failure;
            }
            return Result.Failure;
        }
        public async Task<Result> CreateAsync(Models.AppointmentTime appointment)
        {
            try
            {
                var appointments = _db.AppointmentTimes.
                    Where((item) =>
                    item.AppontmentTime.AddMinutes(-30) < appointment.AppontmentTime
                    && item.AppontmentTime.AddMinutes(30) > appointment.AppontmentTime);
                if (appointments == null)
                {
                    _db.AppointmentTimes.Add(appointment);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return Result.Failure;
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }

        }

        public List<Models.AppointmentTime> PhoneNumber(string phoneNumber)
        {
            return _db.AppointmentTimes.
                Include(item => item.User).
                Where(item => item.User.PhoneNumber == phoneNumber).ToList();
        }



    }
   
}
