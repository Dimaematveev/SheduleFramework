using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

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
        public static List<Classroom> classrooms;
        public static List<Group> groups;
        public static List<Subject> subjects;
        public static List<Curriculum> curricula;
        public static List<Pair> pairs;
        public static List<StudyDay> studyDays;
        public static void ReadDB()
        {
            using (var context = new MyDbContext())
            {
                classrooms = context.Classrooms.ToList();
                groups = context.Groups.ToList();
                subjects = context.Subjects.ToList();
                // var teachers = context.Teachers.ToArray();
                curricula = context.Curricula.ToList();
                // var subjectOfTeachers = context.SubjectsOfTeachers.ToArray();
                pairs = context.Pairs.ToList();
                studyDays = context.StudyDays.ToList();
            }
        }

        public static void AddNewBD()
        {
            InitialFilling.FillingAll();
            InitialFilling.FillingCurriculum();
        }


        public static void SaveDB()
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.AddOrUpdate(classrooms.ToArray());
                context.Groups.AddOrUpdate(groups.ToArray());
                context.Subjects.AddOrUpdate(subjects.ToArray());
                context.Curricula.AddOrUpdate(curricula.ToArray());
                context.Pairs.AddOrUpdate(pairs.ToArray());
                context.StudyDays.AddOrUpdate(studyDays.ToArray());
                context.SaveChanges();
            }
        }
    }
}
