using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSemester
{
    [TestClass]

    public class ToStringTest
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static DateTime standatrBeginSemestr;
        static DateTime standatrEndSemestr;
        static int standatrCountDaysOfStudies;
        private void ResetStandart()
        {
            standatrBeginSemestr = DateTime.Now.Date;
            standatrEndSemestr = DateTime.Now.AddDays(1).Date;
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
            Assert.AreEqual(standatrBeginSemestr.Date, semester.BeginSemestr);
            Assert.AreEqual(standatrEndSemestr.Date, semester.EndSemestr);
            Assert.AreEqual(standatrCountDaysOfStudies, semester.DaysOfStudies.Length);
        }

        /// <summary>
        /// В строку.
        /// </summary>
        [TestMethod]
        public void TestToString_SemestIsReady()
        {
            ResetStandart();
            //arrange
            string ret= $"Начало семестра 01.09.2019, " +
                $"окончание семестра 30.09.2019. Всего дней " +
                $"30.";


            //act
            var semester = new Semester.Semester(new DateTime(2019, 09, 01), new DateTime(2019, 09, 30));
            //assert
            
            Assert.AreEqual(ret, semester.ToString());

        
        }

        
    }
}

