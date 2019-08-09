using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestTimeLessons
{
    [TestClass]
    public class ConstructorTests
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static TimeSpan standartBeginTime;
        static TimeSpan standartEndTime;
        static int standartNumberLessons;
        static int minNumberLessons = 1;
        private void ResetStandart()
        {
            standartBeginTime = new TimeSpan(09, 00, 00);
            standartEndTime = new TimeSpan(10, 30, 00);
            standartNumberLessons = minNumberLessons;
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
        /// Конструктор вызывает исключение при подаче numberLessons <=0
        /// </summary>
        [TestMethod]
        public void TestConstructor_NumberLessonsLessThan0_CallArgumentException()
        {
            //arrange
            ResetStandart();
            //act
            int smallNumberLessons = minNumberLessons-1;
            Random rnd = new Random();
            //assert
            for (int i = 0; i < 50; i++)
            {
                string message = $"\nДолжно быть: NumberLessons<{minNumberLessons}, у нас: NumberLessons={smallNumberLessons}";
                Assert.ThrowsException<ArgumentException>(() => new TimeLessons.TimeLessons(standartBeginTime,
                                                                                        standartEndTime,
                                                                                        smallNumberLessons), message);
                smallNumberLessons = rnd.Next(-100, minNumberLessons);
            }
        }

        /// <summary>
        /// Конструктор вызывает исключение если окончания занятий меньше начало занятий
        /// </summary>
        [TestMethod]
        public void TestConstructor_EndTimeLessThanBeginTime_CallArgumentException()
        {
            //arrange
            ResetStandart();
            //act
            TimeSpan smallEndTime = new TimeSpan(0, 0, 0);
            TimeSpan bigBeginTime = new TimeSpan(1, 0, 0);
            //assert
            Assert.ThrowsException<ArgumentException>(() => new TimeLessons.TimeLessons(bigBeginTime,
                                                                                        smallEndTime,
                                                                                        standartNumberLessons), "EndTime<=BeginTime");
        }

        /// <summary>
        /// Конструктор вызывает исключение если время пары больше 12 часов
        /// </summary>
        [TestMethod]
        public void TestConstructor_LessonDurationMoreThan12_CallArgumentException()
        {
            //arrange
            ResetStandart();
            //act
            TimeSpan testBeginTime = new TimeSpan(0, 0, 0);
            TimeSpan testEndTime = new TimeSpan(12, 0, 1);
            //assert
            Assert.ThrowsException<ArgumentException>(() => new TimeLessons.TimeLessons(testBeginTime,
                                                                                        testEndTime,
                                                                                        standartNumberLessons), "EndTime-BeginTime > 12ч");
        }

    }
}
