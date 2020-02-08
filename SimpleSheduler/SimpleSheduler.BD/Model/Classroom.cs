using SimpleSheduler.BD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Аудитория
    /// </summary>
    public class Classroom : IAbbreviation , IIsDelete, ICloneable
    {

        /// <summary>
        /// Ключ Аудитории
        /// </summary>
        [Key]
        public int ClassroomId { get; set; }
        /// <summary>
        /// Название Аудитории - можно сказать сокращенное название
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Abbreviation { get; set; }
        /// <summary>
        /// Полное Название Аудитории
        /// </summary>
        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        /// <summary>
        /// Кол-во мест в аудитории. ?значит может быть нуль
        /// </summary>
        [Required]
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;

        public object Clone()
        {
            Classroom newClassroom = new Classroom()
            {
                ClassroomId = this.ClassroomId,
                Abbreviation = this.Abbreviation,
                NumberOfSeats = this.NumberOfSeats,
                IsDelete = this.IsDelete,
                FullName = this.FullName,
            };
            return newClassroom;
        }

        public string AbbreviationString()
        {
            return Abbreviation;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is Classroom newClassroom)
            {
                result = result && newClassroom.ClassroomId.Equals(ClassroomId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ClassroomId;
        }

        public override string ToString()
        {
            return $"ID:{ClassroomId}, N:{Abbreviation}, Num:{NumberOfSeats}.";
        }
    }
}
