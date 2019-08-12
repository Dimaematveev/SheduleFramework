using Interface.Interface;
using System;
using System.Collections.Generic;

namespace Sheduler.BL
{
    public class Version1
    {
        List<DateTime> dateTime;
        List<List<int>> numbersLessons;

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

        public void Free()
        {
            dateTime = new List<DateTime>();
            numbersLessons = new List<List<int>>();
            foreach (var dayOfStudies in semester.DaysOfStudies)
            {
                if (dayOfStudies.Study == HowDays.WorkingDay)
                {
                    dateTime.Add(dayOfStudies.Date);
                    List<int> tempNumbersLessons = new List<int>();
                    foreach (var timeLesson in timeLessons)
                    {
                        tempNumbersLessons.Add(timeLesson.NumberLessons);
                    }
                    numbersLessons.Add(tempNumbersLessons);
                }
            }
        }
        //Что можно сделать
        // 1) Создать на каждый день свободные часы
        // 2) Каждому преподавателю поставить свободные часы
        // 3) 

    }
}
