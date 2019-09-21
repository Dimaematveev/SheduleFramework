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
        //public Group()
        //{
        //}

        //public Group(string name, int numberOfPersons)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentNullException($"Название группы не должно быть пустым!({name})", nameof(name)); ;
        //    }
        //    if (numberOfPersons <= 0)
        //    {
        //        throw new ArgumentNullException($"Количество человек в группе должно быть больше 0!({numberOfPersons})", nameof(numberOfPersons));
        //    }
        //    Name = name;
        //    NumberOfPersons = numberOfPersons;
        //}

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
