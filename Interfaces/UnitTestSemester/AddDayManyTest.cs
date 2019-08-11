using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSemester
{
    [TestClass]

    public class AddDayManyTest
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

    }
}
