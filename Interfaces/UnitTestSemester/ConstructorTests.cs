using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSemester
{
    [TestClass]

    public class ConstructorTests
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static DateTime standatrBeginSemestr;
        static DateTime standatrEndSemestr;
        static int standatrCountDaysOfStudies;
        private void ResetStandart()
        {
            standatrBeginSemestr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7);
            standatrEndSemestr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 8);
            standatrCountDaysOfStudies = 2;
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
            var semester = new Semester.Semester(standatrBeginSemestr, standatrEndSemestr);
            //assert
            Assert.AreEqual(standatrBeginSemestr, semester.BeginSemestr);
            Assert.AreEqual(standatrEndSemestr, semester.EndSemestr);
            Assert.AreEqual(standatrCountDaysOfStudies, semester.DaysOfStudies.Length);
        }



        /// <summary>
        /// Конструктор вызывает исключение при подаче даты начала семестра ранее 7 лет.
        /// </summary>
        [TestMethod]
        public void TestConstructor_BeginSemestrLess7Old_CallArgumentException()
        {
            //arrange
            ResetStandart();
            DateTime testBeginSemestr = new DateTime(DateTime.Now.Year - 8, 12, 31);
            DateTime testEndSemestr = testBeginSemestr.AddDays(60);
            //act

            //assert
            Assert.ThrowsException<ArgumentException>(() => new Semester.Semester(  testBeginSemestr, 
                                                                                    testEndSemestr), "NULL");
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче  даты окончания семестра более 7 лет.
        /// </summary>
        [TestMethod]
        public void TestConstructor_EndSemestrMore7Old_CallArgumentException()
        {
            //arrange
            ResetStandart();
            DateTime testEndSemestr  = new DateTime(DateTime.Now.Year + 7, 1, 2);
            DateTime testBeginSemestr = testEndSemestr.AddDays(-60);
            //act

            //assert
            Assert.ThrowsException<ArgumentException>(() => new Semester.Semester(testBeginSemestr,
                                                                                    testEndSemestr), "NULL");
        }
        /// <summary>
        /// Конструктор вызывает исключение если дата окончания семестра раньше даты начала семестра.
        /// </summary>
        [TestMethod]
        public void TestConstructor_EndSemestrLessThanBeginSemestr_CallArgumentException()
        {
            //arrange
            ResetStandart();
            DateTime testEndSemestr = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime testBeginSemestr = testEndSemestr;
            //act

            //assert
            Assert.ThrowsException<ArgumentException>(() => new Semester.Semester(testBeginSemestr,
                                                                                    testEndSemestr), "NULL");
        }
        /// <summary>
        /// Конструктор вызывает исключение если семестр длиться больше 180 дней.
        /// </summary>
        [TestMethod]
        public void TestConstructor_SemeserMore180_CallArgumentException()
        {
            //arrange
            ResetStandart();
            DateTime testBeginSemestr = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime testEndSemestr = testBeginSemestr.AddDays(181);
            //act

            //assert
            Assert.ThrowsException<ArgumentException>(() => new Semester.Semester(testBeginSemestr,
                                                                                    testEndSemestr), "NULL");
        }

    }
}
