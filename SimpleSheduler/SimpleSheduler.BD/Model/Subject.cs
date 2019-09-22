using SimpleSheduler.BD.Model;
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
    public class Subject : IName
    {
        
        /// <summary>
        /// Ключ Предмета
        /// </summary>
        [Key]
        public int SubjectId { get; set; }
        /// <summary>
        /// Название Предмета
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

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


        public string NameString()
        {
            return Name;
        }
    }
}
