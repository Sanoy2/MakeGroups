using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class ParticipantViewModel : UserViewModel
    {
        public bool IsLeader { get; set; }

        public ParticipantViewModel(string name, string id) : base(name, id) { }
    }
}
