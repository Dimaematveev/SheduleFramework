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
    public interface ITypeLessons
    {
        /// <value> Вид пары(лекция,практика) </value>
        string NameType { get; set; }
    }
}
