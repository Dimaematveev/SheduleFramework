using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using SimpleSheduler.BL;
using System;
using System.Collections.Generic;
using System.Data;
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


        public DataTable GetDateTableBDCurriculum()
        {
            var BDClass = curricula;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "CurriculumId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(Group);
                column.Caption = "Группа";
                column.ColumnName = "Group";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(Subject);
                column.Caption = "Предмет";
                column.ColumnName = "Subject";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Количество лекций";
                column.ColumnName = "NumberOfLectures";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Количество практических";
                column.ColumnName = "NumberOfPractical";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Количество лабораторных";
                column.ColumnName = "NumberOfLaboratory";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.CurriculumId}";
                row[1] = item.Group;
                row[2] = item.Subject;
                row[3] = $"{item.NumberOfLectures}";
                row[4] = $"{item.NumberOfPractical}";
                row[5] = $"{item.NumberOfLaboratory}";
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable GetDateTableBDSubject()
        {
            var BDClass = subjects;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "SubjectId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Название Предмета";
                column.ColumnName = "Name";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.SubjectId}";
                row[1] = $"{item.Name}";
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable GetDateTableBDClassroom()
        {
            var BDClass = classrooms;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "ClassroomId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Название Аудитории";
                column.ColumnName = "Name";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Количество мест";
                column.ColumnName = "NumberOfSeats";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.ClassroomId}";
                row[1] = $"{item.Name}";
                row[2] = $"{item.NumberOfSeats}";
                table.Rows.Add(row);
            }
            return table;
        }
        public DataTable GetDateTableBDGroup()
        {
            var BDClass = groups;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "GroupId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Название Группы";
                column.ColumnName = "Name";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Количество человек в группе";
                column.ColumnName = "NumberOfPersons";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Семинар";
                column.ColumnName = "Seminar";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Поток";
                column.ColumnName = "Potok";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.GroupId}";
                row[1] = $"{item.Name}";
                row[2] = $"{item.NumberOfPersons}";
                row[3] = $"{item.Seminar}";
                row[4] = $"{item.Potok}";
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable GetDateTableBDPair()
        {
            var BDClass = pairs;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "PairId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Номер пары";
                column.ColumnName = "NumberThePair";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Название пары";
                column.ColumnName = "NameThePair";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.PairId}";
                row[1] = $"{item.NumberThePair}";
                row[2] = $"{item.NameThePair}";
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable GetDateTableBDStudyDay()
        {
            var BDClass = studyDays;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "ID";
                column.ColumnName = "StudyDayId";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Номер недели";
                column.ColumnName = "NumberOfWeek";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(string);
                column.Caption = "Название дня недели";
                column.ColumnName = "NameDayOfWeek";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = typeof(int);
                column.Caption = "Номер дня недели";
                column.ColumnName = "NumberDayOfWeek";
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

            }
            foreach (var item in BDClass)
            {
                DataRow row;
                row = table.NewRow();

                row[0] = $"{item.StudyDayId}";
                row[1] = $"{item.NumberOfWeek}";
                row[2] = $"{item.NameDayOfWeek}";
                row[3] = $"{item.NumberDayOfWeek}";
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
