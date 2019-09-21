using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.CMD
{
    /// <summary>
    /// Первоначально заполнение для тестирования!
    /// </summary>
    public class InitialFilling
    {
        public void Filling()
        {
            using (var context = new MyDbContext())
            {

                var groups = new List<Group>
                {
                    new Group(){Name="Класс-1",NumberOfPersons= 8 },
                };

                var classrooms = new List<Classroom>
                {
                    new Classroom(){Name="Аудитория №1",NumberOfSeats= 101 },
                };
                var teachers = new List<Teacher>
                {            
                    new Teacher(){Name="Преподаватель-1" },
                };
                var subjects = new List<Subject>
                {
                    new Subject(){Name="Русский язык" },
                };
                ///Добавляем запись в наш КЭШ но пока не отправили в БД
                context.Groups.AddRange(groups);
                context.Classrooms.AddRange(classrooms);
                context.Teachers.AddRange(teachers);
                context.Subjects.AddRange(subjects);
                ///Все изменения из локального хранилища в БД
                context.SaveChanges();

                //Group group = context.Groups.ToArray().Last();
                //Teacher teacher = context.Teachers.ToArray().Last();
                //Subject subject = context.Subjects.ToArray().Last();
                //var curricula = new List<Curriculum>()
                //{
                //    new Curriculum(group.GroupId,subject.SubjectId,10)

                //};
                //var subjectOfTeachers = new List<SubjectOfTeacher>()
                //{
                //    new SubjectOfTeacher(teacher.TeacherId,subject.SubjectId)


                //};
                //context.Curriculums.AddRange(curricula);
                //context.SubjectsOfTeachers.AddRange(subjectOfTeachers);
                //context.SaveChanges();


            }
        }
    }
}
