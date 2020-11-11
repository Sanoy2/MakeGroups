using Microsoft.AspNetCore.Mvc;
using WebService.Services;

namespace WebService.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IMeetingService meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        public IActionResult Index()
        {
            var meetings = this.meetingService.Get();

            return View(meetings);
        }
    }
}
