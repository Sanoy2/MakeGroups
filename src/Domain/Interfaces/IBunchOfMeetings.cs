using Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Domain.Interfaces
{
    public interface IBunchOfMeetings
    {
        IEnumerable<Meeting> Get();

        IEnumerable<Meeting> Get(Predicate<Meeting> predicate);

        Meeting Get(Guid id);

        void Add(Meeting meeting);
    }
}
