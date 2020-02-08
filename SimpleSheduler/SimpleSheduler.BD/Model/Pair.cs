using SimpleSheduler.BD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Пары 
    /// </summary>
    public class Pair: IIsDelete, ICloneable
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
        /// <summary>
        /// Удален
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;

        public object Clone()
        {
            Pair newPair = new Pair()
            {
                PairId = this.PairId,
                NameThePair = this.NameThePair,
                NumberThePair = this.NumberThePair,
                IsDelete = this.IsDelete,
            };
            return newPair;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is Pair newPair)
            {
                result = result && newPair.PairId.Equals(PairId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return PairId;
        }

        public override string ToString()
        {
            return $"ID:{PairId}, N:{NameThePair}, Num:{NumberThePair}.";
        }
    }
}
