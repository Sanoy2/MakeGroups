using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IBunchOfMeetings bunchOfMeetings;
        private readonly IUserFactory userFactory;

        public MeetingService(IBunchOfMeetings meetings, IUserFactory userFactory)
        {
            this.bunchOfMeetings = meetings;
            this.userFactory = userFactory;
        }

        public void Create(string meetingName)
        {
            if (string.IsNullOrWhiteSpace(meetingName))
            {
                throw new ArgumentNullException(nameof(meetingName));
            }

            Meeting meeting = new Meeting(meetingName);
            this.bunchOfMeetings.Add(meeting);
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

        public void JoinAsLeader(Guid meetingId, string userNameWithDomain)
        {
            User user = this.userFactory.Create(userNameWithDomain);
            Meeting meeting = this.bunchOfMeetings.Get(meetingId);
            meeting.AddLeader(user);
        }

        public void JoinAsMember(Guid meetingId, string userNameWithDomain)
        {
            User user = this.userFactory.Create(userNameWithDomain);
            Meeting meeting = this.bunchOfMeetings.Get(meetingId);
            meeting.AddMember(user);
        }

        public void Leave(Guid meetingId, string userNameWithDomain)
        {
            User user = this.userFactory.Create(userNameWithDomain);
            Meeting meeting = this.bunchOfMeetings.Get(meetingId);
            meeting.Remove(user);
        }

        public ParticipantsViewModel Participants(Guid meetingId)
        {
            List<ParticipantViewModel> participants = new List<ParticipantViewModel>();

            Meeting meeting = this.bunchOfMeetings.Get(meetingId);
            if (meeting is null)
            {
                throw new ArgumentException($"Meeting with id {@meetingId} does not exis");
            }

            participants.AddRange(meeting.Leaders.Select(x => new LeaderViewModel(x.Name, x.Id)));
            participants.AddRange(meeting.Members.Select(x => new MemberViewModel(x.Name, x.Id)));

            ParticipantsViewModel viewModel = new ParticipantsViewModel(meeting.Name, meeting.Id);
            viewModel.Participants = participants;

            return viewModel;
        }
    }
}
