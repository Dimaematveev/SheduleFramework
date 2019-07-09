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
    /// Интерфейс показывающий какой день(учебный, не учебный, сокращенный)
    /// </summary>
    public interface IDaysOfStudy
    {
        /// <value> Дата.</value>
        DateTime Day { get; set; }
        /// <value> Какой день учебный или нет. </value>
        int Study { get; set; }

    }
}
