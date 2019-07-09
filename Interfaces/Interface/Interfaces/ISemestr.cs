using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс семестра.
    /// </summary>
    public interface ISemestr
    {
        /// <value> Дата начала семестра.</value>
        DateTime BeginSemestr { get; set; }
        /// <value>Дата окончания семестра.</value>
        DateTime EndSemestr { get; set; }
        /// <value> Список дней в семестре с указание учебных или нет. </value>
        List<IDaysOfStudy> DaysOfStudies { get; set; }

    }
}
