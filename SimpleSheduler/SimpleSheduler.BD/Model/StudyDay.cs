using SimpleSheduler.BD.Model;
using System;
using System.ComponentModel.DataAnnotations;

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
        public string AbbreviationDayOfWeek { get; set; }

        /// <summary>
        /// полное Название дня недели
        /// </summary>
        [Required]
        [StringLength(20)]
        public string FullNameDayOfWeek { get; set; }

        /// <summary>
        /// Номер дня недели
        /// </summary>

        public int? NumberDayOfWeek { get; set; }
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
                AbbreviationDayOfWeek = this.AbbreviationDayOfWeek,
                NumberDayOfWeek = this.NumberDayOfWeek,
                NumberOfWeek = this.NumberOfWeek,
                FullNameDayOfWeek = this.FullNameDayOfWeek,
            };
            return newStudyDay;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is StudyDay newStudyDay)
            {
                result = result && newStudyDay.StudyDayId.Equals(StudyDayId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return StudyDayId;
        }


        public override string ToString()
        {
            return $"ID:{StudyDayId}, NumDay:{NumberDayOfWeek}, N:{AbbreviationDayOfWeek}, NumWeek:{NumberOfWeek}.";
        }
    }
}
