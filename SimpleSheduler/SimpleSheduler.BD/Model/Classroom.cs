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
    public class Classroom : IName
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

        public string NameString()
        {
            return Name;
        }
    }
}
