using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSemester
{
    [TestClass]

    public class AddDayWeekTest
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static DateTime standatrBeginSemestr;
        static DateTime standatrEndSemestr;
        static int standatrCountDaysOfStudies;
        private void ResetStandart()
        {
            standatrBeginSemestr = DateTime.Now;
            standatrEndSemestr = DateTime.Now.AddDays(1);
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
        /// Сделать воскресенье выходным.
        /// </summary>
        [TestMethod]
        public void TestAddDayWeek_SundayToDayOff()
        {
            ResetStandart();
            //arrange

            IDaysOfStudy[] var = new IDaysOfStudy[100];
            for (int i = 0; i < 100; i++)
            {
                var te = A.Fake<IDaysOfStudy>();
                te.Date = DateTime.Now.AddDays(i);
                te.Study = HowDays.WorkingDay;
                var[i] = te;
            }
            
            var semester = new Semester.Semester(standatrBeginSemestr, standatrEndSemestr);
            semester.DaysOfStudies = var;
            //act
            semester.AddDayWeek(DayOfWeek.Sunday, HowDays.DayOff);
            //assert
            foreach (var item in semester.DaysOfStudies)
            {
                if (item.Date.DayOfWeek== DayOfWeek.Sunday)
                {
                    Assert.AreEqual(HowDays.DayOff, item.Study);
                }
                else
                {
                    Assert.AreEqual(HowDays.WorkingDay, item.Study);
                }
            }
        }
        /// <summary>
        /// Сделать с понедельника по пятницу рабочими выходным.
        /// </summary>
        [TestMethod]
        public void TestAddDayWeek_MonToFriToWorkingDay()
        {
            ResetStandart();
            //arrange

            IDaysOfStudy[] var = new IDaysOfStudy[100];
            for (int i = 0; i < 100; i++)
            {
                var te = A.Fake<IDaysOfStudy>();
                te.Date = DateTime.Now.AddDays(i);
                te.Study = HowDays.DayOff;
                var[i] = te;
            }

            var semester = new Semester.Semester(standatrBeginSemestr, standatrEndSemestr);
            semester.DaysOfStudies = var;
            //act
            semester.AddDayWeek(DayOfWeek.Monday, HowDays.WorkingDay);
            semester.AddDayWeek(DayOfWeek.Tuesday, HowDays.WorkingDay);
            semester.AddDayWeek(DayOfWeek.Wednesday, HowDays.WorkingDay);
            semester.AddDayWeek(DayOfWeek.Thursday, HowDays.WorkingDay);
            semester.AddDayWeek(DayOfWeek.Friday, HowDays.WorkingDay);
            //assert
            foreach (var item in semester.DaysOfStudies)
            {
                if (item.Date.DayOfWeek == DayOfWeek.Sunday || item.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    Assert.AreEqual(HowDays.DayOff, item.Study);
                }
                else
                {
                    Assert.AreEqual(HowDays.WorkingDay, item.Study);
                }
            }
        }
    }
}
