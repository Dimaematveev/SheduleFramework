using System;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSubjectOfTeacher
{
    [TestClass]
    public class UnitTestSubjectOfTeacher
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static ISubject standatrSubject;
        static string standatrNameSubject;
        static int standatrPercent;
        private void ResetStandart()
        {
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
