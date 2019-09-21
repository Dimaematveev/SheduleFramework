using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Предмет
    /// </summary>
    public class Subject
    {
        public Subject(string name)
        {
            Name = name;
        }

        public Subject()
        {
        }

        /// <summary>
        /// Ключ Предмета
        /// </summary>
        [Key]
        public int SubjectId { get; set; }
        private string name;
        /// <summary>
        /// Название Предмета
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Название предмета не должно быть пустым!({value})", nameof(name));
                }
                name = value;
            }
        }

        ///Свойство для EntityFramework
        /// <summary>
        /// У каждого предмета будет храниться весь учебный план. Т.е. связь с Планом занятий
        /// </summary>
        public virtual ICollection<Curriculum> Curricula { get; set; }

        ///Свойство для EntityFramework
        /// <summary>
        /// У каждого предмета будет храниться все преподаватели. Т.е. связь с Предметы преподавателей
        /// </summary>
        public virtual ICollection<SubjectOfTeacher> SubjectOfTeachers { get; set; }
    }
}
