using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Commands
{
    public class JoinMeeting
    {
        public Guid MeetingId { get; set; }

        public string UserId { get; set; }
    }
}
