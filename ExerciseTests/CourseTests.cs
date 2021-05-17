using Exercise.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static Exercise.Models.Day;
using static Exercise.Models.Level;
using static Exercise.Models.Modality;

namespace Exercise.Tests
{
    [TestClass()]
    public class CourseTests
    {
        [TestMethod()]
        public void FoundIntersectionSchedules()
        {
            //arrange

            int durationMinutes = 60;
            //Teacher
            List<Day> daysTeacher = new();
            daysTeacher.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysTeacher.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleTeacher = new (daysTeacher);
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
            Student student1 = new ("2", "José", "Neón", scheduleStudent1, "1", levelStudent1, modalityStudent1);

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
            //assert
            Assert.IsFalse(result.Count==0);
        }

        [TestMethod()]
        public void ValidIndividualModality()
        {
            //arrange
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudent1 = new();
            levelStudent1.CurrentLevel = _Level.Beginner;
            Modality modalityStudent1 = new();
            modalityStudent1.CurrentModality = _Modality.Individual;
            Student student1 = new("2", "José", "Neón", scheduleStudent1, "1", levelStudent1, modalityStudent1);

            List<Student> students = new();
            students.Add(student1);
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Individual;

            //Act
            Boolean result = Course.ValidIndividualModality(students, currentModality);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidIndividualModality_TwoStudents()
        {
            //arrange
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudent1 = new();
            levelStudent1.CurrentLevel = _Level.Beginner;
            Modality modalityStudent1 = new();
            modalityStudent1.CurrentModality = _Modality.Individual;
            Student student1 = new("2", "José", "Neón", scheduleStudent1, "1", levelStudent1, modalityStudent1);
            Student student2 = new("3", "Joséfina", "Neónina", scheduleStudent1, "2", levelStudent1, modalityStudent1);

            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Individual;

            //Act
            Boolean result = Course.ValidIndividualModality(students, currentModality);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidGroupModality()
        {
            //arrange
            Level currentLevel = new();
            currentLevel.CurrentLevel = _Level.Beginner;
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Group;

            //Students
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudents = new();
            levelStudents.CurrentLevel = _Level.Beginner;
            Modality modalityStudents = new();
            modalityStudents.CurrentModality = _Modality.Group;
            Student student1 = new ("2", "José", "Neón", scheduleStudent1, "1", levelStudents, modalityStudents);

            List<Day> daysStudent2 = new();
            daysStudent2.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent2.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent2 = new(daysStudent2);

            Student student2 = new("3", "Mariana", "Leopaldo", scheduleStudent2, "2", levelStudents, modalityStudents);

            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);

            Boolean result = Course.ValidGroupModality(students, currentLevel, currentModality);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidGroupModality_SevenStudents()
        {
            //arrange
            Level currentLevel = new();
            currentLevel.CurrentLevel = _Level.Beginner;
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Group;

            //Students
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudents = new();
            levelStudents.CurrentLevel = _Level.Beginner;
            Modality modalityStudents = new();
            modalityStudents.CurrentModality = _Modality.Group;
            Student student1 = new ("2", "José", "Neón", scheduleStudent1, "1", levelStudents, modalityStudents);

            List<Day> daysStudent2 = new();
            daysStudent2.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent2.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent2 = new(daysStudent2);

            Student student2 = new("3", "Mariana", "Leopaldo", scheduleStudent2, "2", levelStudents, modalityStudents);

            Student student3 = new("4", "Mariano", "Leopaldo", scheduleStudent2, "3", levelStudents, modalityStudents);
            Student student4 = new("5", "Lucas", "Leopaldo", scheduleStudent2, "4", levelStudents, modalityStudents);
            Student student5 = new("6", "Luciana", "Leopaldo", scheduleStudent2, "5", levelStudents, modalityStudents);
            Student student6 = new("7", "Irina", "Casacasas", scheduleStudent2, "6", levelStudents, modalityStudents);
            Student student7 = new("8", "Noco", "Respondo", scheduleStudent2, "7", levelStudents, modalityStudents);
            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            students.Add(student6);
            students.Add(student7);

            Boolean result = Course.ValidGroupModality(students, currentLevel, currentModality);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidGroupModality_DistinctLevels()
        {
            //arrange
            Level currentLevel = new();
            currentLevel.CurrentLevel = _Level.Beginner;
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Group;

            //Students
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudent1 = new();
            levelStudent1.CurrentLevel = _Level.Advanced;
            Modality modalityStudents = new();
            modalityStudents.CurrentModality = _Modality.Group;
            Student student1 = new ("2", "José", "Neón", scheduleStudent1, "1", levelStudent1, modalityStudents);

            List<Day> daysStudent2 = new();
            daysStudent2.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent2.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent2 = new(daysStudent2);
            Level levelStudent2 = new();
            levelStudent2.CurrentLevel = _Level.Upper_Intermediate;
            Student student2 = new("3", "Mariana", "Leopaldo", scheduleStudent2, "2", levelStudent2, modalityStudents);

            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);

            Boolean result = Course.ValidGroupModality(students, currentLevel, currentModality);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidGroupModality_StudentWrongModality()
        {
            //arrange
            Level currentLevel = new();
            currentLevel.CurrentLevel = _Level.Beginner;
            Modality currentModality = new();
            currentModality.CurrentModality = _Modality.Group;

            //Students
            List<Day> daysStudent1 = new();
            daysStudent1.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent1.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent1 = new(daysStudent1);
            Level levelStudents = new();
            levelStudents.CurrentLevel = _Level.Beginner;
            Modality modalityStudent1 = new();
            modalityStudent1.CurrentModality = _Modality.Group;
            Student student1 = new ("2", "José", "Neón", scheduleStudent1, "1", levelStudents, modalityStudent1);

            List<Day> daysStudent2 = new();
            daysStudent2.Add(new Day(_CurrentDay.Monday, new TimeSpan(9, 30, 0), new TimeSpan(13, 30, 0)));
            daysStudent2.Add(new Day(_CurrentDay.Thursday, new TimeSpan(15, 0, 0), new TimeSpan(19, 0, 0)));

            Schedule scheduleStudent2 = new(daysStudent2);
            Modality modalityStudent2 = new();
            modalityStudent2.CurrentModality = _Modality.Individual;
            Student student2 = new("3", "Mariana", "Leopaldo", scheduleStudent2, "2", levelStudents, modalityStudent2);

            List<Student> students = new();
            students.Add(student1);
            students.Add(student2);

            Boolean result = Course.ValidGroupModality(students, currentLevel, currentModality);
            Assert.IsFalse(result);
        }
    }
}