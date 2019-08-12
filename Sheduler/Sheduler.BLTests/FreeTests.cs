using FakeItEasy;
using Interface.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheduler.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheduler.BL.Tests
{
    [TestClass()]
    public class FreeTests
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
        public void FreeTest_HZ()
        {
            Reset();

            
            List<IDaysOfStudy> daysOfStudies = new List<IDaysOfStudy>();
            for (int i = 0; i < 10; i++)
            {
                var temp = A.Fake<IDaysOfStudy>();
                temp.Date = DateTime.Now.Date.AddDays(i);
                temp.Study = HowDays.WorkingDay;
                daysOfStudies.Add(temp);
            }
            List<ITimeLessons> timeLessons = new List<ITimeLessons>();
            for (int i = 0; i < 6; i++)
            {
                var temp = A.Fake<ITimeLessons>();
                temp.NumberLessons =i+1;
                timeLessons.Add(temp);
            }
            
            ISemester semester = A.Fake<ISemester>();
            semester.DaysOfStudies= daysOfStudies.ToArray();
            Version1 version1 = new Version1(semester, groups, classRooms, planOfLessons, teachers, timeLessons);



            var frees = version1.Free();
            int ind1 = 0;
            foreach (var free in frees)
            {
                Assert.AreEqual(daysOfStudies[ind1++].Date.Date, free.dateTime);
                int ind2 = 0;
                foreach (var lesson in free.Lessons)
                {
                    Assert.AreEqual(timeLessons[ind2++].NumberLessons, lesson.numberLesson);
                    Assert.AreEqual(null, lesson.infoLesson);
                }
            }

        }
    }
}