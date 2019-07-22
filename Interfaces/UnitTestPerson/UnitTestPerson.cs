using System;
using Interface.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPerson
{
    [TestClass]
    public class UnitTestPerson
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать  </value>
        string standatrName;
        IGender standatrGender;
        DateTime standatrBirthDay;
        int standatrAge;
        string standatrLiving;
        private void ResetStandart()
        {
            standatrName = "Name1";
            standatrGender = new Gender.Gender("men");
            standatrAge = 19;
            standatrBirthDay = new DateTime(DateTime.Now.Year- standatrAge, DateTime.Now.Month, DateTime.Now.Day);
            standatrLiving = "unknown";
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
            var person = new Person.Person(standatrName, standatrGender, standatrBirthDay, standatrLiving);
            //assert
            Assert.AreEqual(standatrName, person.Name);
            Assert.AreEqual(standatrGender, person.Gender);
            Assert.AreEqual(standatrBirthDay, person.BirthDay);
            Assert.AreEqual(standatrAge, person.Age);
            Assert.AreEqual(standatrLiving, person.Living);
        }
    }
}
