using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MeetingViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}
