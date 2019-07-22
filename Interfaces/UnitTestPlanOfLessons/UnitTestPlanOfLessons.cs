using System;
using System.Collections.Generic;
using Interface.Interface;
using Interface.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPlanOfLessons
{
    [TestClass]
    public class UnitTestPlanOfLessons
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать  </value>
        static IGroup standatrGroup;
        static List<INumberOfLesson> standatrNumberOfLessons;
        static INumberOfLesson standatrNumberOfLesson;
        private void ResetStandart()
        {
            standatrGroup = new Group.Group("NBO", 3, "NBO-3", TypeStudy.EveningClass);
            standatrNumberOfLesson = new NumberOfLesson.NumberOfLesson(new Subject.Subject("subj1"), 3);
            standatrNumberOfLessons = new List<INumberOfLesson>
            {
                standatrNumberOfLesson,
                standatrNumberOfLesson
            };
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
            var planOfLessons = new PlanOfLessons.PlanOfLessons(standatrGroup, standatrNumberOfLessons);
            //assert
            Assert.AreEqual(standatrGroup, planOfLessons.Group);
            Assert.AreEqual(standatrNumberOfLessons, planOfLessons.NumberOfLesson);
        }


        /// <summary>
        /// Тест конструктора. 
        /// </summary>
        /// <param name="IsSubject">Показывает передается null или Group.</param>
        /// <param name="numberOfNumberOfLesson">Количество NumberOfLesson в списке либо null.</param>
        /// <param name="result">Какое исключение должно вызваться.</param>
        [DataTestMethod]
        [DataRow(false, 1, typeof(ArgumentNullException))]
        [DataRow(true, 0, typeof(ArgumentNullException))]
        [DataRow(true, null, typeof(ArgumentNullException))]
        public void TestConstructor_Exception(bool IsGroup, int? numberOfNumberOfLesson, Type result)
        {
            ResetStandart();

            IGroup group = null;
            if (IsGroup)
            {
                group = standatrGroup;
            }
            List<INumberOfLesson> numberOfLessons = null;
            if (numberOfNumberOfLesson != null)
            {
                List<INumberOfLesson> tempNumberOfLesson = new List<INumberOfLesson>();
                for (int i = 0; i < numberOfNumberOfLesson; i++)
                {
                    tempNumberOfLesson.Add(standatrNumberOfLesson);
                }
                numberOfLessons = tempNumberOfLesson;
            }
            Type exception = null;
            //arrange
            try
            {
                //act
                var planOfLessons = new PlanOfLessons.PlanOfLessons(group, numberOfLessons);
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
        /// <param name="numberOfNumberOfLesson">Количество NumberOfLesson в списке.</param>
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(23)]
        public void TestConstructor_True(int numberOfNumberOfLesson)
        {
            ResetStandart();

            List<INumberOfLesson> numberOfLessons = new List<INumberOfLesson>();
            for (int i = 0; i < numberOfNumberOfLesson; i++)
            {
                numberOfLessons.Add(standatrNumberOfLesson);
            }

            //arrange
            //act
            var planOfLessons = new PlanOfLessons.PlanOfLessons(standatrGroup, numberOfLessons);

            //assert
            Assert.AreEqual(standatrGroup, planOfLessons.Group);
            Assert.AreEqual(numberOfLessons, planOfLessons.NumberOfLesson);
        }

        /// <summary>
        /// Проверка метода ToString. Не придумал!!!
        /// </summary>
        /// <param name="nameSubject">Название предмета.</param>
        /// <param name="numberSubject">Количество пар за семестр.</param>
        /// <param name="result">Что должен возвращать.</param>
        [DataTestMethod]
        [DataRow("gr1", 3, "seminar", TypeStudy.EveningClass,new string[] { "Математика", "Физика" }, new int[] { 1, 5 }, "seminar\n    Математика - 1\n    Физика - 5\n")]
        [DataRow("gr121", 4, "Семинар-2", TypeStudy.EveningClass,new string[] { "Математика", "Физика", "Матанализ" }, new int[] { 1, 5,9 }, "Семинар-2\n    Математика - 1\n    Физика - 5\n    Матанализ - 9\n")]
        public void TestToString(string groupName, int groupCours, string groupSeminar, TypeStudy groupTypeStudy,string[] nameSubject, int[] numberSubject,  string result)
        {
            //arrange
            IGroup group = new Group.Group(groupName, groupCours, groupSeminar, groupTypeStudy);
            List<INumberOfLesson> numberOfLessons = new List<INumberOfLesson>();
            for (int i = 0; i < nameSubject.Length; i++)
            {
                ISubject subject = new Subject.Subject(nameSubject[i]);
                INumberOfLesson numberOfLesson = new NumberOfLesson.NumberOfLesson(subject, numberSubject[i]);
                numberOfLessons.Add(numberOfLesson);
            }
            //act
            PlanOfLessons.PlanOfLessons planOfLessons = new PlanOfLessons.PlanOfLessons(group, numberOfLessons);
            //assert
            Assert.AreEqual(result, planOfLessons.ToString());
        }
    }
}
