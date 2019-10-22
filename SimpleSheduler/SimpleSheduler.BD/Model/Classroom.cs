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
    /// Аудитория
    /// </summary>
    public class Classroom : IName,ICloneable
    {

        /// <summary>
        /// Ключ Аудитории
        /// </summary>
        [Key]
        public int ClassroomId { get; set; }
        /// <summary>
        /// Название Аудитории
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        /// <summary>
        /// Кол-во мест в аудитории. ?значит может быть нуль
        /// </summary>
        [Required]
        public int NumberOfSeats { get; set; }

        public object Clone()
        {
            Classroom newClassroom = new Classroom()
            {
                ClassroomId = this.ClassroomId,
                Name = this.Name,
                NumberOfSeats = this.NumberOfSeats
            };
            return newClassroom;
        }

        public string NameString()
        {
            return Name;
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
            return $"ID:{ClassroomId}, N:{Name}, Num:{NumberOfSeats}.";
        }
    }
}
