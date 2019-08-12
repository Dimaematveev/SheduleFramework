using Interface.Interface;
using System;
using System.Collections.Generic;

namespace Sheduler.BL
{
    public class Version1
    {
        List<FreeClassRoom> freeClassrooms;
        List<FreeTeacher> freeTeachers;
        List<FreeGroup> freeGroups;


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
        /// <summary>
        /// День и список пар когда свободно.
        /// </summary>
        /// <returns></returns>
        public List<Free> Free()
        {
            List<Free> free = new List<Free>();
            foreach (var dayOfStudies in semester.DaysOfStudies)
            {
                if (dayOfStudies.Study == HowDays.WorkingDay)
                {
                    List<Lesson> tempLessons = new List<Lesson>();
                    foreach (var timeLesson in timeLessons)
                    {
                        tempLessons.Add(new Lesson(timeLesson.NumberLessons,null));
                    }
                    free.Add(new Free(dayOfStudies.Date.Date, tempLessons));
                }
            }
            return free;
        }

        /// <summary>
        /// Когда свободна аудитория
        /// </summary>
        public void FreeClassRoom()
        {
            freeClassrooms = new List<FreeClassRoom>();
            foreach (var classRoom in classRooms)
            {
                freeClassrooms.Add(new FreeClassRoom(Free(), classRoom));
            }
        }

       /// <summary>
       /// когда свободен преподаватель.
       /// </summary>
        public void FreeTeacher()
        {
            freeTeachers = new List<FreeTeacher>();
            foreach (var teacher in teachers)
            {
                freeTeachers.Add(new FreeTeacher(Free(), teacher));
            }
        }
        /// <summary>
        /// когда свободна группа.
        /// </summary>
        public void FreeGroup()
        {
            freeGroups = new List<FreeGroup>();
            foreach (var group in groups)
            {
                freeGroups.Add(new FreeGroup(Free(), group));
            }
        }
        public void SetFree()
        {
            FreeClassRoom();
            FreeTeacher();
            FreeGroup();
        }
        //Что можно сделать
        // 1) Создать на каждый день свободные часы
        // 2) Каждому преподавателю поставить свободные часы
        // 3) 

    }
    /// <summary>
    /// О паре кто ведет, какая группа и какой предмет
    /// </summary>
    public class InfoLesson
    {
        ITeacher teacher;
        ISubject subject;
        IGroup group;

        public InfoLesson(ITeacher teacher, ISubject subject, IGroup group)
        {
            this.teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.group = group ?? throw new ArgumentNullException(nameof(group));
        }
    }
    /// <summary>
    /// Есть ли пара на этот номер пары
    /// </summary>
    public class Lesson
    {
        public int numberLesson;
        public InfoLesson infoLesson;

        public Lesson(int numberLesson, InfoLesson infoLesson)
        {
            this.numberLesson = numberLesson;
            this.infoLesson = infoLesson;
        }
    }
    public class Free
    {
        public DateTime dateTime;
        public List<Lesson> Lessons;

        public Free(DateTime dateTime, List<Lesson> Lessons)
        {
            this.dateTime = dateTime;
            this.Lessons = Lessons ?? throw new ArgumentNullException(nameof(Lessons));
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
    public class FreeGroup
    {
        public List<Free> free;
        public IGroup group;

        public FreeGroup(List<Free> free, IGroup group)
        {
            this.free = free ?? throw new ArgumentNullException(nameof(free));
            this.group = group ?? throw new ArgumentNullException(nameof(group));
        }
    }
}
