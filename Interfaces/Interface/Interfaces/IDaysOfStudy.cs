using Interface.Attributes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// перечисление для Study. Какой день.
    /// </summary>
    public enum HowDays : int { WorkingDay = -1, DayOff = 0 };
    /// <summary>
    /// Интерфейс показывающий какой день(учебный, не учебный, сокращенный).
    /// </summary>
    [ReadMetaDataInterface(nameof(IDaysOfStudy), "Интерфейс показывающий какой день(учебный, не учебный, сокращенный).")]
    public interface IDaysOfStudy
    {
        /// <value> Дата.</value>
        [ReadMetaDataProperty(nameof(Date), "Дата.")]
        DateTime Date { get; set; }
        /// <value> Какой день учебный или нет. </value>
        [ReadMetaDataProperty(nameof(Study), "Какой день учебный или нет.")]
        HowDays Study { get; set; }

    }
}
