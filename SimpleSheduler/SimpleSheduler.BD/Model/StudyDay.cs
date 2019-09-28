using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Учебные дни за 2 недели
    /// </summary>
    public class StudyDay
    {
        /// <summary>
        /// Ключ Учебного дня
        /// </summary>
        [Key]
        public int StudyDayId { get; set; }
        /// <summary>
        /// Название дня недели
        /// </summary>
        [Required]
        [StringLength(20)]
        public string NameDayOfWeek { get; set; }
        /// <summary>
        /// Номер недели
        /// </summary>
        [Required]
        public int NumberOfWeek { get; set; }


        public override string ToString()
        {
            return $"ID:{StudyDayId}, N:{NameDayOfWeek}, Num:{NumberOfWeek}.";
        }
    }
}
