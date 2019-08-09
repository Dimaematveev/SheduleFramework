using System;
using System.Collections.Generic;
using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTeacher
{
    [TestClass]

    public class ToStringTests
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static List<ISubjectOfTeacher> standartSubjectOfTeachers;
        static string standartCertification;
        static int standartRate;
        static IPerson standatrPerson;
        static int maxRate = 5;
        static int minRate = 0;
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
            var teacher = new Teacher.Teacher(standartSubjectOfTeachers,
                                                standartCertification,
                                                standartRate,
                                                standatrPerson);

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
        public void TestToString_TeacherIsReady_FixedLineCheck()
        {
            //arrange
            ResetStandart();
            string assert = "Person\nSubjTeach_0\nSubjTeach_1\nSubjTeach_2\nSubjTeach_3\n";

            var testSubjectOfTeachers = new List<ISubjectOfTeacher>();
            for (int i = 0; i < 4; i++)
            {
                var tes = A.Fake<ISubjectOfTeacher>();
                A.CallTo(()=>tes.ToString()).Returns($"SubjTeach_{i}");
                testSubjectOfTeachers.Add(tes);
            }
            var testPerson = A.Fake<IPerson>();
            A.CallTo(() => testPerson.ToString()).Returns($"Person");
            //act
            var teacher = new Teacher.Teacher(testSubjectOfTeachers,
                                                standartCertification,
                                                standartRate,
                                                testPerson);

            //assert
            Assert.AreEqual(assert, teacher.ToString());
        }
    }
}
