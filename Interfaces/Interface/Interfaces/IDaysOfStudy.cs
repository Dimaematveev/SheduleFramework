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
    public enum HowDays : int
    {
        /// <value>Рабочий день = -1.</value>
        WorkingDay = -1,
        /// <value>Выходной день = 0.</value>
        DayOff = 0
    };
    /// <summary>
    /// Интерфейс показывающий какой день(учебный, не учебный, сокращенный).
    /// </summary>
    [ReadMetaDataInterface(nameof(IDaysOfStudy), "Интерфейс показывающий какой день(учебный, не учебный, сокращенный).", "Простейшее сделано.")]
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
