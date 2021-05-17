using Exercise.Models;
using System;
using System.Collections.Generic;
using static Exercise.Models.Day;
using static Exercise.Models.Level;
using static Exercise.Models.Modality;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationMinutes = 60;
            //Teacher
            List<Day> daysTeacher = new();
            daysTeacher.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysTeacher.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleTeacher = new(daysTeacher);
            Teacher teacher = new("1", "Susana", "Gimenez", scheduleTeacher, "1");

            //Students
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudent1 = new();
            levelStudent1.CurrentLevel = _Level.Beginner;
            Modality modalityStudent1 = new();
            modalityStudent1.CurrentModality = _Modality.Group;
            Student student1 = new("2", "José", "Neón", scheduleStudent1, "1", levelStudent1, modalityStudent1);

            List<Day> daysStudent2 = new();
            daysStudent2.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent2.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent2 = new(daysStudent2);
            Level levelStudent2 = new();
            levelStudent2.CurrentLevel = _Level.Beginner;
            Modality modalityStudent2 = new();
            modalityStudent2.CurrentModality = _Modality.Group;
            Student student2 = new("3", "Mariana", "Leopaldo", scheduleStudent2, "2", levelStudent2, modalityStudent2);

            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);

            //act
            List<Schedule> result = Course.FindScheduleIntersection(students, teacher, durationMinutes);
            Console.ReadKey();
            Console.WriteLine("maiu");
        }
    }
}
