using Interface.Interface;
using System;
using System.Collections.Generic;

namespace Sheduler.BL
{
    public class Version1
    {
        List<FreeClassRoom> freeClassrooms;
        List<FreeTeacher> freeTeachers;


        ISemester semester;
        List<IGroup> groups;
        List<IClassRoom> classRooms;
        List<IPlanOfLessons> planOfLessons;
        List<ITeacher> teachers;
        List<ITimeLessons> timeLessons;

        public Version1(ISemester semester,
                      List<IGroup> groups,
                      List<IClassRoom> classRooms,
                      List<IPlanOfLessons> planOfLessons,
                      List<ITeacher> teachers,
                      List<ITimeLessons> timeLessons)
        {
            this.semester = semester ?? throw new ArgumentNullException(nameof(semester));
            this.groups = groups ?? throw new ArgumentNullException(nameof(groups));
            this.classRooms = classRooms ?? throw new ArgumentNullException(nameof(classRooms));
            this.planOfLessons = planOfLessons ?? throw new ArgumentNullException(nameof(planOfLessons));
            this.teachers = teachers ?? throw new ArgumentNullException(nameof(teachers));
            this.timeLessons = timeLessons ?? throw new ArgumentNullException(nameof(timeLessons));
        }

        public List<Free> Free()
        {
            List<Free> free = new List<Free>();
            foreach (var dayOfStudies in semester.DaysOfStudies)
            {
                if (dayOfStudies.Study == HowDays.WorkingDay)
                {
                    List<int> tempNumbersLessons = new List<int>();
                    foreach (var timeLesson in timeLessons)
                    {
                        tempNumbersLessons.Add(timeLesson.NumberLessons);
                    }
                    free.Add(new Free(dayOfStudies.Date.Date, tempNumbersLessons));
                }
            }
            return free;
        }

        public void FreeClassRoom()
        {
            freeClassrooms = new List<FreeClassRoom>();
            foreach (var classRoom in classRooms)
            {
                freeClassrooms.Add(new FreeClassRoom(Free(), classRoom));
            }
        }
        public void FreeTeacher()
        {
            freeTeachers = new List<FreeTeacher>();
            foreach (var teacher in teachers)
            {
                freeTeachers.Add(new FreeTeacher(Free(), teacher));
            }
        }
        public void SetFree()
        {
            FreeClassRoom();
            FreeTeacher();
        }
        //Что можно сделать
        // 1) Создать на каждый день свободные часы
        // 2) Каждому преподавателю поставить свободные часы
        // 3) 

    }

    public class Free
    {
        public DateTime dateTime;
        public List<int> numberLessons;

        public Free(DateTime dateTime, List<int> numberLessons)
        {
            this.dateTime = dateTime;
            this.numberLessons = numberLessons ?? throw new ArgumentNullException(nameof(numberLessons));
        }
    }
    public class FreeClassRoom
    {
        public List<Free> free;
        public IClassRoom classRoom;

        public FreeClassRoom(List<Free> free, IClassRoom classRoom)
        {
            this.free = free ?? throw new ArgumentNullException(nameof(free));
            this.classRoom = classRoom ?? throw new ArgumentNullException(nameof(classRoom));
        }
    }
    public class FreeTeacher
    {
        public List<Free> free;
        public ITeacher teacher;

        public FreeTeacher(List<Free> free, ITeacher teacher)
        {
            this.free = free ?? throw new ArgumentNullException(nameof(free));
            this.teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
        }
    }
}
