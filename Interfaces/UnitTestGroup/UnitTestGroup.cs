using System;
using System.Collections.Generic;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGroup
{
    [TestClass]
    public class UnitTestGroup
    {
        /// <value> стандартные значения и классы с которыми программа БУДЕТ работать  </value>
        static string standatrNameGroup;
        static int standatrCoursGroup;
        static string standatrSeminarGroup;
        static Interface.Interface.TypeStudy standatrTypeStudyGroup;
        private void ResetStandart()
        {
            standatrNameGroup = "NBO";
            standatrCoursGroup = 3;
            standatrSeminarGroup = "NBO-3";
            standatrTypeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
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
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup);

            //assert
            Assert.AreEqual(0,group.NumberOfStutents);
            Assert.AreEqual(standatrNameGroup, group.NameGroup);
            Assert.AreEqual(standatrCoursGroup, group.Cours);
            Assert.AreEqual(standatrSeminarGroup, group.Seminar);
            Assert.AreEqual(standatrTypeStudyGroup, group.TypeOfTraining);

        }

        /// <summary>
        /// Простейший тест конструктора без Студентов. Проверим исключения!
        /// </summary>
        /// <param name="name">Имя группы.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        /// <param name="result">Тип вызываемого исключение. Сверяется с этим!</param>
        [DataTestMethod]
        [DataRow(null, 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("", 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("\t", 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("group1", 6, "Seminar",  typeof(ArgumentException))]
        [DataRow("group1", 0, "Seminar", typeof(ArgumentException))]
        [DataRow("group1", 1, null, typeof(ArgumentNullException))]
        [DataRow("group1", 1, "\n", typeof(ArgumentNullException))]
        public void TestConstructor_NumberStudentsIsNull_Exception(string name, int cours, string seminar, Type result)
        {
            ResetStandart();
            Type exception = null;
            //arrange
            try
            {
                //act
                var group = new Group.Group(name, cours, seminar, standatrTypeStudyGroup);
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
        /// Простейший тест конструктора без Студентов. Проверим что класс будет создан!
        /// </summary>
        /// <param name="name">Имя группы.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        [DataTestMethod]
        [DataRow("group1", 1, "@11")]
        [DataRow("gr1", 2, "11@")]
        [DataRow("@1", 5, "'")]
        public void TestConstructor_NumberStudentsIsNull_True(string name, int cours, string seminar)
        {
            ResetStandart();
            //arrange
            //act
            var group = new Group.Group(name, cours, seminar, standatrTypeStudyGroup);
            //assert
            Assert.AreEqual(0, group.NumberOfStutents);
            Assert.AreEqual(name, group.NameGroup);
            Assert.AreEqual(cours, group.Cours);
            Assert.AreEqual(seminar, group.Seminar);
            Assert.AreEqual(standatrTypeStudyGroup, group.TypeOfTraining);
        }

        /// <summary>
        /// Тест конструктора с не пустыми Студентами. Должно быть исключение!
        /// </summary>
        /// <param name="numberStudents">Количество студентов(=< 0)</param>
        /// <param name="result">Тип исключения. Проверяет это.</param>
        [DataTestMethod]
        [DataRow(0,  typeof(ArgumentNullException))]
        [DataRow(-1,  typeof(ArgumentNullException))]
        public void TestConstructor_NumberStudentsIsNotNull_Exception(int numberStudents, Type result)
        {
            ResetStandart();
            Type exception = null;
            //arrange
            try
            {
                //act
                var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, numberStudents);
            }
            catch (Exception ex)
            {
                
                exception = ex.GetType();
            }
            finally
            {
                //assert
                Assert.AreEqual(result, exception);
            }
            
        }
        /// <summary>
        /// Тест конструктора с не пустыми студентами.
        /// </summary>
        /// <param name="numberStudents">Сколько студентов в группе.</param>
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(100)]
        public void TestConstructor_NumberStudentsIsNotNull_True(int numberStudents)
        {
            ResetStandart();
            //arrange
            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, numberStudents);
            Assert.AreEqual(numberStudents, group.NumberOfStutents);
            Assert.AreEqual(standatrNameGroup, group.NameGroup);
            Assert.AreEqual(standatrCoursGroup, group.Cours);
            Assert.AreEqual(standatrSeminarGroup, group.Seminar);
            Assert.AreEqual(standatrTypeStudyGroup, group.TypeOfTraining);

        }

        /// <summary>
        /// Метод Addstudent Добавляем к студентам, еще студентов.
        /// </summary>
        /// <param name="numberStudents">Количество студентов(=< 0)</param>
        /// <param name="result">Тип исключения. Проверяет это.</param>
        [DataTestMethod]
        [DataRow(0, typeof(ArgumentNullException))]
        [DataRow(-1, typeof(ArgumentNullException))]
        public void TestAddStudent_NumberStudentsIsNull_Exception(int numberStudents, Type result)
        {
            ResetStandart();
            Type exception = null;
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup);
            //arrange
            try
            {
                //act
                group.AddStudent(numberStudents);
            }
            catch (Exception ex)
            {
                exception = ex.GetType();
            }
            finally
            {
                //assert
                Assert.AreEqual(result, exception);
                Assert.AreEqual(0, group.NumberOfStutents);
                Assert.AreEqual(standatrNameGroup, group.NameGroup);
                Assert.AreEqual(standatrCoursGroup, group.Cours);
                Assert.AreEqual(standatrSeminarGroup, group.Seminar);
                Assert.AreEqual(standatrTypeStudyGroup, group.TypeOfTraining);
            }

        }
        /// <summary>
        /// Метод Addstudent Добавляем к студентам, еще студентов.
        /// </summary>
        /// <param name="numberStudents1">количество студентов было.</param>
        /// <param name="numberStudents2">Количество добавленных.</param>
        /// <param name="result">Сколько должно стать.</param>
        [DataTestMethod]
        [DataRow(100,15, 115)]
        [DataRow(10, 30, 40)]
        [DataRow(1, 2 , 3)]
        public void TestAddStudent_NumberStudentsIsNotNull_True(int numberStudents1,int numberStudents2, int result)
        {
            ResetStandart();
            //arrange

            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, numberStudents1);

            //act
            group.AddStudent(numberStudents2);
            Assert.AreEqual( result, group.NumberOfStutents);
            Assert.AreEqual(standatrNameGroup, group.NameGroup);
            Assert.AreEqual(standatrCoursGroup, group.Cours);
            Assert.AreEqual(standatrSeminarGroup, group.Seminar);
            Assert.AreEqual(standatrTypeStudyGroup, group.TypeOfTraining);
        }
        /// <summary>
        /// Проверка метода ToString
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        /// <param name="typeStudy">Тип обучения.</param>
        /// <param name="toString">Что должно получиться.</param>
        [DataTestMethod]
        [DataRow("group1", 1, "sem", Interface.Interface.TypeStudy.EveningClass, "sem")]
        [DataRow("group1", 2, "sem", Interface.Interface.TypeStudy.FullTimeEducation, "sem")]
        [DataRow("2", 5, "TB/d", Interface.Interface.TypeStudy.ExtraMuralStudies, "TB/d")]
        public void TestToString(string name, int cours, string seminar, Interface.Interface.TypeStudy typeStudy,string toString)
        {

            //arrange
            var group = new Group.Group(name, cours, seminar, typeStudy);
            //act
            var str = group.ToString();
            //assert
            Assert.AreEqual(str, toString);


        }
    }
}
