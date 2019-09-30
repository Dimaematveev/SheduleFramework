﻿using System;
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
    public class Pair:ICloneable
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
        public object Clone()
        {
            Pair newPair = new Pair()
            {
                PairId = this.PairId,
                NameThePair = this.NameThePair,
                NumberThePair = this.NumberThePair
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
        public override string ToString()
        {
            return $"ID:{PairId}, N:{NameThePair}, Num:{NumberThePair}.";
        }
    }
}
