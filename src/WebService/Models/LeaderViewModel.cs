using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class LeaderViewModel : ParticipantViewModel
    {
        public LeaderViewModel(string name, string id) : base(name, id)
        {
            this.IsLeader = true;
        }
    }
}
