using Group.Interfaces;
using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    /// <summary>
    /// Класс Группа студентов
    /// </summary>
    public class Group : IGroupWithConsole
    {

        /// <value>Имя группы.</value>
        public string NameGroup { get; set; }
        /// <value>Количество человек в группе(Берется из списка студентов).</value>
        public int NumberOfStutents { get => Students.Count; }
        /// <value>Курс.</value>
        public int Cours { get; set; }
        /// <value>Семинар.</value>
        public string Seminar { get; set; }
        /// <value>Тип обучения.</value>
        public TypeStudy TypeOfTraining { get; set; }
        /// <value>Список студентов.</value>
        public List<IStudent> Students { get; set; } 
        /// <summary>
        /// Конструктор класса группы. С пустым списком студентов.
        /// </summary>
        /// <param name="nameGroup">Имя группы.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        /// <param name="typeOfTraining">Тип обучения.</param>
        public Group(   string nameGroup,
                        int cours, 
                        string seminar, 
                        TypeStudy typeOfTraining)
        {

            if (string.IsNullOrWhiteSpace(nameGroup))
            {
                throw new ArgumentNullException("Имя группы не должно быть пустым!", nameof(nameGroup));
            }
            if (cours < 1 || cours>5)
            {
                throw new ArgumentException($"Курс должен быть больше нуля и не превышать 5!", nameof(cours));
            }
            if (string.IsNullOrWhiteSpace(seminar))
            {
                throw new ArgumentNullException("Семинар не должен быть пустым.", nameof(seminar));
            }
            NameGroup = nameGroup;
            Cours = cours;
            Seminar = seminar;
            TypeOfTraining = typeOfTraining;
            Students = new List<IStudent>();
        }
        /// <summary>
        /// Конструктор группы со списком студентов. Автоматически вызывает другой конструктор. И добавляет студентов.
        /// </summary>
        /// <param name="nameGroup">Имя группы.</param>
        /// <param name="cours">Курс.</param>
        /// <param name="seminar">Семинар.</param>
        /// <param name="typeOfTraining">Тип обучения.</param>
        /// <param name="students">Список студентов.</param>
        public Group(string nameGroup,
                        int cours,
                        string seminar,
                        TypeStudy typeOfTraining,
                        List<IStudent> students) : this(nameGroup, cours, seminar, typeOfTraining)
        {
            AddStudent(students);
        }
        /// <summary>
        /// Добавление студентов в группу(одного).
        /// </summary>
        /// <param name="student">Студент.</param>
        public bool AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException($"Количество студентов в группе должно быть больше нуля!", nameof(student));
            }
            if (Equals(student.Group,this) || Equals(student.Group, null))
            {
                student.Group = this;
                Students.Add(student);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// Добавление студентов в группу(Список).
        /// </summary>
        /// <param name="students">Список студентов.</param>
        public bool AddStudent(List<IStudent> students)
        {
            if (students.Count <= 0 || students == null)
            {
                throw new ArgumentNullException($"Количество студентов в группе должно быть больше нуля!", nameof(students));
            }
            if (students.All(student=>Equals(student.Group, this)|| Equals(student.Group, null)))
            {
                students.ForEach(stud => stud.Group = this);
                Students.AddRange(students);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Вывод на консоль.
        /// </summary>
        public void ToConsole()
        {
            Console.WriteLine(Seminar);
        }
    }
}
