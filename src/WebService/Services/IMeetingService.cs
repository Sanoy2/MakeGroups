using System;
using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface IMeetingService
    {
        IEnumerable<MeetingViewModel> Get();

        ParticipantsViewModel Participants(Guid meetingId);

        void Create(string meetingName);

        void JoinAsMember(Guid meetingId, string userNameWithDomain);

        void JoinAsLeader(Guid meetingId, string userNameWithDomain);

        void Leave(Guid meetingId, string userNameWithDomain);

        void ArrangeTeams(Guid meetingId);

        void ClearTeams(Guid meetingId);
    }
}
