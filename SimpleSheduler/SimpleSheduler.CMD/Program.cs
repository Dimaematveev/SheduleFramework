using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет мир!");

            ///Создаем подключение к БД
            ///т.к. работает с внешним хранилищем и за безопасность
            ///


            
            using(var context =new MyDbContext())
            {
                /*
                var group = new Group()
                {
                    Name = "G1",
                    NumberOfPersons = 10
                };

                var classroom = new Classroom()
                {
                    Name = "C1",
                    NumberOfSeats=10

                };
                var teacher = new Teacher()
                {
                    Name = "T1"

                };
                var subject = new Subject()
                {
                    Name = "S1"
                };
                ///Добавляем запись в наш КЭШ но пока не отправили в БД
                context.Groups.Add(group);
                context.Classrooms.Add(classroom);
                context.Teachers.Add(teacher);
                context.Subjects.Add(subject);
                

                ///Все изменения из локального хранилища в БД
                context.SaveChanges();
                */
                Group group = context.Groups.First();
                Teacher teacher = context.Teachers.First();
                Subject subject = context.Subjects.First();
                var curriculums = new List<Curriculum>()
                {
                    new Curriculum(){GroupId = group.GroupId, SubjectId = subject.SubjectId}
                    
                };
                var subjectsOfTeachers = new List<SubjectOfTeacher>()
                {
                    new SubjectOfTeacher(){TeacherId = teacher.TeacherId,SubjectId = subject.SubjectId}
                    
                    
                };
                context.Curriculums.AddRange(curriculums);
                context.SubjectsOfTeachers.AddRange(subjectsOfTeachers);
                context.SaveChanges();


            }

        }
    }
}
