using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WebService.DomainImplementation
{
    public class CachedBunchOfMeetings : IBunchOfMeetings
    {
        private readonly IMemoryCache cache;
        private const int periodInMinutes = 60;

        private string cacheKey => nameof(CachedBunchOfMeetings);

        public CachedBunchOfMeetings(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void Add(Meeting meeting)
        {
            var meetings = this.Load();
            meetings.Add(meeting);
            this.Save(meetings);
        }

        public IEnumerable<Meeting> Get()
        {
            var meetings = this.Load();
            return meetings.ToList();
        }

        public IEnumerable<Meeting> Get(Predicate<Meeting> predicate)
        {
            var meetings = this.Load();
            var filteredMeetings = meetings.Where(x => predicate(x));

            return filteredMeetings;
        }

        public Meeting Get(Guid id)
        {
            var meetings = this.Load();
            var meeting = meetings.FirstOrDefault(x => x.Id == id);
            if(meeting is null)
            {
                throw new ArgumentException();
            }

            return meeting;
        }

        private void Save(HashSet<Meeting> meetings)
        {
            this.cache.Set<HashSet<Meeting>>(this.cacheKey, meetings, DateTime.UtcNow.AddMinutes(periodInMinutes));
        }

        private HashSet<Meeting> Load()
        {
            var meetings = this.cache.Get<HashSet<Meeting>>(this.cacheKey);
            if (meetings is null)
            {
                meetings = new HashSet<Meeting>();
                meetings.Add(new Meeting("Default"));
                this.Save(meetings);
            }

            return meetings;
        }
    }
}
