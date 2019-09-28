using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Пары 
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// Ключ Пары
        /// </summary>
        [Key]
        public int PairId { get; set; }
        /// <summary>
        /// Название пары
        /// </summary>
        [Required]
        [StringLength(20)]
        public string NameThePair { get; set; }
        /// <summary>
        /// Номер пары
        /// </summary>
        [Required]
        public int NumberThePair { get; set; }

        public override string ToString()
        {
            return $"ID:{PairId}, N:{NameThePair}, Num:{NumberThePair}.";
        }
    }
}
