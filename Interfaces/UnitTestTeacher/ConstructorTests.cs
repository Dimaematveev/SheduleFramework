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
                A.Fake<ISubjectOfTeacher>(),
                A.Fake<ISubjectOfTeacher>(),
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
        public void TestConstructor_SubjectTeacherIsNullOrCountNull_CallException()
        {
            //arrange
            ResetStandart();
            //act
            //assert
            Assert.ThrowsException<ArgumentNullException>(()=>new Teacher.Teacher(null, standartCertification, standartRate, standatrPerson),"NULL");
            standartSubjectOfTeachers = new List<ISubjectOfTeacher>();
            Assert.ThrowsException<ArgumentNullException>(()=>new Teacher.Teacher(standartSubjectOfTeachers, standartCertification, standartRate, standatrPerson),"Count=0");

        }

    }
}
