using System.Collections.Generic;

namespace Exercise.Models
{
    public class Schedule
    {
        public List<Day> Days { get; set; }

        public Schedule()
        {
        }

        public Schedule(List<Day> _days)
        {
            Days = _days;
        }
    }
}