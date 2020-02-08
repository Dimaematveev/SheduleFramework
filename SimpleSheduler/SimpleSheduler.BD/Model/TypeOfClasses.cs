using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD.Model
{
    /// <summary>
    /// Тип занятий
    /// </summary>
    public class TypeOfClasses : IAbbreviation, IIsDelete, ICloneable
    {


        /// <summary>
        /// Ключ Типа занятий
        /// </summary>
        [Key]
        public int TypeOfClassesId { get; set; }
        /// <summary>
        /// Сокращенное название объединения
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Abbreviation { get; set; }
        /// <summary>
        /// Название объединения
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        /// <summary>
        /// Удален?
        /// </summary>
        [Required]
        public bool IsDelete { get; set; }


        ///Свойство для EntityFramework
        /// <summary>
        /// У каждого предмета будет храниться все типы занятий. Т.е. связь с Планом занятий
        /// </summary>
        public virtual ICollection<Curriculum> Curricula { get; set; }
        public string AbbreviationString()
        {
            return Abbreviation;
        }

        public object Clone()
        {
            TypeOfClasses newTypeOfClasses = new TypeOfClasses()
            {
                Curricula = this.Curricula,
                TypeOfClassesId = this.TypeOfClassesId,
                Abbreviation = this.Abbreviation,
                FullName = this.FullName,
                IsDelete = this.IsDelete,
            };
            return newTypeOfClasses;
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is TypeOfClasses newnewTypeOfClasses)
            {
                result = result && newnewTypeOfClasses.TypeOfClassesId.Equals(TypeOfClassesId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TypeOfClassesId;
        }

        public override string ToString()
        {
            return $"ID:{TypeOfClassesId}, N:{Abbreviation}.";
        }
    }
}
