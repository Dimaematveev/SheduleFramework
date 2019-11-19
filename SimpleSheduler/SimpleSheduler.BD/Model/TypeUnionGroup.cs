using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD.Model
{
    /// <summary>
    /// Тип объединения групп
    /// ваианты объединения
    /// </summary>
    public class TypeUnionGroup : IAbbreviation , IIsDelete, ICloneable
    {
        /// <summary>
        /// Ключ Типа объединения
        /// </summary>
        [Key]
        public int TypeUnionGroupId { get; set; }
        /// <summary>
        /// Удален
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;
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
                IsDelete = this.IsDelete,
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
