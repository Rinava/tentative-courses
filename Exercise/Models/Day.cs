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

        public Day(string day, TimeSpan _startTime, TimeSpan _endTime)
        {
            CurrentDay=(_CurrentDay)Enum.Parse(typeof(_CurrentDay), day);
            if(_startTime.Hours>=9 && _endTime.Hours<= 19)
            {
                StartTime = _startTime;
                EndTime = _endTime;
            }
            else
            {
                throw new ArgumentException("Wrong parameter value  " + nameof(_startTime) +" or " + nameof(_endTime));
            }

        }
    }
}