using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс времени пар.
    /// </summary>
    [ReadMetaDataInterface(nameof(ITimeLessons), "Интерфейс времени пар.","Простейший сделан.")]
    public interface ITimeLessons
    {
        /// <value> Начало пары.</value>
        [ReadMetaDataProperty(nameof(BeginTime), "Начало пары.")]
        TimeSpan BeginTime { get; set; }
        /// <value> Окончание пары. </value>
        [ReadMetaDataProperty(nameof(EndTime), "Окончание пары.")]
        TimeSpan EndTime { get; set; }
        /// <value> Номер пары.</value>
        [ReadMetaDataProperty(nameof(NumberLessons), "Номер пары.")]
        int NumberLessons { get; set; }

    }
}
