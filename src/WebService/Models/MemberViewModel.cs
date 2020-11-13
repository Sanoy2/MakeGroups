using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MemberViewModel : ParticipantViewModel
    {
        public MemberViewModel(string name, string id) : base(name, id)
        {
            this.IsLeader = false;
        }
    }
}
