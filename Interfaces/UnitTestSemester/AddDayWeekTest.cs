﻿using System;
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
        /// Проверка что стандартные параметры делаю конструктор без исключения.
        /// </summary>
        [TestMethod]
        public void TestStandartValue1()
        {

            //arrange
            
            IDaysOfStudy[] var = new IDaysOfStudy[100];
            for (int i = 0; i < 100; i++)
            {
                var te = A.Fake<IDaysOfStudy>();
                te.Date = DateTime.Now.AddDays(i);
                te.Study = HowDays.WorkingDay;
                var[i] = te;
            }
            var semester = new Semester.Semester(DateTime.Now.AddDays(0), DateTime.Now.AddDays(1));
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
    }
}
