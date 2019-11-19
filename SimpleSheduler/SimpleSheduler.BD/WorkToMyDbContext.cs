using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using SimpleSheduler.BD.Model;

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
        public static List<TypeUnionGroup> typeUnionGroups;
        public static List<TypeOfClasses> typeOfClasses;
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
                typeUnionGroups = context.TypeUnionGroups.ToList();
                typeOfClasses = context.TypeOfClasses.ToList();
            }
        }

        public static void AddNewBD()
        {
            InitialFilling.FillingAll();
            InitialFilling.FillingCurriculum();
        }


        private static void SaveDBALL()
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.AddOrUpdate(classrooms.ToArray());
                context.Groups.AddOrUpdate(groups.ToArray());
                context.Subjects.AddOrUpdate(subjects.ToArray());
                context.Curricula.AddOrUpdate(curricula.ToArray());
                context.Pairs.AddOrUpdate(pairs.ToArray());
                
                context.StudyDays.AddOrUpdate(studyDays.ToArray());
                context.TypeOfClasses.AddOrUpdate(typeOfClasses.ToArray());
                context.SaveChanges();
            }
        }

        public static void SaveDB(string sNamespace="ALL")
        {
            if (typeof(Classroom).FullName == sNamespace) 
            {
                SaveDBClassroom();
                return;
            }
            if (typeof(Group).FullName == sNamespace)
            {
                SaveDBGroup();
                return;
            }
            if (typeof(Curriculum).FullName == sNamespace)
            {
                SaveDBCurriculum();
                return;
            }
            if (typeof(Pair).FullName == sNamespace)
            {
                SaveDBPair();
                return;
            }
            if (typeof(StudyDay).FullName == sNamespace)
            {
                SaveDBStudyDay();
                return;
            }
            if (typeof(Subject).FullName == sNamespace)
            {
                SaveDBSubject();
                return;
            }
            if (typeof(TypeOfClasses).FullName == sNamespace)
            {
                SaveDBTypeOfClasses();
                return;
            }
            if ("ALL" == sNamespace)
            {
                SaveDBALL();
                return;
            }
            throw new ArgumentException($"Нет такой таблицы {sNamespace}");
        }

        private static void SaveDBClassroom()
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.AddOrUpdate(classrooms.ToArray());
                context.SaveChanges();
            }
        }
        private static void SaveDBTypeOfClasses()
        {
            using (var context = new MyDbContext())
            {
                context.TypeOfClasses.AddOrUpdate(typeOfClasses.ToArray());
                context.SaveChanges();
            }
        }

        private static void SaveDBGroup()
        {
            using (var context = new MyDbContext())
            {

                context.Groups.AddOrUpdate(groups.ToArray());
                context.SaveChanges();
            }
        }


        private static void SaveDBSubject()
        {
            using (var context = new MyDbContext())
            {

                context.Subjects.AddOrUpdate(subjects.ToArray());

                context.SaveChanges();
            }
        }


        private static void SaveDBCurriculum()
        {
            using (var context = new MyDbContext())
            {
               
                context.Curricula.AddOrUpdate(curricula.ToArray());
               
                context.SaveChanges();
            }
        }


        private static void SaveDBPair()
        {
            using (var context = new MyDbContext())
            {
                context.Pairs.AddOrUpdate(pairs.ToArray());

                context.SaveChanges();
            }
        }


        private static void SaveDBStudyDay()
        {
            using (var context = new MyDbContext())
            {
                context.StudyDays.AddOrUpdate(studyDays.ToArray());
                context.SaveChanges();
            }
        }

    }
}
