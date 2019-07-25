using System;
using System.Collections.Generic;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSemester
{
    [TestClass]
    public class UnitTestSemester
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static DateTime standatrBeginSemestr;
        static DateTime standatrEndSemestr;
        static List<IDaysOfStudy> standatrDaysOfStudies;
        private void ResetStandart()
        {
            standatrBeginSemestr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7);
            standatrBeginSemestr = standatrBeginSemestr.AddDays(-(int)standatrBeginSemestr.DayOfWeek);
            standatrEndSemestr = standatrBeginSemestr.AddDays(6);
            standatrDaysOfStudies = new List<IDaysOfStudy>
            {
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(0), HowDays.DayOff),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(1), HowDays.WorkingDay),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(2), HowDays.WorkingDay),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(3), HowDays.WorkingDay),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(4), HowDays.WorkingDay),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(5), HowDays.WorkingDay),
                new DaysOfStudy.DaysOfStudy(standatrBeginSemestr.AddDays(6), HowDays.WorkingDay),
            };
            
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
            for (int i = 0; i < standatrDaysOfStudies.Count; i++)
            {
                Assert.AreEqual(standatrDaysOfStudies[i].Date, semester.DaysOfStudies[i].Date,$"i={i}");
                Assert.AreEqual(standatrDaysOfStudies[i].Study, semester.DaysOfStudies[i].Study, $"i={i}");
            }
        }

        /// <summary>
        /// не сделаны тесты.
        /// </summary>
        [TestMethod]
        public void False()
        {
            Assert.Fail();
        }
    }
}
