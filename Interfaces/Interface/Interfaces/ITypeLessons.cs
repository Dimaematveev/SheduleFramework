using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс виды пары.
    /// </summary>
    [ReadMetaDataInterface(nameof(ITypeLessons), "Интерфейс виды пары.","Простейший готов.")]
    public interface ITypeLessons
    {
        /// <value> Вид пары(лекция,практика) </value>
        [ReadMetaDataProperty(nameof(NameType), "Вид пары(лекция,практика)")]
        string NameType { get; set; }
    }
}
