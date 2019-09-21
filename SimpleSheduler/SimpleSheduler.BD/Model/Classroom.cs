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
    public class Classroom
    {
        //public Classroom()
        //{
        //}

        //public Classroom(string name, int numberOfSeats)
        //{
        //    if (numberOfSeats <= 0)
        //    {
        //        throw new ArgumentNullException($"Количество мест в аудитории должно быть больше 0!({numberOfSeats})", nameof(numberOfSeats));
        //    }
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentNullException($"Название аудитории не должно быть пустым!({name})", nameof(name));
        //    }
        //    Name = name;
        //    NumberOfSeats = numberOfSeats;
        //}

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
    }
}
