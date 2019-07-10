using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс аудитории.
    /// </summary>
    [ReadMetaDataInterface(nameof(IClassRoom), "Интерфейс аудитории.","Простейшее сделано.")]
    public interface IClassRoom
    {
        /// <value> Название аудитории.</value>
        [ReadMetaDataProperty(nameof(NameClass), "Название аудитории.")]
        string NameClass { get; set; }
        /// <value> Сколько человек вмещается. </value>
        [ReadMetaDataProperty(nameof(NumberOfPeople), "Сколько человек вмещается.")]
        int NumberOfPeople { get; set; }
    }
}
