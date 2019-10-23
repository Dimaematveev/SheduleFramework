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

        public DataTable GetDateTableBD(string sNamespase)
        {
            if (sNamespase == typeof(Subject).FullName)
            {
                return GetDateTableBDSubject();
            }
            if (sNamespase == typeof(Classroom).FullName)
            {
                return GetDateTableBDClassroom();
            }
            if (sNamespase == typeof(Curriculum).FullName)
            {
                return GetDateTableBDCurriculum();
            }
            if (sNamespase == typeof(Pair).FullName)
            {
                return GetDateTableBDPair();
            }
            if (sNamespase == typeof(StudyDay).FullName)
            {
                return GetDateTableBDStudyDay();
            }

            if (sNamespase == typeof(Group).FullName)
            {
                return GetDateTableBDGroup();
            }
            return null;
        }

        public void SetBD(DataTable dataTable)
        {
            string namespase = dataTable.Namespace;
            if (namespase == typeof(Group).FullName)
            {
                SetBDGroup(dataTable);
                return;
            }
            if (namespase == typeof(Classroom).FullName)
            {
                SetBDClassroom(dataTable);
                return;
            }
            if (namespase == typeof(Curriculum).FullName)
            {
                SetBDCurriculum(dataTable);
                return;
            }

            if (namespase == typeof(Subject).FullName)
            {
                SetBDSubject(dataTable);
                return;
            }

            if (namespase == typeof(Pair).FullName)
            {
                SetBDPair(dataTable);
                return;
            }
            if (namespase == typeof(StudyDay).FullName)
            {
                SetBDStudyDay(dataTable);
                return;
            }

        }




        private DataTable GetDateTableBDCurriculum()
        {
            var BDClass = curricula;
            DataTable table = new DataTable();
            table.TableName = "План";
            table.Namespace = typeof(Curriculum).FullName;
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

        private DataTable GetDateTableBDSubject()
        {
            var BDClass = subjects;
            DataTable table = new DataTable();
            table.TableName = "Предметы";
            table.Namespace = typeof(Subject).FullName;
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

        private DataTable GetDateTableBDClassroom()
        {
            var BDClass = classrooms;
            DataTable table = new DataTable();
            table.TableName = "Аудитории";
            table.Namespace = typeof(Classroom).FullName;
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
        private DataTable GetDateTableBDGroup()
        {
            var BDClass = groups;
            DataTable table = new DataTable();
            table.TableName = "Группы";
            table.Namespace = typeof(Group).FullName;
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

        private DataTable GetDateTableBDPair()
        {
            var BDClass = pairs;
            DataTable table = new DataTable();
            table.TableName = "Пары";
            table.Namespace = typeof(Pair).FullName;
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

        private DataTable GetDateTableBDStudyDay()
        {
            var BDClass = studyDays;
            DataTable table = new DataTable();
            table.TableName = "Учебные дни";
            table.Namespace = typeof(StudyDay).FullName;
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

        
        private void SetBDGroup(DataTable dataTable)
        {
            List<int> useGroup = new List<int>();
            var BDList = groups;

            for (int i = 0; i < BDList.Count; i++)
            {
                useGroup.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["GroupId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.GroupId == (int)dataTable.Rows[i]["GroupId"]);



                    if (ind >= 0)
                    {
                        useGroup.Remove(ind);
                        BDList[ind] = new Group
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
                        BDList.Add(
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
                else
                {
                    BDList.Add(
                            new Group
                            {
                                
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
                BDList.RemoveAt(useGroup[i]);
            }
            WorkToMyDbContext.SaveDB();

        }

        private void SetBDClassroom(DataTable dataTable)
        {
            List<int> useList = new List<int>();
            var BDList = classrooms;

            for (int i = 0; i < BDList.Count; i++)
            {
                useList.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["ClassroomId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.ClassroomId == (int)dataTable.Rows[i]["ClassroomId"]);

                    if (ind >= 0)
                    {
                        useList.Remove(ind);
                        BDList[ind] = new Classroom
                        {
                            ClassroomId = (int)dataTable.Rows[i]["ClassroomId"],
                            Name = (string)dataTable.Rows[i]["Name"],
                            NumberOfSeats = (int)dataTable.Rows[i]["NumberOfSeats"],
                           
                        };
                    }
                    else
                    {
                        BDList.Add(
                            new Classroom
                            {
                                ClassroomId = (int)dataTable.Rows[i]["ClassroomId"],
                                Name = (string)dataTable.Rows[i]["Name"],
                                NumberOfSeats = (int)dataTable.Rows[i]["NumberOfSeats"],
                            }
                        );
                    }
                }
                else
                {
                    BDList.Add(
                            new Classroom
                            {
                                Name = (string)dataTable.Rows[i]["Name"],
                                NumberOfSeats = (int)dataTable.Rows[i]["NumberOfSeats"],
                            }
                        );
                }
            }

            for (int i = useList.Count - 1; i >= 0; i--)
            {
                BDList.RemoveAt(useList[i]);
            }
            WorkToMyDbContext.SaveDB();

        }



        private void SetBDCurriculum(DataTable dataTable)
        {
            List<int> useList = new List<int>();
            var BDList = curricula;

            for (int i = 0; i < BDList.Count; i++)
            {
                useList.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["CurriculumId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.CurriculumId == (int)dataTable.Rows[i]["CurriculumId"]);

                    if (ind >= 0)
                    {
                        useList.Remove(ind);
                        BDList[ind] = new Curriculum
                        {
                            CurriculumId = (int)dataTable.Rows[i]["CurriculumId"],
                            NumberOfLaboratory = (int)dataTable.Rows[i]["NumberOfLaboratory"],
                            NumberOfLectures = (int)dataTable.Rows[i]["NumberOfLectures"],
                            NumberOfPractical= (int)dataTable.Rows[i]["NumberOfPractical"],
                            GroupId = ((Group)dataTable.Rows[i]["Group"]).GroupId,
                            SubjectId = ((Subject)dataTable.Rows[i]["Subject"]).SubjectId,

                        };
                    }
                    else
                    {
                        BDList.Add(
                            new Curriculum
                            {
                                CurriculumId = (int)dataTable.Rows[i]["CurriculumId"],
                                NumberOfLaboratory = (int)dataTable.Rows[i]["NumberOfLaboratory"],
                                NumberOfLectures = (int)dataTable.Rows[i]["NumberOfLectures"],
                                NumberOfPractical = (int)dataTable.Rows[i]["NumberOfPractical"],
                                GroupId = ((Group)dataTable.Rows[i]["Group"]).GroupId,
                                SubjectId = ((Subject)dataTable.Rows[i]["Subject"]).SubjectId,
                            }
                        );
                    }
                }
                else
                {
                    BDList.Add(
                            new Curriculum
                            {
                                NumberOfLaboratory = (int)dataTable.Rows[i]["NumberOfLaboratory"],
                                NumberOfLectures = (int)dataTable.Rows[i]["NumberOfLectures"],
                                NumberOfPractical = (int)dataTable.Rows[i]["NumberOfPractical"],
                                GroupId = ((Group)dataTable.Rows[i]["Group"]).GroupId,
                                SubjectId = ((Subject)dataTable.Rows[i]["Subject"]).SubjectId,
                            }
                        );
                }
            }

            for (int i = useList.Count - 1; i >= 0; i--)
            {
                BDList.RemoveAt(useList[i]);
            }
            WorkToMyDbContext.SaveDB();

        }




        private void SetBDSubject(DataTable dataTable)
        {
            List<int> useList = new List<int>();
            var BDList = subjects;

            for (int i = 0; i < BDList.Count; i++)
            {
                useList.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["SubjectId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.SubjectId == (int)dataTable.Rows[i]["SubjectId"]);

                    if (ind >= 0)
                    {
                        useList.Remove(ind);
                        BDList[ind] = new Subject
                        {
                            SubjectId = (int)dataTable.Rows[i]["SubjectId"],
                            Name = (string)dataTable.Rows[i]["Name"],

                        };
                    }
                    else
                    {
                        BDList.Add(
                            new Subject
                            {
                                SubjectId = (int)dataTable.Rows[i]["SubjectId"],
                                Name = (string)dataTable.Rows[i]["Name"],
                            }
                        );
                    }
                }
                else
                {
                    BDList.Add(
                            new Subject
                            {
                                Name = (string)dataTable.Rows[i]["Name"],
                            }
                        );
                }
            }

            for (int i = useList.Count - 1; i >= 0; i--)
            {
                BDList.RemoveAt(useList[i]);
            }
            WorkToMyDbContext.SaveDB();

        }



        private void SetBDPair(DataTable dataTable)
        {
            List<int> useList = new List<int>();
            var BDList = pairs;

            for (int i = 0; i < BDList.Count; i++)
            {
                useList.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["PairId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.PairId == (int)dataTable.Rows[i]["PairId"]);

                    if (ind >= 0)
                    {
                        useList.Remove(ind);
                        BDList[ind] = new Pair
                        {
                            PairId = (int)dataTable.Rows[i]["PairId"],
                            NameThePair = (string)dataTable.Rows[i]["NameThePair"],
                            NumberThePair = (int)dataTable.Rows[i]["NumberThePair"],
                            

                        };
                    }
                    else
                    {
                        BDList.Add(
                            new Pair
                            {
                                PairId = (int)dataTable.Rows[i]["PairId"],
                                NameThePair = (string)dataTable.Rows[i]["NameThePair"],
                                NumberThePair = (int)dataTable.Rows[i]["NumberThePair"],
                            }
                        );
                    }
                }
                else
                {
                    BDList.Add(
                            new Pair
                            {
                               
                                NameThePair = (string)dataTable.Rows[i]["NameThePair"],
                                NumberThePair = (int)dataTable.Rows[i]["NumberThePair"],
                            }
                        );
                }
            }

            for (int i = useList.Count - 1; i >= 0; i--)
            {
                BDList.RemoveAt(useList[i]);
            }
            WorkToMyDbContext.SaveDB();

        }

        private void SetBDStudyDay(DataTable dataTable)
        {
            List<int> useList = new List<int>();
            var BDList = studyDays;

            for (int i = 0; i < BDList.Count; i++)
            {
                useList.Add(i);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int ind = -1;
                if (dataTable.Rows[i]["StudyDayId"].ToString() != "")
                {
                    ind = BDList.FindIndex(x => x.StudyDayId == (int)dataTable.Rows[i]["StudyDayId"]);

                    if (ind >= 0)
                    {
                        useList.Remove(ind);
                        BDList[ind] = new StudyDay
                        {
                            StudyDayId = (int)dataTable.Rows[i]["StudyDayId"],
                            NameDayOfWeek = (string)dataTable.Rows[i]["NameDayOfWeek"],
                            NumberDayOfWeek = (int)dataTable.Rows[i]["NumberDayOfWeek"],
                            NumberOfWeek = (int)dataTable.Rows[i]["NumberOfWeek"],

                        };
                    }
                    else
                    {
                        BDList.Add(
                            new StudyDay
                            {
                                StudyDayId = (int)dataTable.Rows[i]["StudyDayId"],
                                NameDayOfWeek = (string)dataTable.Rows[i]["NameDayOfWeek"],
                                NumberDayOfWeek = (int)dataTable.Rows[i]["NumberDayOfWeek"],
                                NumberOfWeek = (int)dataTable.Rows[i]["NumberOfWeek"],
                            }
                        );
                    }
                }
                else
                {
                    BDList.Add(
                            new StudyDay
                            {
                                
                                NameDayOfWeek = (string)dataTable.Rows[i]["NameDayOfWeek"],
                                NumberDayOfWeek = (int)dataTable.Rows[i]["NumberDayOfWeek"],
                                NumberOfWeek = (int)dataTable.Rows[i]["NumberOfWeek"],
                            }
                        );
                }
            }

            for (int i = useList.Count - 1; i >= 0; i--)
            {
                BDList.RemoveAt(useList[i]);
            }
            WorkToMyDbContext.SaveDB();

        }


    }
}
