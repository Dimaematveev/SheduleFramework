using Interface.Attributes;
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
    [ReadMetaDataInterface(nameof(ISubject), "Интерфейс для учебных предметов.")]
    public interface ISubject
    {
        /// <value> Название предмета. </value>
        [ReadMetaDataProperty(nameof(NameSubject), "Название предмета.")]
        string NameSubject { get; set; }
        /// <value> Кафедра. </value>
        [ReadMetaDataProperty(nameof(Departament), "Кафедра.")]
        string Departament { get; set; }
    }
}
