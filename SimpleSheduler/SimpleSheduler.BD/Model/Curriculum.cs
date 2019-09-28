using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Учебный план на 2 недели
    /// </summary>
    public class Curriculum
    {
       
        /// <summary>
        /// Ключ Учебного плана
        /// </summary>
        [Key]
        public int CurriculumId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        [Required]
        public int GroupId { get; set; }
     
        /// <summary>
        /// Предмет
        /// </summary>
        [Required]
        public int SubjectId { get; set; }
        /// <summary>
        /// Количество пар за 2 недели
        /// </summary>
        [Required]
        public int NumberOfPairs { get; set; }


        /// <summary>
        /// Для связи с группой.
        /// </summary>
        public virtual Group Group { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }

        public override string ToString()
        {
            return $"ID:{CurriculumId}, G:{Group.Name}, S:{Subject.Name}, Num:{NumberOfPairs}.";
        }
    }
}
