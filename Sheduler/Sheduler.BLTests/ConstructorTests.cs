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
        [TestMethod()]
        public void ConstructorTest_CallConstructorNotException()
        {
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester =null;
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };


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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = null;
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };


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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>();
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = null;
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>();
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = null;
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>();
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };
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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = null;
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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

            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>();
            List<ITimeLessons> timeLessons = new List<ITimeLessons>
            {
                A.Fake<ITimeLessons>()
            };

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
            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = null;
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

            ISemester semester = A.Fake<ISemester>();
            List<IGroup> groups = new List<IGroup>
            {
                A.Fake<IGroup>()
            };
            List<IClassRoom> classRooms = new List<IClassRoom>
            {
                A.Fake<IClassRoom>()
            };
            List<IPlanOfLessons> planOfLessons = new List<IPlanOfLessons>
            {
                A.Fake<IPlanOfLessons>()
            };
            List<ITeacher> teachers = new List<ITeacher>
            {
                A.Fake<ITeacher>()
            };
            List<ITimeLessons> timeLessons = new List<ITimeLessons>();
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