using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс для учебных предметов.
    /// </summary>
    public interface ISubject
    {
        /// <value> Название предмета. </value>
        string NameSubject { get; set; }
        /// <value> Кафедра. </value>
        string Departament { get; set; }
    }
}
