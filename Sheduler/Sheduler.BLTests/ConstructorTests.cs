using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sheduler.BL.Tests
{
    [TestClass()]
    public class ConstructorTests
    {
        static ISemester semester;
        static List<IGroup> groups;
        static List<IClassRoom> classRooms;
        static List<IPlanOfLessons> planOfLessons;
        static List<ITeacher> teachers;
        static List<ITimeLessons> timeLessons;

        public void Reset()
        {
            semester = A.Fake<ISemester>();
            groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
           classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
           planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
           teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
           timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };
        }
        [TestMethod()]
        public void ConstructorTest_CallConstructorNotException()
        {
            Reset();

            Version1 version1 = new Version1(semester, groups, classRooms, planOfLessons, teachers, timeLessons);


            Assert.AreEqual(semester, version1.semester);
            Assert.AreEqual(groups, version1.groups);
            Assert.AreEqual(classRooms, version1.classRooms);
            Assert.AreEqual(planOfLessons, version1.planOfLessons);
            Assert.AreEqual(teachers, version1.teachers);
            Assert.AreEqual(timeLessons, version1.timeLessons);
        }

        [TestMethod()]
        public void ConstructorTest_SemesterToNULL_CallArgumentNullException()
        {
            Reset();
            semester =null;
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_GroupsToNULL_CallArgumentNullException()
        {
            Reset();
         
            groups = null;
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_GroupsIsEmpty_CallArgumentNullException()
        {
            Reset();
            groups = new List<IGroup>();
            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_ClassRoomsToNULL_CallArgumentNullException()
        {
            Reset();
           
            classRooms = null;
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_ClassRoomsIsEmpty_CallArgumentNullException()
        {
            Reset();
           
            classRooms = new List<IClassRoom>();
            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_PlanOfLessonsToNULL_CallArgumentNullException()
        {
            Reset();
            planOfLessons = null;
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_PlanOfLessonsIsEmpty_CallArgumentNullException()
        {
            Reset();
            planOfLessons = new List<IPlanOfLessons>();
           
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_TeachersToNULL_CallArgumentNullException()
        {
            Reset();
            teachers = null;
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_TeachersIsEmpty_CallArgumentNullException()
        {

            Reset();
            teachers = new List<ITeacher>();
           

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_TimeLessonsToNULL_CallArgumentNullException()
        {
            Reset();
            timeLessons = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
        [TestMethod()]
        public void ConstructorTest_TimeLessonsIsEmpty_CallArgumentNullException()
        {

            Reset();
            timeLessons = new List<ITimeLessons>();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return new Version1(semester,
                                    groups,
                                    classRooms,
                                    planOfLessons,
                                    teachers,
                                    timeLessons);
            });
        }
    }
}