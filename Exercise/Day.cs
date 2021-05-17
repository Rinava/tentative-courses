using System;

namespace Exercise.Models
{
    public class Day
    {
        //Posible days of the week
        public enum _CurrentDay
        {
            Monday,
            Thursday,
            Wednesday,
            Tuesday,
            Friday
        }

        public _CurrentDay CurrentDay { get; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }

        public Day()
        {
        }

        public Day(_CurrentDay day, TimeSpan _startTime, TimeSpan _endTime)
        {
            if (ValidTimeInterval(_startTime, _endTime))
            {
                CurrentDay = day;
                StartTime = _startTime;
                EndTime = _endTime;
            }
            else { throw new ArgumentException("Wrong parameter value  " + nameof(_startTime) + " or " + nameof(_endTime)); }
        }

        public static Boolean ValidTimeInterval(TimeSpan _startTime, TimeSpan _endTime)
        {
            if (_startTime.Hours >= 9 && _endTime.Hours <= 19 && _startTime <= _endTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}