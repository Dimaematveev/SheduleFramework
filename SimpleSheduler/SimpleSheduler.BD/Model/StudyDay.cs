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
    public class StudyDay:ICloneable
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

        public object Clone()
        {
            StudyDay newStudyDay = new StudyDay()
            {
                StudyDayId = this.StudyDayId,
                NameDayOfWeek = this.NameDayOfWeek,
                NumberOfWeek = this.NumberOfWeek
            };
            return newStudyDay;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is StudyDay newStudyDay)
            {
                result = result && newStudyDay.StudyDayId.Equals(StudyDayId);
            }
            return result;
        }
        public override string ToString()
        {
            return $"ID:{StudyDayId}, N:{NameDayOfWeek}, Num:{NumberOfWeek}.";
        }
    }
}
