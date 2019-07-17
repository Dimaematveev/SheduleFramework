using Interface.Interface;
using Interface.Interfaces;
using Student.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    /// <summary>
    /// Класс студент.
    /// </summary>
    public class Student : IStudentWithConsole
    {
        /// <value> Группа студента. </value>
        public IGroup Group { get ; set; }
        /// <value> Человек(стандартный набор).</value>
        public IPerson Person { get ; set; }
        /// <summary>
        /// Конструктор студента. С пустой группой.
        /// </summary>
        /// <param name="person">Человек.</param>
        public Student(IPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Человек не должен быть пуст!", nameof(person));
            }
            Person = person;
            Group = null;
        }
        /// <summary>
        /// Конструктор студента.Вызывает другой конструктор.
        /// </summary>
        /// <param name="person">Человек.</param>
        /// <param name="group">Группа.</param>
        public Student(IPerson person, IGroup group):this(person)
        {
            EditOrNewGroup(group);
        }
        /// <summary>
        /// Удаляет группу у студента.
        /// </summary>
        public void DelGroup()
        {
            Group = null;
        }
        /// <summary>
        /// Добавляет или изменяет группу у студента.
        /// </summary>
        /// <param name="group">Группа.</param>
        public void EditOrNewGroup(IGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Группа не должна быть пустой!", nameof(group));
            }
            Group = group;
        }
        /// <summary>
        /// Вывод на консоль.
        /// </summary>
        public void ToConsole()
        {
            ((IConsole)Group).ToConsole();
            ((IConsole)Person).ToConsole();
        }
    }
}
