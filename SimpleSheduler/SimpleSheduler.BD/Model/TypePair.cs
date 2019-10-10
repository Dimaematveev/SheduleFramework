using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD.Model
{
    /// <summary>
    /// Тип пары
    /// </summary>
    public class TypePair : IName, ICloneable
    {
        /// <summary>
        /// Ключ Типа пары
        /// </summary>
        [Key]
        public int TypePairId { get; set; }
        /// <summary>
        /// Название Типа пары
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }



        public object Clone()
        {
            TypePair newTypePair = new TypePair()
            {
                TypePairId = this.TypePairId,
                Name = this.Name
            };
            return newTypePair;
        }

        public string NameString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is TypePair newTypePair)
            {
                result = result && newTypePair.TypePairId.Equals(TypePairId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TypePairId;
        }

        public override string ToString()
        {
            return $"ID:{TypePairId}, N:{Name}.";
        }




    }
}
