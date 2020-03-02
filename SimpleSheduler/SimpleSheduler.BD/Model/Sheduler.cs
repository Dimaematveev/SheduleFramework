using SimpleSheduler.BD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD.Model
{
    /// <summary>
    /// Расписание
    /// </summary>
    public class Sheduler : ICloneable
    {
        /// <summary>
        /// Ключ Расписания
        /// </summary>
        [Key]
        public int ShedulerId { get; set; }
        /// <summary>
        /// номер недели
        /// </summary>
        [Required]
        public int NumberWeek { get; set; }
        /// <summary>
        /// День недели
        /// </summary>
        [Required]
        [StringLength(20)]
        public string DayWeek { get; set; }
        /// <summary>
        /// номер пары
        /// </summary>
        [Required]
        public int NumberPair { get; set; }
        /// <summary>
        /// Аудитория
        /// </summary>
        [Required]
        public int ClassroomId { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        [Required]
        public int SubjectId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        [Required]
        public int GroupId { get; set; }
       
        public object Clone()
        {
            Sheduler newSheduler = new Sheduler()
            {
                ShedulerId = this.ShedulerId,
                NumberWeek = this.NumberWeek,
                DayWeek = this.DayWeek,
                NumberPair = this.NumberPair,
                ClassroomId = this.ClassroomId,
                GroupId = this.GroupId,
                SubjectId = this.SubjectId,
            };
            return newSheduler;
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is Sheduler newSheduler)
            {
                result = result && newSheduler.ShedulerId.Equals(ShedulerId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ShedulerId;
        }

        public override string ToString()
        {
            return $"ID:{ShedulerId}, S:{SubjectId}, C:{ClassroomId}, G:{GroupId}.";
        }
    }
}
