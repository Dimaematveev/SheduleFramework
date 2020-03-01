using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD.Model
{
    /// <summary>
    /// Тип объединения групп
    /// ваианты объединения
    /// </summary>
    public class TypeUnionGroup : IAbbreviation , ICloneable
    {
        /// <summary>
        /// Ключ Типа объединения
        /// </summary>
        [Key]
        public int TypeUnionGroupId { get; set; }

        /// <summary>
        /// Название Объединения - можно сказать сокращенное название
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Abbreviation { get; set; }
        /// <summary>
        /// Полное Название объединения
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }



        public object Clone()
        {
            TypeUnionGroup newTypeUnionGroup = new TypeUnionGroup()
            {
                TypeUnionGroupId = this.TypeUnionGroupId,
                Abbreviation = this.Abbreviation,
                FullName = this.FullName,
            };
            return newTypeUnionGroup;
        }

        public string AbbreviationString()
        {
            return Abbreviation;
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is TypeUnionGroup newTypeUnionGroup)
            {
                result = result && newTypeUnionGroup.TypeUnionGroupId.Equals(TypeUnionGroupId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TypeUnionGroupId;
        }

        public override string ToString()
        {
            return $"ID:{TypeUnionGroupId}, N:{Abbreviation}.";
        }
    }
}
