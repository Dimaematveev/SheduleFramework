using Interface.Attributes;
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
    [ReadMetaDataInterface(nameof(ISemester<T>), "Интерфейс семестра.")]
    public interface ISemester<T> where T:IDaysOfStudy
    {
        /// <value> Дата начала семестра.</value>
        [ReadMetaDataProperty(nameof(BeginSemestr), "Дата начала семестра.")]
        DateTime BeginSemestr { get; set; }
        /// <value>Дата окончания семестра.</value>
        [ReadMetaDataProperty(nameof(EndSemestr), "Дата окончания семестра.")]
        DateTime EndSemestr { get; set; }
        /// <value> Список дней в семестре с указание учебных или нет. </value>
        [ReadMetaDataProperty(nameof(DaysOfStudies), "Список дней в семестре с указание учебных или нет.")]
        List<T> DaysOfStudies { get; set; }
    }
}
