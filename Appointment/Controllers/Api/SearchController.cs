using Appointment.Data;
using Appointment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers.Api
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize("Admin")]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IAppoinmentTimeServices _timeServices;
        public SearchController(ApplicationDbContext db, IAppoinmentTimeServices timeServices)
        {
            _timeServices = timeServices;
            _db = db;
        }
        public List<Models.AppointmentTime> SearchByDate(DateTime date)
        {
            return _timeServices.DateDay(date);
        }
        public List<Models.AppointmentTime> SearchIntervalDay(int start, int end)
        {
            return _timeServices.StartAndEnd(start, end);
        }
        public List<Models.AppointmentTime> SearchByPhone(int phoneNumber)
        {
            return _timeServices.PhoneNumber(phoneNumber.ToString());
        }

    }
}
