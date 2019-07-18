using System;
using System.Collections.Generic;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGroup
{
    [TestClass]
    public class UnitTestGroup
    {
        [DataTestMethod]
        [DataRow(null, 1,"ss", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentNullException))]
        [DataRow("gr1", 6,"ss", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentException))]
        [DataRow("gr2", 0,"ss", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentException))]
        [DataRow("gr2", 1, null, Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentNullException))]
        [DataRow("gr2", 1, "", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentNullException))]
        [DataRow("gr2", 1, "   ", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentNullException))]
        [DataRow("\n", 1, " wd ", Interface.Interface.TypeStudy.EveningClass, typeof(ArgumentNullException))]
        public void TestConstructorNullListStudentIsException(string name, int cours, string seminar, Interface.Interface.TypeStudy typeStudy,Type exception)
        {
            //arrange
            try
            {
                //act
                var group = new Group.Group(name, cours, seminar, typeStudy);
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(ex.GetType(), exception);
            }
        }
        [DataTestMethod]
        [DataRow("group1", 1, "sem", Interface.Interface.TypeStudy.EveningClass)]
        [DataRow("group1", 2, "sem", Interface.Interface.TypeStudy.FullTimeEducation)]
        [DataRow("2", 5, "TB/d", Interface.Interface.TypeStudy.ExtraMuralStudies)]
        public void TestConstructorNullListStudentIsTruen(string name, int cours, string seminar, Interface.Interface.TypeStudy typeStudy)
        {
            //arrange
            //act
            var group = new Group.Group(name, cours, seminar, typeStudy);
            //assert
         
        }

        [DataTestMethod]
        [DataRow(null,  typeof(ArgumentNullException))]
        [DataRow(0,  typeof(ArgumentNullException))]
        public void TestConstructorWithListStudentIsExceptionGroupNull(int? numberStudents, Type exception)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");

            
            List<IStudent> students;
            if (numberStudents==null)
            {
                students = null;
            }
            else
            {
                students = new List<IStudent>();
                for (int i = 0; i < numberStudents; i++)
                {
                    students.Add(new Student.Student(person));
                }
            }

            
            try
            {
                //act
                var group = new Group.Group(nameGroup, coursGroup, seminarGroup, typeStudyGroup, students);
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(ex.GetType(), exception);
            }
        }
        [DataTestMethod]
        [DataRow(3,1,0)]
        [DataRow(3,3,0)]
        [DataRow(7,0,7)]
        public void TestConstructorWithListStudentGroupAnother(int numberStudents,int numberStudentWithGroup , int result)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");
            var group2 = new Group.Group(nameGroup + "2", coursGroup, seminarGroup + "2", typeStudyGroup);

            List<IStudent> students=new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(new Student.Student(person));
            }
            for (int i = 0; i < numberStudentWithGroup; i++)
            {
                students[i].Group = group2;
            }
            //act
            var group1 = new Group.Group(nameGroup + "1", coursGroup, seminarGroup + "1", typeStudyGroup, students);
            Assert.AreEqual(group1.NumberOfStutents,result);

        }
        [DataTestMethod]
        [DataRow(100)]
        [DataRow(10)]
        public void TestConstructorWithListStudentIsTrueGroupNull(int numberStudents)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");


            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(new Student.Student(person));
            }

            //act
            var group = new Group.Group(nameGroup, coursGroup, seminarGroup, typeStudyGroup, students);
          

        }
        [DataTestMethod]
        [DataRow(100,100)]
        [DataRow(10,10)]
        [DataRow(1,1)]
        public void TestConstructorGetNumberOfStutents(int numberStudents,int result)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");


            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(new Student.Student(person));
            }

            //act
            var group = new Group.Group(nameGroup, coursGroup, seminarGroup, typeStudyGroup, students);
            Assert.AreEqual(group.NumberOfStutents, result);
        }
        [DataTestMethod]
        [DataRow(100, 101)]
        [DataRow(10, 11)]
        [DataRow(1, 2)]
        public void TestConstructorAddOneStudentGroupNull(int numberStudents, int result)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");


            List<IStudent> students = new List<IStudent>();
            for (int i = 0; i < numberStudents; i++)
            {
                students.Add(new Student.Student(person));
            }
            Student.Student student = new Student.Student(person);
            //act
            var group = new Group.Group(nameGroup, coursGroup, seminarGroup, typeStudyGroup, students);
            group.AddStudent(student);
            Assert.AreEqual(group.NumberOfStutents, result);
        }
        [DataTestMethod]
        [DataRow(100,15, 115)]
        [DataRow(10, 30, 40)]
        [DataRow(1, 2 , 3)]
        public void TestConstructorAddListStudentGroupNull(int numberStudents1,int numberStudents2, int result)
        {
            //arrange
            string nameGroup = "NBO";
            int coursGroup = 3;
            string seminarGroup = "NBO-3";
            Interface.Interface.TypeStudy typeStudyGroup = Interface.Interface.TypeStudy.EveningClass;
            Person.Person person = new Person.Person("Dima", new Gender.Gender("Men"), new DateTime(1996, 05, 19), "HZ");


            List<IStudent> students1 = new List<IStudent>();
            for (int i = 0; i < numberStudents1; i++)
            {
                students1.Add(new Student.Student(person));
            }
            List<IStudent> students2 = new List<IStudent>();
            for (int i = 0; i < numberStudents2; i++)
            {
                students2.Add(new Student.Student(person));
            }
            //act
            var group = new Group.Group(nameGroup, coursGroup, seminarGroup, typeStudyGroup, students1);
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
