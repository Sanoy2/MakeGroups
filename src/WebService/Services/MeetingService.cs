using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IBunchOfMeetings bunchOfMeetings;

        public MeetingService(IBunchOfMeetings meetings)
        {
            this.bunchOfMeetings = meetings;
        }
        public IEnumerable<MeetingViewModel> Get()
        {
            var meetingsVM = this.bunchOfMeetings.Get().Select(x => new MeetingViewModel()
            {
                Created = x.CreateDate,
                Id = x.Id,
                Name = x.Name
            });

            return meetingsVM;
        }
    }
}
