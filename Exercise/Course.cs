using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Models
{
    public class Course
    {
        public List<Student> Students { get; }
        public Teacher Teacher { get; }
        public Level CurrentLevel { get; }
        public Schedule CurrentSchedule { get; }
        public Modality CurrentModality { get; }
        public int DurationMinutes { get; }

        public Course(List<Student> _students, Teacher _teacher, Level _currentLevel, Modality _currentModality, int _durationMinutes)
        {
            List < Schedule > posibleSchedules= FindScheduleIntersection(_students, _teacher, _durationMinutes);
            if (!posibleSchedules.Count.Equals(0))
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(posibleSchedules.Count);
                if (_currentModality.Equals(1) && _students.Count == 1 && _students.First().CurrentModality.Equals(1))
                {
                    Students = _students;
                    Teacher = _teacher;
                    CurrentLevel = _currentLevel;
                    CurrentSchedule = posibleSchedules.ElementAt(randomIndex);
                    CurrentModality = _currentModality;
                }
                else if (_currentModality.Equals(2) && _students.Count <= 6 && _students.All(student => student.CurrentModality.Equals(2)) && _students.All(student => student.CurrentLevel.Equals(_currentLevel)))
                {
                    Students = _students;
                    Teacher = _teacher;
                    CurrentLevel = _currentLevel;
                    CurrentSchedule = posibleSchedules.ElementAt(randomIndex);
                    CurrentModality = _currentModality;
                }
            }
            else
            {
                throw new ArgumentException("No schedule available");
            }
        }

        public List<Schedule> FindScheduleIntersection(List<Student> _students, Teacher _teacher, int _durationMinutes)
        {
            List<Schedule> scheduleIntersection = null;
            foreach (string day in Enum.GetNames(typeof(Day._CurrentDay)))
            {
                if (_students.All(student => student.AvariableSchedule.Days.All(student => student.CurrentDay.Equals(day)) && _teacher.AvariableSchedule.Days.All(teacher => teacher.CurrentDay.Equals(day))))
                {
                    TimeSpan courseStartTime = TimeSpan.Zero;
                    TimeSpan courseEndTime = TimeSpan.Zero;
                    Day teacherTime = _teacher.AvariableSchedule.Days.Find(_day => _day.Equals(day));
                    for (int i = 0; i < _students.Count; i++)
                    {
                        Day studentTime1 = _students.ElementAt(i).AvariableSchedule.Days.Find(_day => _day.Equals(day));
                        Day studentTime2 = _students.ElementAt(i + 1).AvariableSchedule.Days.Find(_day => _day.Equals(day));
                        courseStartTime = studentTime1.StartTime;
                        courseEndTime = studentTime1.EndTime;

                        if (studentTime1.StartTime <= studentTime2.EndTime && studentTime2.StartTime <= studentTime1.EndTime)
                        {
                            courseStartTime = new TimeSpan(Math.Max(studentTime1.StartTime.Ticks, studentTime2.StartTime.Ticks));
                            courseEndTime = new TimeSpan(Math.Min(studentTime1.EndTime.Ticks, studentTime2.EndTime.Ticks));
                        }
                    }
                    if (courseStartTime <= teacherTime.EndTime && teacherTime.StartTime <= courseEndTime)
                    {
                        courseStartTime = new TimeSpan(Math.Max(courseStartTime.Ticks, teacherTime.StartTime.Ticks));
                        courseEndTime = new TimeSpan(Math.Min(courseEndTime.Ticks, teacherTime.EndTime.Ticks));
                        if ((courseEndTime.Minutes - courseStartTime.Minutes) >= _durationMinutes)
                        {
                            Day currentDay = new Day(day, courseStartTime, courseEndTime);
                            Schedule schedule = new Schedule();
                            schedule.Days.Add(currentDay);
                            scheduleIntersection.Add(schedule);
                        }
                    }
                }
                else
                {
                }
            }
            return scheduleIntersection;
        }
    }
}