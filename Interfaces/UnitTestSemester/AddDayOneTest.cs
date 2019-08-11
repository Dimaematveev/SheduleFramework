using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestSemester
{
    [TestClass]

    public class AddDayOneTest
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
        /// Сделать один день выходным.
        /// </summary>
        /// <param name="allDays">Всего дней в диапазоне.</param>
        /// <param name="Days"> Дни выходных дня выходные.</param>
        [DataTestMethod]
        [DataRow(100, 0)]
        [DataRow(100, 99)]
        [DataRow(100, 70)]
        public void TestAddDayMany_OneToDayOff(int allDays, int day)
        {
            ResetStandart();
            //arrange

            IDaysOfStudy[] var = new IDaysOfStudy[allDays];
            for (int i = 0; i < allDays; i++)
            {
                var te = A.Fake<IDaysOfStudy>();
                te.Date = DateTime.Now.AddDays(i);
                te.Study = HowDays.WorkingDay;
                var[i] = te;
            }

            var semester = new Semester.Semester(standatrBeginSemestr, standatrEndSemestr);
            semester.DaysOfStudies = var;
            for (int i = 0; i < allDays; i++)
            {
                Assert.AreEqual(HowDays.WorkingDay, semester.DaysOfStudies[i].Study);
            }
            //act
            semester.AddDayOne(HowDays.DayOff, var[0].Date.AddDays(day));

            //assert
            for (int i = 0; i < allDays; i++)
            {
                if (day==i)
                {
                    Assert.AreEqual(HowDays.DayOff, semester.DaysOfStudies[i].Study);
                }
                else
                {
                    Assert.AreEqual(HowDays.WorkingDay, semester.DaysOfStudies[i].Study);
                }
               
            }

        }
        /// <summary>
        /// Сделать один день рабочим.
        /// </summary>
        /// <param name="allDays">Всего дней в диапазоне.</param>
        /// <param name="Days"> Дни выходных дня выходные.</param>
        [DataTestMethod]
        [DataRow(100, 0)]
        [DataRow(100, 99)]
        [DataRow(100, 70)]
        public void TestAddDayMany_OneToWorkingDay(int allDays, int day)
        {
            ResetStandart();
            //arrange

            IDaysOfStudy[] var = new IDaysOfStudy[allDays];
            for (int i = 0; i < allDays; i++)
            {
                var te = A.Fake<IDaysOfStudy>();
                te.Date = DateTime.Now.AddDays(i);
                te.Study = HowDays.DayOff;
                var[i] = te;
            }

            var semester = new Semester.Semester(standatrBeginSemestr, standatrEndSemestr);
            semester.DaysOfStudies = var;
            for (int i = 0; i < allDays; i++)
            {
                Assert.AreEqual(HowDays.DayOff, semester.DaysOfStudies[i].Study);
            }
            //act
            semester.AddDayOne(HowDays.WorkingDay, var[0].Date.AddDays(day));

            //assert
            for (int i = 0; i < allDays; i++)
            {
                if (day == i)
                {
                    Assert.AreEqual(HowDays.WorkingDay, semester.DaysOfStudies[i].Study);
                }
                else
                {
                    Assert.AreEqual(HowDays.DayOff, semester.DaysOfStudies[i].Study);
                }

            }

        }
    }
}