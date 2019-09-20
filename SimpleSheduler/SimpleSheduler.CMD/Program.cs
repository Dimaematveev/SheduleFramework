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
                
                var group1 = new Group()
                {
                    Name = "G1",
                    NumberOfPersons = 10
                };

                var classroom1 = new Classroom()
                {
                    Name = "C1",
                    NumberOfSeats=10

                };
                var teacher1 = new Teacher()
                {
                    Name = "T1"

                };
                var subject1 = new Subject()
                {
                    Name = "S1"
                };
                ///Добавляем запись в наш КЭШ но пока не отправили в БД
                context.Groups.Add(group1);
                context.Classrooms.Add(classroom1);
                context.Teachers.Add(teacher1);
                context.Subjects.Add(subject1);
                

                ///Все изменения из локального хранилища в БД
                context.SaveChanges();
                
                Group group = context.Groups.ToArray().Last();
                Teacher teacher = context.Teachers.ToArray().Last();
                Subject subject = context.Subjects.ToArray().Last();
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
