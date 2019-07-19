﻿using System;
using System.Collections.Generic;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGroup
{
    [TestClass]
    public class UnitTestGroup
    {
        static string standatrNameGroup = "NBO";
        static int standatrCoursGroup = 3;
        static string standatrSeminarGroup = "NBO-3";
        static Interface.Interface.TypeStudy standatrTypeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
        static List<Person.Person> standatrPersons = new List<Person.Person>
        {
            new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "none"),
            new Person.Person("Ira", new Gender.Gender("Women"), new DateTime(1995, 02, 21), "none"),
            new Person.Person("Vova", new Gender.Gender("Men"), new DateTime(1982, 09, 11), "none"),
            new Person.Person("Ivan", new Gender.Gender("Men"), new DateTime(1990, 4, 14), "none"),
            new Person.Person("Roma", new Gender.Gender("Men"), new DateTime(2015, 12, 22), "none"),
        };
        static List<Student.Student> standatrStudents = new List<Student.Student>
        {
            new Student.Student(standatrPersons[0]),
            new Student.Student(standatrPersons[1]),
            new Student.Student(standatrPersons[2]),
            new Student.Student(standatrPersons[3]),
            new Student.Student(standatrPersons[4])
        };

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
            //arrange
            Random rnd = new Random();
            List<IStudent> students;
            if (numberStudents==null)
            {
                students = null;
            }
            else
            {
                students = new List<IStudent>();
            }
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
        /// Тест конструктора с не пустыми студентами. Должно быть исключение!
        /// </summary>
        /// <param name="numberStudents"></param>
        /// <param name="numberStudentWithGroup"></param>
        /// <param name="result"></param>
        [DataTestMethod]
        [DataRow(3,1,0)]
        [DataRow(3,3,0)]
        [DataRow(7,0,7)]
        public void TestConstructorWithListStudentGroupAnother(int numberStudents,int numberStudentWithGroup , int result)
        {
            //arrange
            var group2 = new Group.Group(standatrNameGroup + "2", standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup);
            Random rnd = new Random();
            List<IStudent> students=new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }
            for (int i = 0; i < numberStudentWithGroup; i++)
            {
                students[i].Group = group2;
            }
            //act
            var group1 = new Group.Group(standatrNameGroup + "1", standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            Assert.AreEqual(group1.NumberOfStutents,result);

        }
        [DataTestMethod]
        [DataRow(100)]
        [DataRow(10)]
        public void TestConstructorWithListStudentIsTrueGroupNull(int numberStudents)
        {
            //arrange
            Random rnd = new Random();
            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }

            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
        }
        [DataTestMethod]
        [DataRow(100,100)]
        [DataRow(10,10)]
        [DataRow(1,1)]
        public void TestConstructorGetNumberOfStutents(int numberStudents,int result)
        {
            //arrange
            Random rnd = new Random();
            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }

            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            Assert.AreEqual(group.NumberOfStutents, result);
        }
        [DataTestMethod]
        [DataRow(100, 101)]
        [DataRow(10, 11)]
        [DataRow(1, 2)]
        public void TestConstructorAddOneStudentGroupNull(int numberStudents, int result)
        {
            //arrange
            Random rnd = new Random();
            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }
            Student.Student student = new Student.Student(standatrPersons[rnd.Next(0, standatrPersons.Count)]);
            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students);
            group.AddStudent(student);
            //assert
            Assert.AreEqual(group.NumberOfStutents, result);
        }
        [DataTestMethod]
        [DataRow(100,15, 115)]
        [DataRow(10, 30, 40)]
        [DataRow(1, 2 , 3)]
        public void TestConstructorAddListStudentGroupNull(int numberStudents1,int numberStudents2, int result)
        {
            //arrange

            Random rnd = new Random();
            List<IStudent> students1 = new List<IStudent>();
            for (int i = 0; i < numberStudents1; i++)
            {
                students1.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }
            List<IStudent> students2 = new List<IStudent>();
            for (int i = 0; i < numberStudents2; i++)
            {
                students2.Add(standatrStudents[rnd.Next(0, standatrStudents.Count)]);
            }
            //act
            var group = new Group.Group(standatrNameGroup, standatrCoursGroup, standatrSeminarGroup, standatrTypeStudyGroup, students1);
            group.AddStudent(students2);
            Assert.AreEqual(group.NumberOfStutents, result);
        }
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
