using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SimpleSheduler.BD
{
    public static class WorkToMyDbContext
    { 

        public static void RepositoryBase()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }
        public static Classroom[] classrooms;
        public static Group[] groups;
        public static Subject[] subjects;
        public static Curriculum[] curricula;
        public static Pair[] pairs;
        public static StudyDay[] studyDays;
        public static void ReadDB()
        {
            using (var context = new MyDbContext())
            {
                classrooms = context.Classrooms.ToArray();
                groups = context.Groups.ToArray();
                subjects = context.Subjects.ToArray();
                // var teachers = context.Teachers.ToArray();
                curricula = context.Curricula.ToArray();
                // var subjectOfTeachers = context.SubjectsOfTeachers.ToArray();
                pairs = context.Pairs.ToArray();
                studyDays = context.StudyDays.ToArray();
            }
        }

        public static void AddNewBD()
        {
            InitialFilling.FillingAll();
            InitialFilling.FillingCurriculum();
        }
    }
}
