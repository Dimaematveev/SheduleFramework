using Interface.Interface;
using System;
using System.Collections.Generic;

namespace Sheduler.BL
{
    public class Version1
    {
        public List<FreeClassRoom> freeClassrooms;
        public List<FreeTeacher> freeTeachers;
        public List<FreeGroup> freeGroups;


        public ISemester semester;
        public List<IGroup> groups;
        public List<IClassRoom> classRooms;
        public List<IPlanOfLessons> planOfLessons;
        public List<ITeacher> teachers;
        public List<ITimeLessons> timeLessons;

        public Version1(ISemester semester,
                      List<IGroup> groups,
                      List<IClassRoom> classRooms,
                      List<IPlanOfLessons> planOfLessons,
                      List<ITeacher> teachers,
                      List<ITimeLessons> timeLessons)
        {
            this.semester = semester ?? throw new ArgumentNullException(nameof(semester));
            if (groups == null || groups.Count == 0)
            {
                throw new ArgumentNullException(nameof(groups));
            }
            if (classRooms == null || classRooms.Count == 0)
            {
                throw new ArgumentNullException(nameof(classRooms));
            }
            if (planOfLessons == null || planOfLessons.Count == 0)
            {
                throw new ArgumentNullException(nameof(planOfLessons));
            }
            if (teachers == null || teachers.Count == 0)
            {
                throw new ArgumentNullException(nameof(teachers));
            }
            if (timeLessons == null || timeLessons.Count == 0)
            {
                throw new ArgumentNullException(nameof(timeLessons));
            }
            this.groups = groups;
            this.classRooms = classRooms;
            this.planOfLessons = planOfLessons;
            this.teachers = teachers;
            this.timeLessons = timeLessons;
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
                        tempLessons.Add(new Lesson(timeLesson.NumberLessons, null));
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
        public void Distribution()
        {
            //1) Преподаватель выбирается на весь семестр на один предмет
            //2) 
        }

        /// <summary>
        /// Проверяет есть ли группы у которых пар больше чем учебных пар.
        /// </summary>
        /// <returns>Список групп.</returns>
        public List<IGroup> CheckLesson()
        {
            List<IGroup> ret = new List<IGroup>();

            foreach (var freeGroup in freeGroups)
            {
                int freeGr = 0;
                foreach (var free in freeGroup.free)
                {
                    freeGr+=free.Lessons.Count;
                }
                int grBuzy = 0;
                var groupPlanOfLessons = planOfLessons.Find(x => x.Group == freeGroup.group);
                foreach (var plan in groupPlanOfLessons.NumberOfLesson)
                {
                    grBuzy+=plan.NumberSubject;
                }

                if (grBuzy > freeGr)
                {
                    ret.Add(freeGroup.group);
                }
            }
            return ret;
        }
        public class Wee
        {
            public DayOfWeek DayOfWeek;
            public int number;

            public Wee(DayOfWeek dayOfWeek)
            {
                DayOfWeek = dayOfWeek;
                number = 0;
            }
            public void AddNumber(int k)
            {
                number += k;
            }
        }
        public class WeeOfGroup
        {
            IGroup group;
            List<Wee> wees;

            public WeeOfGroup(IGroup group, List<Wee> wees)
            {
                this.group = group ?? throw new ArgumentNullException(nameof(group));
                this.wees = wees ?? throw new ArgumentNullException(nameof(wees));
            }
        }
        /// <summary>
        /// Список количества рабочих дней недели у группы!
        /// </summary>
        /// <returns>Список количества рабочих дней недели у группы</returns>
        public List<WeeOfGroup> NumberWorkDayofWeekFoeGroup()
        {

            List<WeeOfGroup> weeOfGroups = new List<WeeOfGroup>();
            foreach (var freeGroup in freeGroups)
            {
                List<Wee> wees = new List<Wee>();
                for (int i = 0; i < 7; i++)
                {
                    wees.Add(new Wee((DayOfWeek)i));
                }
                foreach (var free in freeGroup.free)
                {
                    wees[(int)free.dateTime.DayOfWeek].number++;
                }
                weeOfGroups.Add(new WeeOfGroup(freeGroup.group, wees));
            }

            return weeOfGroups;
        }

        public class LessonOfWeek
        {
            public ISubject subject;
            public int classesPerWeek;
            public int lessonLeft;

            public LessonOfWeek(ISubject subject, int classesPerWeek, int lessonLeft)
            {
                this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
                this.classesPerWeek = classesPerWeek;
                this.lessonLeft = lessonLeft;
            }
        }
        public class LessonOfWeekToGroup
        {
            public IGroup group;
            public List<LessonOfWeek> lessonOfWeeks;
            public int numberWeek;

            public LessonOfWeekToGroup(IGroup group, List<LessonOfWeek> lessonOfWeeks, int numberWeek)
            {
                this.group = group ?? throw new ArgumentNullException(nameof(group));
                this.lessonOfWeeks = lessonOfWeeks ?? throw new ArgumentNullException(nameof(lessonOfWeeks));
                this.numberWeek = numberWeek;
            }
        }
        /// <summary>
        /// Метод показывает сколько раз в неделю надо пару и сколько в остатке. Переделал на 2 недели.
        /// </summary>
        /// <returns></returns>
        public List<LessonOfWeekToGroup> LessonOfWeekToGroups()
        {
            List<LessonOfWeekToGroup> lessonOfWeekToGroups = new List<LessonOfWeekToGroup>();
            
            foreach (var freeGroup in freeGroups)
            {
                int week = 0;
                List<Wee> wees = new List<Wee>();
                for (int i = 0; i < 7; i++)
                {
                    wees.Add(new Wee((DayOfWeek)i));
                }
                foreach (var free in freeGroup.free)
                {
                    wees[(int)free.dateTime.DayOfWeek].number++;
                }
                for (int i = 1; i <= 5; i++)
                {
                    week += wees[i].number;
                }
                week /= 5;
                //Для четных и нечетных недель
                week /= 2;

                var groupPlanOfLessons = planOfLessons.Find(x => x.Group == freeGroup.group);
                List<LessonOfWeek> lessonOfWeeks = new List<LessonOfWeek>();
                foreach (var plan in groupPlanOfLessons.NumberOfLesson)
                {
                    lessonOfWeeks.Add(new LessonOfWeek(plan.Subject, (plan.NumberSubject / week), (plan.NumberSubject % week)));
                   // grBuzy += plan.NumberSubject;
                }
                lessonOfWeekToGroups.Add(new LessonOfWeekToGroup(freeGroup.group, lessonOfWeeks,week));


            }



            return lessonOfWeekToGroups;
        }
        public void TwoWeek()
        {

        }

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
