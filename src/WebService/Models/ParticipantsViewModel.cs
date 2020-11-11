using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public class ParticipantsViewModel
    {
        public List<ParticipantViewModel> Participants { get; set; }

        public string MeetingName { get; set; }

        public Guid MeetingId { get; set; }

        public ParticipantsViewModel(string meetingName, Guid meetingId)
        {
            this.MeetingName = meetingName;
            this.MeetingId = meetingId;
        }
    }
}
