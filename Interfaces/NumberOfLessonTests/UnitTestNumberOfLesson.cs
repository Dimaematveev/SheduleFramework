using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOfLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNumberOfLesson
{
    [TestClass()]
    public class UnitTestNumberOfLesson
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать  </value>
        static ISubject standatrSubject;
        static int standatrNumberSubject;
        private void ResetStandart()
        {
            standatrSubject = new Subject.Subject("mat");
            standatrNumberSubject = 1;
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
            var numberOfLesson = new NumberOfLesson.NumberOfLesson(standatrSubject, standatrNumberSubject);
            //assert
            Assert.AreEqual(1, numberOfLesson.NumberSubject);
            Assert.AreEqual(standatrSubject, numberOfLesson.Subject);
        }
        /// <summary>
        /// Тест конструктора. 
        /// </summary>
        /// <param name="IsSubject">Показывает передается null или Subject.</param>
        /// <param name="numberSubject">Количество пар за семестр.</param>
        /// <param name="result">Какое исключение должно вызваться.</param>
        [DataTestMethod]
        [DataRow(false, 1, typeof(ArgumentNullException))]
        [DataRow(true, 0, typeof(ArgumentException))]
        [DataRow(true, -1, typeof(ArgumentException))]
        [DataRow(false, -1, typeof(ArgumentNullException))]
        public void TestConstructor_Exception(bool IsSubject, int numberSubject, Type result)
        {
            ResetStandart();
            ISubject subject=null;
            if (IsSubject)
            {
                subject = standatrSubject;
            }
            Type exception = null;
            //arrange
            try
            {
                //act
                var numberOfLesson = new NumberOfLesson.NumberOfLesson(subject, numberSubject);
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
        /// Тест конструктора с заполненным предметом.. 
        /// </summary>
        /// <param name="numberSubject">Количество пар за семестр.</param>
        [DataTestMethod]
        [DataRow( 1)]
        [DataRow( 80)]
        public void TestConstructor_True(int numberSubject)
        {
            ResetStandart();
            ISubject subject = standatrSubject;
            
            //arrange
            
            //act
            var numberOfLesson = new NumberOfLesson.NumberOfLesson(subject, numberSubject);
         
         
            Assert.AreEqual(subject, numberOfLesson.Subject);
            Assert.AreEqual(numberSubject, numberOfLesson.NumberSubject);
          
        }
        /// <summary>
        /// Проверка метода ToString.
        /// </summary>
        /// <param name="nameSubject">Название предмета.</param>
        /// <param name="numberSubject">Количество пар за семестр.</param>
        /// <param name="result">Что должен возвращать.</param>
        [DataTestMethod]
        [DataRow("NameSubj",12,"NameSubj - 12")]
        [DataRow("Book",1,"Book - 1")]
        public void TestToString(string nameSubject, int numberSubject,string result)
        {
            ISubject subject = new Subject.Subject(nameSubject);
            var numberOfLesson = new NumberOfLesson.NumberOfLesson(subject, numberSubject);

             
            Assert.AreEqual(result, numberOfLesson.ToString());
        }
    }
}