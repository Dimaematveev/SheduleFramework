using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Предметы преподавателей
    /// </summary>
    public class SubjectOfTeacher:ICloneable
    {
       
        /// <summary>
        /// Ключ  Предмета преподавателя
        /// </summary>
        [Key]
        public int SubjectOfTeacherId { get; set; }
        /// <summary>
        /// Преподаватель
        /// </summary>
        [Required]
        public int TeacherId { get; set; }
        /// <summary>
        /// Предмет
        /// </summary>
        [Required]
        public int SubjectId { get; set; }


        /// <summary>
        /// Для связи с Преподавателем.
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }

        public object Clone()
        {
            SubjectOfTeacher newSubjectOfTeacher = new SubjectOfTeacher()
            {
                SubjectOfTeacherId = this.SubjectOfTeacherId,
                Subject = this.Subject,
                SubjectId = this.SubjectId,
                TeacherId = this.TeacherId,
                Teacher = this.Teacher
            };
            return newSubjectOfTeacher;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is SubjectOfTeacher newSubjectOfTeacher)
            {
                result = result && newSubjectOfTeacher.SubjectOfTeacherId.Equals(SubjectOfTeacherId);
            }
            return result;
        }
        public override string ToString()
        {
            return $"ID:{SubjectOfTeacherId}, T:{Teacher.Name}, S:{Subject.Name}.";
        }
    }
}
