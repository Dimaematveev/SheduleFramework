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


        public DataTable GetDateTableBDCurriculum()
        {
            var BDClass = curricula;
            DataTable table = new DataTable();
            {
                DataColumn column;
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "CurriculumId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(Group),
                    Caption = "Группа",
                    ColumnName = "Group"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(Subject),
                    Caption = "Предмет",
                    ColumnName = "Subject"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Количество лекций",
                    ColumnName = "NumberOfLectures"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Количество практических",
                    ColumnName = "NumberOfPractical"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Количество лабораторных",
                    ColumnName = "NumberOfLaboratory"
                };
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
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "SubjectId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Название Предмета",
                    ColumnName = "Name"
                };
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
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "ClassroomId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Название Аудитории",
                    ColumnName = "Name"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Количество мест",
                    ColumnName = "NumberOfSeats"
                };
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
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "GroupId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Название Группы",
                    ColumnName = "Name"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Количество человек в группе",
                    ColumnName = "NumberOfPersons"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Семинар",
                    ColumnName = "Seminar"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Поток",
                    ColumnName = "Potok"
                };
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
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "PairId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Номер пары",
                    ColumnName = "NumberThePair"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Название пары",
                    ColumnName = "NameThePair"
                };
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
                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "ID",
                    ColumnName = "StudyDayId"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Номер недели",
                    ColumnName = "NumberOfWeek"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(string),
                    Caption = "Название дня недели",
                    ColumnName = "NameDayOfWeek"
                };
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);

                column = new DataColumn
                {
                    DataType = typeof(int),
                    Caption = "Номер дня недели",
                    ColumnName = "NumberDayOfWeek"
                };
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




        public void SetBDGroup(DataTable dataTable)
        {
            List<int> useGroup = new List<int>();
            for (int i = 0; i < groups.Count; i++)
            {
                useGroup.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = groups.FindIndex(x => x.GroupId == (int)dataTable.Rows[i]["GroupId"]);
                if (ind >= 0)
                {
                    useGroup.Remove(ind);
                    groups[ind] = new Group
                    {
                        GroupId = (int)dataTable.Rows[i]["GroupId"],
                        Name = (string)dataTable.Rows[i]["Name"],
                        NumberOfPersons = (int)dataTable.Rows[i]["NumberOfPersons"],
                        Seminar = (string)dataTable.Rows[i]["Seminar"],
                        Potok = (string)dataTable.Rows[i]["Potok"]
                    };
                }
                else
                {
                    groups.Add(
                        new Group
                        {
                            GroupId = (int)dataTable.Rows[i]["GroupId"],
                            Name = (string)dataTable.Rows[i]["Name"],
                            NumberOfPersons = (int)dataTable.Rows[i]["NumberOfPersons"],
                            Seminar = (string)dataTable.Rows[i]["Seminar"],
                            Potok = (string)dataTable.Rows[i]["Potok"]
                        }
                    );
                }
            }

            for (int i = useGroup.Count-1; i >= 0; i--)
            {
                groups.RemoveAt(useGroup[i]);
            }
            WorkToMyDbContext.SaveDB();

        }
    }
}
