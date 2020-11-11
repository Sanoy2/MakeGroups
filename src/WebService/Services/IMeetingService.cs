using System;
using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface IMeetingService
    {
        IEnumerable<MeetingViewModel> Get();

        ParticipantsViewModel Participants(Guid meetingId);
    }
}
