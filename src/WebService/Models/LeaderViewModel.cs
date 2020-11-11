using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class LeaderViewModel : ParticipantViewModel
    {
        public LeaderViewModel(string name) : base(name)
        {
            this.IsLeader = true;
        }
    }
}
