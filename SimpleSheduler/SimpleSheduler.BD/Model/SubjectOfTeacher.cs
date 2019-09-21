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
    public class SubjectOfTeacher
    {
        public SubjectOfTeacher(int teacherId, int subjectId)
        {
            TeacherId = teacherId;
            SubjectId = subjectId;
        }

        public SubjectOfTeacher()
        {
        }

        /// <summary>
        /// Ключ  Предмета преподавателя
        /// </summary>
        [Key]
        public int SubjectOfTeacherId { get; set; }
        private int teacherId;
        /// <summary>
        /// Преподаватель
        /// </summary>
        [Required]
        public int TeacherId
        {
            get
            {
                return teacherId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"id Преподавателя должно быть больше 0!({value})", nameof(teacherId));
                }
                teacherId = value;
            }
        }
        private int subjectId;
        /// <summary>
        /// Предмет
        /// </summary>
        [Required]
        public int SubjectId
        {
            get
            {
                return subjectId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"id Предмета должно быть больше 0!({value})", nameof(subjectId));
                }
                subjectId = value;
            }
        }


        /// <summary>
        /// Для связи с Преподавателем.
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}
