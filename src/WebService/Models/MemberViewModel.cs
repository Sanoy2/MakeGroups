using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MemberViewModel : ParticipantViewModel
    {
        public MemberViewModel(string name) : base(name)
        {
            this.IsLeader = false;
        }
    }
}
