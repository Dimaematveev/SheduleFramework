using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс для людей.
    /// </summary>
    public interface IPerson
    {
        /// <value> Полное имя. </value>
        string Name { get; set; }
        /// <value>Пол. </value>
        bool Gender { get; set; }
        /// <value> Дата рождения. </value>
        DateTime BirthDay { get; set; }
        /// <value> Возраст. </value>
        int Age { get; }
        /// <value> Живет (для того чтобы сказать куда проще ехать учиться). </value>
        string Living { get; set; }
    }
}

