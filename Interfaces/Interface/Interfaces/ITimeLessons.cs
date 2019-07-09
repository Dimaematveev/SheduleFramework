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
    public interface ITimeLessons
    {
        /// <value> Начало пары.</value>
        TimeSpan BeginTime { get; set; }
        /// <value> Окончание пары. </value>
        TimeSpan EndTime { get; set; }
        /// <value> Номер пары.</value>
        int NumberLessons { get; set; }

    }
}
