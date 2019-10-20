using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.WPF.BL
{
    public class GetDataFromBD
    {
        public static void RepositoryBase()
        {
            WorkToMyDbContext.RepositoryBase();
        }
        public Classroom[] classrooms;
        public Group[] groups;
        public Subject[] subjects;
        public Curriculum[] curricula;
        public Pair[] pairs;
        public StudyDay[] studyDays;
        public void ReadDB()
        {
            WorkToMyDbContext.ReadDB();
            classrooms = WorkToMyDbContext.classrooms;
            groups = WorkToMyDbContext.groups;
            subjects = WorkToMyDbContext.subjects;
            curricula = WorkToMyDbContext.curricula;
            pairs = WorkToMyDbContext.pairs;
            studyDays = WorkToMyDbContext.studyDays;

        }

       
    }
}
