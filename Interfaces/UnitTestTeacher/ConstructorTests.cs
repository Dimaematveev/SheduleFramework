using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTeacher
{
    [TestClass]
    
    public class ConstructorTests
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static List<ISubjectOfTeacher> standartSubjectOfTeachers;
        static string standartCertification;
        static int standartRate;
        static IPerson standatrPerson;
        private void ResetStandart()
        {
            standartSubjectOfTeachers = new List<ISubjectOfTeacher>
            {
                A.Fake<ISubjectOfTeacher>()
            };
            standartCertification = "none";
            standartRate = 1;
            standatrPerson = A.Fake<IPerson>();
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
            var teacher = new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, standartRate, standatrPerson);

            //assert
            Assert.AreEqual(standartSubjectOfTeachers, teacher.SubjectOfTeachers);
            Assert.AreEqual(standartCertification, teacher.Certification);
            Assert.AreEqual(standartRate, teacher.Rate);
            Assert.AreEqual(standatrPerson, teacher.Person);
        }
        
        /// <summary>
        /// Конструктор вызывает исключение при подаче вместо списка SubjectTeacher -> null.
        /// </summary>
        [TestMethod]
        public void TestConstructor_SubjectTeacherIsNull_CallArgumentNullException()
        {
            //arrange
            ResetStandart();
            //act
            List<ISubjectOfTeacher> nullSubjectOfTeachers = null;
            //assert
            Assert.ThrowsException<ArgumentNullException>(()=>new Teacher.Teacher(nullSubjectOfTeachers, standartCertification, standartRate, standatrPerson),"NULL");
            
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче пустого списка SubjectTeacher.
        /// </summary>
        [TestMethod]
        public void TestConstructor_SubjectTeacherIsCountNull_CallArgumentNullException()
        {
            //arrange
            ResetStandart();
            //act
            var countNullSubjectOfTeachers = new List<ISubjectOfTeacher>();
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(countNullSubjectOfTeachers, standartCertification, standartRate, standatrPerson), "Count=0");

        }

        /// <summary>
        /// Конструктор вызывает исключение при подаче вместо строки Certification -> null.
        /// </summary>
        [TestMethod]
        public void TestConstructor_СertificationIsNull_CallArgumentNullException()
        {
            //arrange
            ResetStandart();
            //act
            string nullCertification = null;
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(standartSubjectOfTeachers, nullCertification, standartRate, standatrPerson), "NULL");
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче пустой строки или строки только из пробелов Certification.
        /// </summary>
        /// <param name="whiteSpaceСharactersCertification">строка подачи.</param>
        [DataTestMethod]
        [DataRow("")]
        [DataRow("\n")]
        [DataRow("\t")]
        [DataRow("  ")]
        [DataRow(" \n \t     ")]
        public void TestConstructor_СertificationIsWhiteSpace_CallArgumentNullException(string whiteSpaceСharactersCertification)
        {
            //arrange
            ResetStandart();
            //act
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(standartSubjectOfTeachers, whiteSpaceСharactersCertification, standartRate, standatrPerson), "Строка из пробелов!");
        }

        /// <summary>
        /// Конструктор вызывает исключение при подаче Rate>=5
        /// </summary>
        [TestMethod]
        public void TestConstructor_RateMoreThan5_CallArgumentException()
        {
            //arrange
            ResetStandart();
            //act
            int min = 5;//Максимальное значения для Rate 
            int bigRate = min;
            //assert
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100; i++)
            {
                string message = $"\nДолжно быть: Rate<={min}, у нас: Rate={bigRate}";
                Assert.ThrowsException<ArgumentException>(() => new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, bigRate, standatrPerson), message);
                bigRate = rnd.Next(min,100);
            }
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче Rate<=0
        /// </summary>
        [TestMethod]
        public void TestConstructor_RateLessThan0_CallArgumentException()
        {
            //arrange
            ResetStandart();
            //act
            int max=0;//Максимальное значения для Rate 
            int smallRate = max;
             //assert
             Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100; i++)
            {
                string message = $"\nДолжно быть: Rate<={max}, у нас: Rate={smallRate}";
                Assert.ThrowsException<ArgumentException>(() => new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, smallRate, standatrPerson), message);
                smallRate = rnd.Next(-100, max);
            }
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче вместо списка Person -> null.
        /// </summary>
        [TestMethod]
        public void TestConstructor_PersonIsNull_CallArgumentNullException()
        {
            //arrange
            ResetStandart();
            //act
            IPerson nullPerson = null;
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, standartRate, nullPerson), "NULL");
        }

        /// <summary>
        /// Проверка что получиться создать класс.
        /// </summary>
        [TestMethod]
        public void TestConstructor_()
        {
            ResetStandart();
            //arrange
            //act
            var teacher = new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, standartRate, standatrPerson);

            //assert
            Assert.AreEqual(standartSubjectOfTeachers, teacher.SubjectOfTeachers);
            Assert.AreEqual(standartCertification, teacher.Certification);
            Assert.AreEqual(standartRate, teacher.Rate);
            Assert.AreEqual(standatrPerson, teacher.Person);
        }
    }
}
