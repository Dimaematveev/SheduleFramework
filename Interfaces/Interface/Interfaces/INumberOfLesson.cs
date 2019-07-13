using Interface.Attributes;
using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Интерфейс количества пар в семестр.
    /// </summary>
    [ReadMetaDataInterface(nameof(INumberOfLesson), "Интерфейс количества пар в семестр.")]
    public interface INumberOfLesson
    {
        /// <value> Предмет. </value>
        [ReadMetaDataProperty(nameof(Subject), "Предмет.")]
        ISubject Subject { get; set; }
        /// <value> Количество пар за семестр. </value>
        [ReadMetaDataProperty(nameof(NumberSubject), "Количество пар за семестр.")]
        int NumberSubject { get; set; }
    }
}
