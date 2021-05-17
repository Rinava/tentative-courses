using System;
using System.Collections.Generic;
using System.Linq;
using static Exercise.Models.Day;
using static Exercise.Models.Modality;

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

        public Course()
        {
        }

        public Course(List<Student> _students, Teacher _teacher, Level _currentLevel, Modality _currentModality, int _durationMinutes)
        {
            List<Schedule> posibleSchedules = FindScheduleIntersection(_students, _teacher, _durationMinutes);
            if (!posibleSchedules.Count.Equals(0))
            {
                Random rnd = new ();
                int randomIndex = rnd.Next(posibleSchedules.Count);
                if (ValidIndividualModality(_students, _currentModality))
                {
                    Students = _students;
                    Teacher = _teacher;
                    CurrentLevel = _currentLevel;
                    CurrentSchedule = posibleSchedules.ElementAt(randomIndex);
                    CurrentModality = _currentModality;
                }
                else if (ValidGroupModality(_students, _currentLevel, _currentModality))
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

        public static List<Schedule> FindScheduleIntersection(List<Student> _students, Teacher _teacher, int _durationMinutes)
        {
            List<Schedule> scheduleIntersection = new();

            foreach (_CurrentDay day in Enum.GetValues<_CurrentDay>())
            {
                if (_students.All(student => student.AvariableSchedule.Days.Any(_day => _day.CurrentDay.Equals(day))) &&  _teacher.AvariableSchedule.Days.Any(_day => _day.CurrentDay.Equals(day)))
                {
                    TimeSpan courseStartTime = TimeSpan.Zero;
                    TimeSpan courseEndTime = TimeSpan.Zero;
                    Day teacherTime = _teacher.AvariableSchedule.Days.Find(_day => _day.CurrentDay.Equals(day));
                    for (int i = 0; i < _students.Count - 1 ; i++)
                    {
                        Day studentTime1 = _students.ElementAt(i).AvariableSchedule.Days.Find(_day => _day.CurrentDay.Equals(day));
                        Day studentTime2 = _students.ElementAt(i + 1).AvariableSchedule.Days.Find(_day => _day.CurrentDay.Equals(day));
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
                        if ((courseEndTime.TotalMinutes - courseStartTime.TotalMinutes) >= _durationMinutes)
                        {
                            Day currentDay = new(day, courseStartTime, courseEndTime);
                            Schedule schedule = new();
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

        public static Boolean ValidIndividualModality(List<Student> _students, Modality _currentModality)
        {
            if (_currentModality.CurrentModality.Equals(_Modality.Individual) && _students.Count == 1 && _students.First().CurrentModality.CurrentModality.Equals(_Modality.Individual))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean ValidGroupModality(List<Student> _students, Level _currentLevel, Modality _currentModality)
        {
            if (_currentModality.CurrentModality.Equals(_Modality.Group) && _students.Count <= 6 && _students.All(student => student.CurrentModality.CurrentModality.Equals(_Modality.Group)) && _students.All(student => student.CurrentLevel.CurrentLevel.Equals(_currentLevel.CurrentLevel)))
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