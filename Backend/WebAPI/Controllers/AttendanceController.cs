using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService attendanceService;

        public AttendanceController()
        {
            attendanceService = new AttendanceService();
        }

        [Authorize(Roles = "user, admin")]
        [Route("attendance")]
        [HttpPost]
        public async Task<IActionResult> CreateAttendanceAsync(AttendanceREST attendance)
        {
            var result = await attendanceService.CreateAttendanceAsync(new Attendance(attendance.EventId, attendance.UserId));

            if (result)
            {
                return Ok(attendance);
            }

            return BadRequest("Attendance not created.");
        }
    }

    public class AttendanceREST
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
    }
}