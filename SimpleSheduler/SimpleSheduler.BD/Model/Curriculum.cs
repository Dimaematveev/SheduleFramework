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
    public class Curriculum
    {
        public Curriculum(int groupId, int subjectId, int numberOfPairs)
        {
            GroupId = groupId;
            SubjectId = subjectId;
            NumberOfPairs = numberOfPairs;
        }

        public Curriculum()
        {
        }

        /// <summary>
        /// Ключ Учебного плана
        /// </summary>
        [Key]
        public int CurriculumId { get; set; }
        private int groupId;
        /// <summary>
        /// Группа
        /// </summary>
        [Required]
        public int GroupId
        {
            get
            {
                return groupId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"id Группы должно быть больше 0!({value})", nameof(groupId));
                }
                groupId = value;
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
        private int numberOfPairs;
        /// <summary>
        /// Количество пар за 2 недели
        /// </summary>
        [Required]
        public int NumberOfPairs
        {
            get
            {
                return numberOfPairs;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Количество пар за 2 недели должно быть больше 0!({value})", nameof(numberOfPairs));
                }
                numberOfPairs = value;
            }
        }


        /// <summary>
        /// Для связи с группой.
        /// </summary>
        public virtual Group Group { get; set; }
        /// <summary>
        /// Для связи с Предметом.
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}
