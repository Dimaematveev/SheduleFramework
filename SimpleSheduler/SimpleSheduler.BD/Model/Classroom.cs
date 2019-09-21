﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BD
{
    /// <summary>
    /// Аудитория
    /// </summary>
    public class Classroom
    {
        public Classroom()
        {
        }

        public Classroom(string name, int numberOfSeats)
        {
            Name = name;
            NumberOfSeats = numberOfSeats;
        }

        /// <summary>
        /// Ключ Аудитории
        /// </summary>
        [Key]
        public int ClassroomId { get; set; }
        private string name;
        /// <summary>
        /// Название Аудитории
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Название аудитории не должно быть пустым!({value})", nameof(name));
                }
                name = value;
            }
        }


        private int numberOfSeats;
        /// <summary>
        /// Кол-во мест в аудитории. ?значит может быть нуль
        /// </summary>
        [Required]
        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Количество мест в аудитории должно быть больше 0!({value})", nameof(numberOfSeats));
                }
                numberOfSeats = value;
            }
        }
    }
}
