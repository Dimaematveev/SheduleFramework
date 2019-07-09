using Interface.Attributes;
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

    enum HowDays { study = 2, notstudy = 0, shortened = 1 };
    /// <summary>
    /// Интерфейс показывающий какой день(учебный, не учебный, сокращенный).
    /// </summary>
    [ReadMetaDataInterface(nameof(IDaysOfStudy), "Интерфейс показывающий какой день(учебный, не учебный, сокращенный).")]
    public interface IDaysOfStudy
    {
        /// <value> Дата.</value>
        [ReadMetaDataProperty(nameof(Day), "Дата.")]
        DateTime Day { get; set; }
        /// <value> Какой день учебный или нет. </value>
        [ReadMetaDataProperty(nameof(Study), "Какой день учебный или нет.")]
        int Study { get; set; }

    }
}
