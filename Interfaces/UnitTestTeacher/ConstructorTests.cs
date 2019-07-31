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
        public void TestConstructor_SubjectTeacherIsNull_CallException()
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
        public void TestConstructor_SubjectTeacherIsCountNull_CallException()
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
        public void TestConstructor_СertificationIsNull_CallException()
        {
            //arrange
            ResetStandart();
            //act
            string nullCertification = null;
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(standartSubjectOfTeachers, nullCertification, standartRate, standatrPerson), "NULL");
            Assert.Fail();
        }
        /// <summary>
        /// Конструктор вызывает исключение при подаче пустой строки или строки только из пробелов Certification.
        /// </summary>
        [TestMethod]
        public void TestConstructor_СertificationIsWhiteSpace_CallException()
        {
            //arrange
            ResetStandart();
            //act
            string whiteSpaceCertification = "";
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new Teacher.Teacher(standartSubjectOfTeachers, whiteSpaceCertification, standartRate, standatrPerson), "Строка из пробелов!");
            Assert.Fail();
        }
    }
}
