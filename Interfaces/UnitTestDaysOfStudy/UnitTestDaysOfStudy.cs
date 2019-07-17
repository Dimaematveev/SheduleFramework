using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDaysOfStudy
{
    [TestClass]
    public class UnitTestDaysOfStudy
    {
        [DataTestMethod]
        [DataRow("02.05.2018", Interface.Interface.HowDays.DayOff)]
        [DataRow("01.04.2019", Interface.Interface.HowDays.WorkingDay)]
        public void TestConstructorIsTrue(string dates, Interface.Interface.HowDays study)
        {
            //arrange
            DateTime date = DateTime.Parse(dates);
            //assert
            var daysOfStudy = new DaysOfStudy.DaysOfStudy(date, study);
        }
        [DataTestMethod]
        [DataRow("02.05.2018", Interface.Interface.HowDays.DayOff, "2(DayOff)")]
        [DataRow("01.04.2019", Interface.Interface.HowDays.WorkingDay, "1(WorkingDay)")]
        public void TestToString(string dates, Interface.Interface.HowDays study, string toString)
        {
            //arrange
            DateTime date = DateTime.Parse(dates);
            var daysOfStudy = new DaysOfStudy.DaysOfStudy(date, study);
            //act
            var str = daysOfStudy.ToString();
            //assert
            Assert.AreEqual(str, toString);

        }

    }
}
