using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTimeLessons
{
    [TestClass]
    public class ToStringTests
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static TimeSpan standartBeginTime;
        static TimeSpan standartEndTime;
        static int standartNumberLessons;
        private void ResetStandart()
        {
            standartBeginTime = new TimeSpan(09, 00, 00);
            standartEndTime = new TimeSpan(10, 30, 00);
            standartNumberLessons = 1;
        }

        /// <summary>
        /// Проверка что стандартные параметры делаю конструктор без исключения.
        /// </summary>
        [TestMethod]
        public void TestStandartValue()
        {
            ResetStandart();
            //arrange
            //act
            var timeLessons = new TimeLessons.TimeLessons(standartBeginTime,
                                                            standartEndTime,
                                                            standartNumberLessons);

            //assert
            Assert.AreEqual(standartBeginTime, timeLessons.BeginTime);
            Assert.AreEqual(standartEndTime, timeLessons.EndTime);
            Assert.AreEqual(standartNumberLessons, timeLessons.NumberLessons);
        }

        /// <summary>
        /// Конструктор вызывает исключение при подаче вместо списка SubjectTeacher -> null.
        /// </summary>
        [TestMethod]
        public void TestToString_TimeLessonsIsReady_FixedLineCheck()
        {
            //arrange
            ResetStandart();
            int testNumberLessons = 1;
            TimeSpan testBeginTime = new TimeSpan(9, 0, 0);
            TimeSpan testEndTime = new TimeSpan(10, 30, 0);
            
            string assert = "Пара № 1 с 09:00:00 по 10:30:00";
            //act
            var timeLessons = new TimeLessons.TimeLessons(testBeginTime,
                                                          testEndTime,
                                                          testNumberLessons);

            //assert
            Assert.AreEqual(assert, timeLessons.ToString());

        }
    }
}
