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

                var group1 = new Group("G1", 10);

                var classroom1 = new Classroom("C1", 10);
                var teacher1 = new Teacher("T1");
                var subject1 = new Subject("S1");
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
                var curricula = new List<Curriculum>()
                {
                    new Curriculum(group.GroupId,subject.SubjectId,10)
                    
                };
                var subjectOfTeachers = new List<SubjectOfTeacher>()
                {
                    new SubjectOfTeacher(teacher.TeacherId,subject.SubjectId)
                    
                    
                };
                context.Curriculums.AddRange(curricula);
                context.SubjectsOfTeachers.AddRange(subjectOfTeachers);
                context.SaveChanges();


            }

        }
    }
}
