using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс студента.
    /// </summary>
    [ReadMetaDataInterface(nameof(IStudent), " Интерфейс студента.","Простейшая реализация.")]
    public interface IStudent 
    {
        /// <value> Группа. </value>
        [ReadMetaDataProperty(nameof(Group), "Группа.")]
        IGroup Group { get; set; }

        /// <value> Человек. </value>
        [ReadMetaDataProperty(nameof(Person), "Человек.")]
        IPerson Person { get; set; }
    }
}
