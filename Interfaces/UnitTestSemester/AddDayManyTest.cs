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
        /// Сделать диапазон дней выходными.
        /// </summary>
        /// <param name="allDays">Всего дней в диапазоне.</param>
        /// <param name="beginDay">С какого дня выходные.</param>
        /// <param name="endDay">До какого дня выходные.</param>
        [DataTestMethod]
        [DataRow( 100, 30, 51)]
        [DataRow( 100, 0, 51)]
        [DataRow( 100, 0, 99)]
        public void TestAddDayMany_RangeToDayOff(int allDays, int beginDay, int endDay )
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
            semester.AddDayMany(HowDays.DayOff, var[0].Date.AddDays(beginDay), var[0].Date.AddDays(endDay));
            //assert
            for (int i = beginDay; i <= endDay; i++)
            {
                Assert.AreEqual(HowDays.DayOff, semester.DaysOfStudies[i].Study);
            }
            
        }
        /// <summary>
        /// Сделать диапазон дней выходными.
        /// </summary>
        /// <param name="allDays">Всего дней в диапазоне.</param>
        /// <param name="beginDay">С какого дня выходные.</param>
        /// <param name="endDay">До какого дня выходные.</param>
        [DataTestMethod]
        [DataRow(100, 30, 51)]
        [DataRow(100, 0, 51)]
        [DataRow(100, 0, 99)]
        public void TestAddDayMany_RangeToWorkingDay(int allDays, int beginDay, int endDay)
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
            semester.AddDayMany(HowDays.WorkingDay, var[0].Date.AddDays(beginDay), var[0].Date.AddDays(endDay));
            //assert
            for (int i = beginDay; i <= endDay; i++)
            {
                Assert.AreEqual(HowDays.WorkingDay, semester.DaysOfStudies[i].Study);
            }

        }
    }
}
