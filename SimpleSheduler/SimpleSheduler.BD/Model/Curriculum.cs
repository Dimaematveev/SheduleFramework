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
    /// Учебный план на 2 недели
    /// </summary>
    public class Curriculum: ICloneable
    {
       
        /// <summary>
        /// Ключ Учебного плана
        /// </summary>
        [Key]
        public int CurriculumId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        [Required]
        public int GroupId { get; set; }
     
        /// <summary>
        /// Предмет
        /// </summary>
        [Required]
        public int SubjectId { get; set; }
        /// <summary>
        /// Тип пары
        /// </summary>
        [Required]
        public int TypePairId { get; set; }
        /// <summary>
        /// Количество пар за 2 недели
        /// </summary>
        [Required]
        public int NumberOfPairs { get; set; }


        /// <summary>
        /// Для связи с группой.
        /// </summary>
        public virtual Group Group { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }
        /// <summary>
        /// Для связи с Типом пары.
        /// </summary>
        public virtual TypePair TypePair { get; set; }

        public object Clone()
        {
            Curriculum newCurriculum = new Curriculum()
            {
                CurriculumId = this.CurriculumId,
                NumberOfPairs = this.NumberOfPairs,
                Group = this.Group,
                GroupId = this.GroupId,
                Subject = this.Subject,
                SubjectId = this.SubjectId,
                TypePair = this.TypePair,
                TypePairId = this.TypePairId
            };
            return newCurriculum;
        }
        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is Curriculum newCurriculum)
            {
                result = result && newCurriculum.CurriculumId.Equals(CurriculumId);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CurriculumId * GroupId * SubjectId * NumberOfPairs;
        }


        public override string ToString()
        {
            return $"ID:{CurriculumId}, G:{Group.Name}, S:{Subject.Name}, TP:{TypePair.Name}, Num:{NumberOfPairs}.";
        }
    }
}
