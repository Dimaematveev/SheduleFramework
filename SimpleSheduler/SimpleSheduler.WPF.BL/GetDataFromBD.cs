using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SimpleSheduler.WPF.BL
{
    public class GetDataFromBD
    {
        public static void RepositoryBase()
        {
            WorkToMyDbContext.RepositoryBase();
        }
        public List<Classroom> classrooms;
        public List<Group> groups;
        public List<Subject> subjects;
        public List<Curriculum> curricula;
        public List<Pair> pairs;
        public List<StudyDay> studyDays;
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

        public DataGrid GetDateGridBD(string sNamespase)
        {
            DataGrid dataGrid = new DataGrid();
            if (sNamespase == typeof(Subject).FullName)
            {
                dataGrid.ItemsSource = subjects;
            }
            if (sNamespase == typeof(Classroom).FullName)
            {
                dataGrid.ItemsSource = classrooms;
            }
            if (sNamespase == typeof(Curriculum).FullName)
            {
                dataGrid.ItemsSource = curricula;
            }
            if (sNamespase == typeof(Pair).FullName)
            {
                dataGrid.ItemsSource = pairs;
            }
            if (sNamespase == typeof(StudyDay).FullName)
            {
                dataGrid.ItemsSource = studyDays;
            }
            if (sNamespase == typeof(Group).FullName)
            {
                dataGrid.ItemsSource = groups;
            }

            return dataGrid;
        }

        public MyDataGridProperty GetDateGridPropertyBD(string sNamespase)
        {
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty();
            if (sNamespase == typeof(Subject).FullName)
            {
                myDataGridProperty = GetDateGridPropertyBDSubject();
            }
            if (sNamespase == typeof(Classroom).FullName)
            {
                myDataGridProperty= GetDateGridPropertyBDClassroom();
            }
            if (sNamespase == typeof(Curriculum).FullName)
            {
                myDataGridProperty= GetDateGridPropertyBDCurriculum();
            }
            if (sNamespase == typeof(Pair).FullName)
            {
                myDataGridProperty= GetDateGridPropertyBDPair();
            }
            if (sNamespase == typeof(StudyDay).FullName)
            {
                myDataGridProperty= GetDateGridPropertyBDStudyDay();
            }
            if (sNamespase == typeof(Group).FullName)
            {
                myDataGridProperty= GetDateGridPropertyBDGroup();
            }

            return myDataGridProperty;
        }



        private MyDataGridProperty GetDateGridPropertyBDCurriculum()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(Curriculum.CurriculumId),"ID плана",Visibility.Visible,true),
                new MyColumnProperty(nameof(Curriculum.GroupId),"ID группы",Visibility.Hidden,false,groups ),
                new MyColumnProperty(nameof(Curriculum.SubjectId),"ID предмета",Visibility.Visible,false),
                new MyColumnProperty(nameof(Curriculum.NumberOfLectures),"Кол-во лекций",Visibility.Visible,false),
                new MyColumnProperty(nameof(Curriculum.NumberOfPractical),"Кол-во практических",Visibility.Visible,false),
                new MyColumnProperty(nameof(Curriculum.NumberOfLaboratory),"Кол-во лабораторных",Visibility.Visible,false),
                new MyColumnProperty(nameof(Curriculum.Group),"Группа",Visibility.Visible,false),
                new MyColumnProperty(nameof(Curriculum.Subject),"Предмет",Visibility.Visible,false,subjects ),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(Curriculum).FullName, "План");
            return myDataGridProperty;
        }



        private MyDataGridProperty GetDateGridPropertyBDSubject()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(Subject.SubjectId),"ID предмета",Visibility.Visible,true),
                new MyColumnProperty(nameof(Subject.Name),"Название предмета",Visibility.Visible,false),
                new MyColumnProperty(nameof(Subject.FullName),"Полное название предмета",Visibility.Visible,false),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(Subject).FullName, "Предметы");
            return myDataGridProperty;
        }

        private MyDataGridProperty GetDateGridPropertyBDClassroom()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(Classroom.ClassroomId),"ID Аудитории",Visibility.Visible,true),
                new MyColumnProperty(nameof(Classroom.Name),"Название Аудитории",Visibility.Visible,false),
                new MyColumnProperty(nameof(Classroom.FullName),"Полное название Аудитории",Visibility.Visible,false),
                new MyColumnProperty(nameof(Classroom.NumberOfSeats),"Кол-во мест",Visibility.Visible,false),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(Classroom).FullName, "Аудитории");
            return myDataGridProperty;
        }
        private MyDataGridProperty GetDateGridPropertyBDGroup()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(Group.GroupId),"ID Группы",Visibility.Visible,true),
                new MyColumnProperty(nameof(Group.Name),"Название группы",Visibility.Visible,false),
                new MyColumnProperty(nameof(Group.FullName),"Полное название Аудитории",Visibility.Visible,false),
                new MyColumnProperty(nameof(Group.NumberOfPersons),"Количество человек в группе",Visibility.Visible,false),
                new MyColumnProperty(nameof(Group.Seminar),"Семинар",Visibility.Visible,false),
                new MyColumnProperty(nameof(Group.Potok),"Поток",Visibility.Visible,false),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(Group).FullName, "Группы");
            return myDataGridProperty;
        }
        private MyDataGridProperty GetDateGridPropertyBDPair()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(Pair.PairId),"ID пары",Visibility.Visible,true),
                new MyColumnProperty(nameof(Pair.NameThePair),"Название пары",Visibility.Visible,false),
                new MyColumnProperty(nameof(Pair.NumberThePair),"Номер пары",Visibility.Visible,false),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(Pair).FullName, "Пары");
            return myDataGridProperty;
        }
        private MyDataGridProperty GetDateGridPropertyBDStudyDay()
        {
            List<MyColumnProperty> myColumnProperties = new List<MyColumnProperty>
            {
                new MyColumnProperty(nameof(StudyDay.StudyDayId),"ID учебного дня",Visibility.Visible,true),
                new MyColumnProperty(nameof(StudyDay.NumberOfWeek),"Номер недели",Visibility.Visible,false),
                new MyColumnProperty(nameof(StudyDay.NumberDayOfWeek),"Номер дня недели",Visibility.Visible,false),
                new MyColumnProperty(nameof(StudyDay.NameDayOfWeek),"День недели",Visibility.Visible,false),
                new MyColumnProperty(nameof(StudyDay.FullNameDayOfWeek),"Полное название дня недели",Visibility.Visible,false),
            };
            MyDataGridProperty myDataGridProperty = new MyDataGridProperty(myColumnProperties, typeof(StudyDay).FullName, "Учебные дни");
            return myDataGridProperty;
        }


        public void SaveAll()
        {
            WorkToMyDbContext.SaveDB();
        }
       



    }
}
