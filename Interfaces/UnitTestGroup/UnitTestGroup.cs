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
        static Group.Group standatrGroup1;
        static Group.Group standatrGroup2;
        private void ResetStandart()
        {
            standatrNameGroup = "NBO";
            standatrCoursGroup = 3;
            standatrSeminarGroup = "NBO-3";
            standatrTypeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            standatrGroup1 = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup);
            standatrGroup2 = new Group.Group(standatrNameGroup + "2", standatrCoursGroup, standatrSeminarGroup + "2", standatrTypeStudyGroup);
        }

        /// <summary>
        /// Простейший тест конструктора без Студентов. Проверим исключения!
        /// </summary>
        /// <param name="name">Имя группы.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        /// <param name="exception">Тип вызываемого исключение. Сверяется с этим!</param>
        [DataTestMethod]
        [DataRow(null, 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("", 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("\t", 1,"Seminar",  typeof(ArgumentNullException))]
        [DataRow("group1", 6, "Seminar",  typeof(ArgumentException))]
        [DataRow("group1", 0, "Seminar", typeof(ArgumentException))]
        [DataRow("group1", 1, null, typeof(ArgumentNullException))]
        [DataRow("group1", 1, "\n", typeof(ArgumentNullException))]
        public void TestConstructorNullListStudentIsException(string name, int cours, string seminar, Type exception)
        {
            ResetStandart();
            //arrange
            try
            {
                //act
                var group = new Group.Group(name, cours, seminar, standatrTypeStudyGroup);
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(ex.GetType(), exception);
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
        public void TestConstructorNullListStudentIsTrue(string name, int cours, string seminar)
        {
            ResetStandart();
            //arrange
            //act
            var group = new Group.Group(name, cours, seminar, standatrTypeStudyGroup);
            //assert
        }

        /// <summary>
        /// Тест конструктора с пустыми Студентами. Должно быть исключение!
        /// </summary>
        /// <param name="numberStudents">Количество студентов(либо null,либо 0)</param>
        /// <param name="exception">Тип исключения. Проверяет это.</param>
        [DataTestMethod]
        [DataRow(null,  typeof(ArgumentNullException))]
        [DataRow(0,  typeof(ArgumentNullException))]
        public void TestConstructorWithListStudentIsExceptionGroupNull(int? numberStudents, Type exception)
        {
            ResetStandart();
            //arrange
            Random rnd = new Random();
            
            try
            {
                //act
                var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(ex.GetType(), exception);
            }
        }
        /// <summary>
        /// Тест конструктора с не пустыми студентами. Если есть хоть один не с нашей или пустой группой, то будет ноль студентов!
        /// </summary>
        /// <param name="numberStudents">Сколько студентов добавляется.</param>
        /// <param name="numberStudentWithGroup">Сколько из них из другой группы.</param>
        /// <param name="result">Сколько добавится.</param>
        [DataTestMethod]
        [DataRow(3,1,0)]
        [DataRow(3,3,0)]
        [DataRow(7,0,7)]
        public void TestConstructorWithListStudentGroupAnother(int numberStudents,int numberStudentWithGroup , int result)
        {
            ResetStandart();
            if (numberStudentWithGroup> numberStudents)
            {
                numberStudentWithGroup = numberStudents;
            }
            //arrange
            Random rnd = new Random();
            List<IStudent> students=new List<IStudent>();
            for (int i = 0; i < numberStudents- numberStudentWithGroup; i++)
            {
                students.Add(standatrStudents0[rnd.Next(0, standatrStudents0.Count)]);
            }
            for (int i = 0; i < numberStudentWithGroup; i++)
            {
                students.Add(standatrStudents2[rnd.Next(0, standatrStudents2.Count)]);
            }
            //act
            var group1 = new Group.Group(standatrNameGroup + "1", standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            Assert.AreEqual(group1.NumberOfStutents,result);
           
        }
        /// <summary>
        /// Тест конструктора с не пустыми студентами.Студенты из нашей группы или пустой.
        /// </summary>
        /// <param name="numberStudents">Количество студентов.</param>
        [DataTestMethod]
        [DataRow(100)]
        [DataRow(10)]
        public void TestConstructorWithListStudentIsTrueGroupNull(int numberStudents)
        {
            ResetStandart();
            //arrange
            Random rnd = new Random();
            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(standatrStudents0[rnd.Next(0, standatrStudents0.Count)]);
            }

            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            Assert.AreEqual(numberStudents, group.NumberOfStutents);
            
        }
        /// <summary>
        /// Тест свойства Get NumberOfStutents.
        /// </summary>
        /// <param name="numberStudents">количество студентов.</param>
        /// <param name="numberStudentWithGroup">Сколько из них из другой группы.</param>
        /// <param name="result">Что должен вернуть Get.</param>
        [DataTestMethod]
        [DataRow(100,15,85)]
        [DataRow(10,5,5)]
        [DataRow(1,1,0)]
        public void TestConstructorGetNumberOfStutents(int numberStudents, int numberStudentWithGroup, int result)
        {
            ResetStandart();
            //arrange
            Random rnd = new Random();
            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents- numberStudentWithGroup; i++)
            {
                Student.Student student = standatrStudents1[rnd.Next(0, standatrStudents1.Count)];
                standatrGroup1.AddStudent(student);
            }
            for (int i = 0; i <  numberStudentWithGroup; i++)
            {
                Student.Student student = standatrStudents2[rnd.Next(0, standatrStudents2.Count)];
                standatrGroup1.AddStudent(student);
            }
            //act
            Assert.AreEqual(result,standatrGroup1.NumberOfStutents);
           
        }
        /// <summary>
        /// Метод Addstudent Добавляем к списку студентов, другой список.
        /// </summary>
        /// <param name="numberStudents1">количество студентов в первой партии.</param>
        /// <param name="numberStudents2">количество студентов во второй партии.</param>
        /// <param name="result">Что должен вернуть.</param>
        [DataTestMethod]
        [DataRow(100,15, 115)]
        [DataRow(10, 30, 40)]
        [DataRow(1, 2 , 3)]
        public void TestConstructorAddListStudentGroupNull(int numberStudents1,int numberStudents2, int result)
        {
            ResetStandart();
            //arrange

            Random rnd = new Random();
            List<IStudent> students1 = new List<IStudent>();
            for (int i = 0; i < numberStudents1; i++)
            {
                students1.Add(standatrStudents1[rnd.Next(0, standatrStudents1.Count)]);
            }
            List<IStudent> students2 = new List<IStudent>();
            for (int i = 0; i < numberStudents2; i++)
            {
                students2.Add(standatrStudents1[rnd.Next(0, standatrStudents1.Count)]);
            }
            //act
            standatrGroup1.AddStudent(students1);
            standatrGroup1.AddStudent(students2);
            Assert.AreEqual( result, standatrGroup1.NumberOfStutents);
       
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
