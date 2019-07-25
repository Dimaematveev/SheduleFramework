using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSubject
{
    [TestClass]
    public class UnitTestSubject
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать! Переделывать  </value>
        static string standatrNameSubject;
        static string standatrDepartament;
        private void ResetStandart()
        {
            standatrNameSubject ="Матан";
            standatrDepartament = "КБ-3";
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
            var subject1 = new Subject.Subject(standatrNameSubject);
            var subject2 = new Subject.Subject(standatrNameSubject, standatrDepartament);
            //assert
            Assert.AreEqual(standatrNameSubject, subject1.NameSubject);
            Assert.AreEqual(null, subject1.Departament);
            Assert.AreEqual(standatrNameSubject, subject2.NameSubject);
            Assert.AreEqual(standatrDepartament, subject2.Departament);
        }

        /// <summary>
        /// Тест конструктора1. 
        /// </summary>
        /// <param name="nameSubject">Название предмета.</param>
        /// <param name="result">Тип исключения!</param>
        [DataTestMethod]
        [DataRow( " \n\t    ", typeof(ArgumentNullException))]
        [DataRow( null, typeof(ArgumentNullException))]
        public void TestConstructor1_Exception(string nameSubject,Type result)
        {
            ResetStandart();
            Type exception = null;
            //arrange
            try
            {
                //act
                var subject = new Subject.Subject(nameSubject);
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
        /// Тест конструктора2. 
        /// </summary>
        /// <param name="departament">Кафедра.</param>
        /// <param name="result">Тип исключения!</param>
        [DataTestMethod]
        [DataRow(" \n\t    ", typeof(ArgumentNullException))]
        [DataRow(null, typeof(ArgumentNullException))]
        public void TestConstructor2_Exception( string departament, Type result)
        {
            ResetStandart();
            Type exception = null;
            //arrange
            try
            {
                //act
                var subject = new Subject.Subject(standatrNameSubject, departament);
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
        /// Тест конструктора1. 
        /// </summary>
        /// <param name="nameSubject">Кафедра.</param>
        [DataTestMethod]
        [DataRow("eddede")]
        [DataRow("@3334ty311")]
        public void TestConstructor1_True(string nameSubject)
        {
            ResetStandart();
            
            //arrange
           
            //act
            var subject = new Subject.Subject(nameSubject);
            //assert
            Assert.AreEqual(nameSubject, subject.NameSubject);
            Assert.AreEqual(null, subject.Departament);
        }
        /// <summary>
        /// Тест конструктора2. 
        /// </summary>
        /// <param name="nameSubject">Кафедра.</param>
        /// <param name="departament">Кафедра.</param>
        [DataTestMethod]
        [DataRow("eddede","342@")]
        [DataRow("@@@331","!!!!")]
        public void TestConstructor2_True(string nameSubject, string departament)
        {
            ResetStandart();

            //arrange

            //act
            var subject = new Subject.Subject(nameSubject, departament);
            //assert
            Assert.AreEqual(nameSubject, subject.NameSubject);
            Assert.AreEqual(departament, subject.Departament);
        }

        /// <summary>
        /// Тест Метода ToString.   Надо часто обновлять!!!!!!
        /// </summary>
        /// <param name="nameSubject">Кафедра.</param>
        /// <param name="departament">Кафедра.</param>
        /// <param name="toSting">Какая строка должна получиться.</param>
        [DataTestMethod]
        [DataRow("eddede", "342@", "eddede")]
        [DataRow("KB-5", "WER45T", "KB-5")]
        public void TestToString_True(string nameSubject, string departament, string toString)
        {
            ResetStandart();
            //arrange

            //act
            var subject = new Subject.Subject(nameSubject, departament);
            //assert
            Assert.AreEqual(toString, subject.ToString());
        }
    }
}
