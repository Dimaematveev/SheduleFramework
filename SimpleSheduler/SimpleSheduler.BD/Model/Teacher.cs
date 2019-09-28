﻿using SimpleSheduler.BD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Преподаватель
    /// </summary>
    public class Teacher:IName
    {
        

        /// <summary>
        /// Ключ Преподавателя
        /// </summary>
        [Key]
        public int TeacherId { get; set; }
        /// <summary>
        /// Имя Преподавателя
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        ///Свойство для EntityFramework
        /// <summary>
        /// У каждого преподавателя будет храниться все преподаватели. Т.е. связь с Предметы преподавателей
        /// </summary>
        public virtual ICollection<SubjectOfTeacher> SubjectOfTeachers { get; set; }


        public string NameString()
        {
            return Name;
        }


        public override string ToString()
        {
            return $"ID:{TeacherId}, N:{Name}.";
        }
    }
}
