using Exercise.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exercise.Tests
{
    [TestClass()]
    public class DayTests
    {
        [TestMethod()]
        public void CorrectTimeIntervalInput()
        {
            //arrange

            TimeSpan startTime = (new TimeSpan(8, 30, 0));
            TimeSpan endTime = (new TimeSpan(20, 30, 0));

            //act
            Boolean result = Day.ValidTimeInterval(startTime, endTime);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void StartTimeIsLessThanEndTime()
        {
            //arrange

            TimeSpan startTime = (new TimeSpan(11, 30, 0));
            TimeSpan endTime = (new TimeSpan(9, 30, 0));

            //act
            Boolean result = Day.ValidTimeInterval(startTime, endTime);

            //assert
            Assert.IsFalse(result);
        }
    }
}