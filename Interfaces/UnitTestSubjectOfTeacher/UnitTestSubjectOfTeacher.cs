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
        /// <summary>
        /// Тест конструктора. 
        /// </summary>
        /// <param name="nameSubject">Название предмета.</param>
        /// <param name="percent">Процент готовности вести предмет.</param>
        /// <param name="result">Тип исключения!</param>
        [DataTestMethod]
        [DataRow(null,5, typeof(ArgumentNullException))]
        [DataRow("Subj1",-1, typeof(ArgumentException))]
        [DataRow("Subj2",101, typeof(ArgumentException))]
        public void TestConstructor_Exception(string nameSubject,int percent, Type result)
        {
            ResetStandart();
            Type exception = null;

            ISubject subject=null;
            if (nameSubject != null)
            {
                subject = new Subject.Subject(nameSubject);
            }
            //arrange
            try
            {
                //act
                var subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(subject, percent);
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
        /// <param name="nameSubject">Название предмета.</param>
        /// <param name="percent">Процент готовности вести предмет.</param>
        [DataTestMethod]
        [DataRow("Subj1",0)]
        [DataRow("Subj2",100)]
        public void TestConstructor_True(string nameSubject, int percent)
        {
            ResetStandart();
            var subject = new Subject.Subject(nameSubject);
            //arrange
            var subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(subject, percent);
            //act

            //assert
            Assert.AreEqual(subject, subjectOfTeacher.Subject);
            Assert.AreEqual(percent, subjectOfTeacher.Percent);
        }

        /// <summary>
        /// Тест Метода ToString.   Надо часто обновлять!!!!!!
        /// </summary>
        /// <param name="nameSubject">Кафедра.</param>
        /// <param name="departament">Кафедра.</param>
        /// <param name="percent">Процент готовности вести предмет.</param>
        /// <param name="toSting">Какая строка должна получиться.</param>
        [DataTestMethod]
        [DataRow("Subj1", "KB5",10, "Преподаватель готов вести предмет Subj1 с уверенностью в 10%")]
        [DataRow("Subj2", "KB4", 100, "Преподаватель готов вести предмет Subj2 с уверенностью в 100%")]
        public void TestToString_True(string nameSubject, string departament,int percent, string toString)
        {
            ResetStandart();
            //arrange
            var subject = new Subject.Subject(nameSubject, departament);
            //act
            var subjectOfTeacher = new SubjectOfTeacher.SubjectOfTeacher(subject, percent);

            //assert
            Assert.AreEqual(toString, subjectOfTeacher.ToString());
        }
    }
}
