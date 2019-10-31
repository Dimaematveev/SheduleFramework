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
    /// Предмет
    /// </summary>
    public class Subject : IName,ICloneable
    {
        
        /// <summary>
        /// Ключ Предмета
        /// </summary>
        [Key]
        public int SubjectId { get; set; }
        /// <summary>
        /// Название Предмета
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Полное Название Предмета
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;


        ///Свойство для EntityFramework
        /// <summary>
        /// У каждого предмета будет храниться весь учебный план. Т.е. связь с Планом занятий
        /// </summary>
        public virtual ICollection<Curriculum> Curricula { get; set; }

       
        public object Clone()
        {
            Subject newSubject = new Subject()
            {
                Curricula = this.Curricula,
                Name = this.Name,
                SubjectId = this.SubjectId,
                IsDelete = this.IsDelete,
                FullName = this.FullName,
               
            };
            return newSubject;
        }
        public string NameString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is Subject newSubject)
            {
                result = result && newSubject.SubjectId.Equals(SubjectId);
                return result;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return SubjectId;
        }
        public override string ToString()
        {
            return $"ID:{SubjectId}, N:{Name}.";
        }
    }
}
