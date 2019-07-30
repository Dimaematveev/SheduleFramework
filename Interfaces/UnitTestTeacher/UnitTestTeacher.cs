using System;
using System.Collections.Generic;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTeacher
{
    [TestClass]
    public class UnitTestTeacher
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static List<ISubjectOfTeacher> standartSubjectOfTeachers;
        static string standartCertification;
        static int standartRate;
        private void ResetStandart()
        {
            standartSubjectOfTeachers = new List<ISubjectOfTeacher>
            {
                new SubjectOfTeacher.SubjectOfTeacher(new Subject.Subject("Матанализ"),10),
                new SubjectOfTeacher.SubjectOfTeacher(new Subject.Subject("Физика"),100)
            };
            standatrNameSubject = "Матанализ";
            standatrSubject = new Subject.Subject(standatrNameSubject);
            standatrPercent = 100;
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
            var subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(standatrSubject, standatrPercent);

            //assert
            Assert.AreEqual(standatrSubject, subjectOfTeacher.Subject);
            Assert.AreEqual(standatrPercent, subjectOfTeacher.Percent);
        }
    }
}
