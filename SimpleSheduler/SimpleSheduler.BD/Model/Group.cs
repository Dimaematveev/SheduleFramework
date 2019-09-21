using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Группа.
    /// </summary>
    public class Group
    {
        
        /// <summary>
        /// Ключ группы
        /// </summary>
        [Key]
        public int GroupId { get; set; }
        /// <summary>
        /// Название группы
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// Кол-во человек в группе. ?значит может быть нуль
        /// </summary>
        [Required]
        public int NumberOfPersons { get; set; }




        ///Свойство для EntityFramework
        /// <summary>
        /// У каждой группы будет храниться весь учебный план. Т.е. связь с Планом занятий
        /// </summary>
        public virtual ICollection<Curriculum> Curricula { get; set; }

    }
}
