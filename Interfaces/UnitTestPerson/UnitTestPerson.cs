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

        /// <summary>
        /// Тест конструктора. 
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="IsGender">Показывает передается null или Gender.</param>
        /// <param name="stingBirthDay">Строка даты. Должна быть нормальным.</param>
        /// <param name="living">Где живет.</param>
        /// <param name="result">Тип исключения!</param>
        [DataTestMethod]
        [DataRow(null,true, "11.01.1959","HZ", typeof(ArgumentNullException))]
        [DataRow("  \t \n", true, "11.01.1959","HZ", typeof(ArgumentNullException))]
        [DataRow("Name1",false , "11.01.1869","HZ", typeof(ArgumentNullException))]
        [DataRow("Name1", true, "11.01.1869","HZ", typeof(ArgumentException))]
        [DataRow("Name1", true, "25.02.2222","HZ", typeof(ArgumentException))]
        [DataRow("Name1", true, "11.01.1959",null, typeof(ArgumentNullException))]
        [DataRow("Name1", true, "11.01.1959", "  \t \n", typeof(ArgumentNullException))]
        public void TestConstructor_Exception(string name, bool IsGender, string stingBirthDay, string living, Type result)
        {
            ResetStandart();
            IGender gender = null;
            if (IsGender)
            {
                gender = standatrGender;
            }
            DateTime birthDay = DateTime.Parse(stingBirthDay);
            Type exception = null;
            //arrange
            try
            {
                //act
                var person = new Person.Person(name, gender, birthDay, living);
            }
            catch (Exception ex)
            {
                //assert
                exception = ex.GetType();
            }
            finally
            {
                Assert.AreEqual(result, exception);
            }
        }
        /// <summary>
        /// Тест конструктора. 
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="stingBirthDay">Строка даты. Должна быть нормальным.</param>
        /// <param name="living">Где живет.</param>
        [DataTestMethod]
        [DataRow("Name1!@#!@#", "11.01.1969","HZ12F@@")]
        [DataRow("Name2", "11.01.2018", "HZ!@13")]

        public void TestConstructor_True(string name,  string stingBirthDay, string living)
        {
            //arrange
            ResetStandart();
            IGender gender = standatrGender;
           
            DateTime birthDay = DateTime.Parse(stingBirthDay);
            
            //act
            var person = new Person.Person(name, gender, birthDay, living);
            //assert
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(gender, person.Gender);
            Assert.AreEqual(birthDay, person.BirthDay);
            Assert.AreEqual(living, person.Living);
        }
        /// <summary>
        /// Проверка свойства Age.  Надо часто обновлять!!!!!!
        /// </summary>
        /// <param name="stingBirthDay">Строка даты. Должна быть нормальным.</param>
        /// <param name="age">Возраст.</param>
        [DataTestMethod]
        [DataRow("11.01.1969",50)]
        [DataRow("11.12.1969",49)]
        [DataRow("22.07.1969",50)]
        [DataRow("23.07.1969",49)]
        [DataRow("11.01.2018", 1)]

        public void TestPropertyAge_True(string stingBirthDay, int age)
        {
            //arrange
            ResetStandart();
            
            DateTime birthDay = DateTime.Parse(stingBirthDay);

            //act
            var person = new Person.Person(standatrName,standatrGender,  birthDay, standatrLiving);
            //assert
            Assert.AreEqual(age, person.Age);
        }

        /// <summary>
        /// Тест Метода ToString.   Надо часто обновлять!!!!!!
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="stingGender">Строка названия гендера. Должна быть нормальным.</param>
        /// <param name="stingBirthDay">Строка даты. Должна быть нормальным.</param>
        /// <param name="living">Где живет.</param>
        /// <param name="toSting">Какая строка должна получиться.</param>
        [DataTestMethod]
        [DataRow("Name1", "men", "11.01.1969", "HZ", "Пол men имя Name1 возраст 50")]
        [DataRow("Name2", "women", "11.12.1969", "HZ", "Пол women имя Name2 возраст 49")]
        [DataRow("Name3", "men", "22.07.1969", "HZ", "Пол men имя Name3 возраст 50")]
        [DataRow("Name4", "men", "23.07.1969", "HZ", "Пол men имя Name4 возраст 49")]
        [DataRow("Name5", "woemen", "11.01.2018", "HZ",  "Пол woemen имя Name5 возраст 1")]
        public void TestToString_True(string name, string stingGender, string stingBirthDay, string living, string toSting)
        {
            //arrange
            ResetStandart();
            IGender gender = new Gender.Gender(stingGender);
            DateTime birthDay = DateTime.Parse(stingBirthDay);
            //act
            var person = new Person.Person(name, gender, birthDay, living);
            //assert
            Assert.AreEqual(toSting, person.ToString());
        }
    }
}
