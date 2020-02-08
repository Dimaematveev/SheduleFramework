using SimpleSheduler.BD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Учебный план на 2 недели
    /// </summary>
    public class Curriculum: IIsDelete, ICloneable
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
        /// Количество Занятий за 2 недели
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Тип занятия Занятия
        /// </summary>
        [Required]
        public int TypeOfClassesId { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;



        /// <summary>
        /// Для связи с группой.
        /// </summary>
        public virtual Group Group { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Для связи с Типом занятия.
        /// </summary>
        public virtual TypeOfClasses TypeOfClasses { get; set; }


        public object Clone()
        {
            Curriculum newCurriculum = new Curriculum()
            {
                CurriculumId = this.CurriculumId,
                Number = this.Number,
                Group = this.Group,
                GroupId = this.GroupId,
                Subject = this.Subject,
                SubjectId = this.SubjectId,
                TypeOfClasses =  this.TypeOfClasses,
                TypeOfClassesId = this.TypeOfClassesId,
                IsDelete = this.IsDelete,
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
            return CurriculumId;
        }


        public override string ToString()
        {
            return $"ID:{CurriculumId}, G:{Group.Abbreviation}, S:{Subject.Abbreviation}, Type:{TypeOfClasses.Abbreviation}, N:{Number}.";
        }
    }
}
