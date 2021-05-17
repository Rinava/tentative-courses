using Exercise.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Exercise.Models.Level;

namespace Exercise.Tests
{
    [TestClass()]
    public class LevelTests
    {
        [TestMethod()]
        public void ValidLevelTest()
        {
            //arrange
            _Level currentLevel = (_Level)Enum.Parse(typeof(_Level), "Beginner");

            //act
            Boolean result = Level.ValidLevel(currentLevel);

            //assert
            Assert.IsTrue(result);
        }
    }
}