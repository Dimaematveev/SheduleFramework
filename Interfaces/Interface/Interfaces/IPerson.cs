﻿using Interface.Attributes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Пол человека.
    /// </summary>
    public enum Gender:int
    {
        /// <value>Мужчина= 1.</value>
        men = 1,
        /// <value>Женщина = 2.</value>
        women = 2
    };
    /// <summary>
    /// Интерфейс для людей.
    /// </summary>
    [ReadMetaDataInterface(nameof(IPerson), "Интерфейс для людей.","Начально готов.")]
    public interface IPerson
    {
        /// <value> Полное имя. </value>
        [ReadMetaDataProperty(nameof(Name), "Полное имя.")]
        string Name { get; set; }
        /// <value>Пол. </value>
        [ReadMetaDataProperty(nameof(Gender), "Пол.")]
        Gender Gender { get; set; }
        /// <value> Дата рождения. </value>
        [ReadMetaDataProperty(nameof(BirthDay), "Дата рождения.")]
        DateTime BirthDay { get; set; }
        /// <value> Возраст. </value>
        [ReadMetaDataProperty(nameof(Age), "Возраст.")]
        int Age { get; }
        /// <value> Живет (для того чтобы сказать куда проще ехать учиться). </value>
        [ReadMetaDataProperty(nameof(Living), "Живет (для того чтобы сказать куда проще ехать учиться).")]
        string Living { get; set; }
    }
}

