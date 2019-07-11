using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс на сколько преподаватель готов вести предмет.
    /// </summary>
    [ReadMetaDataInterface(nameof(ISubjectOfTeacher), "Интерфейс на сколько преподаватель готов вести предмет.","Простейшая реализация.")]
    public interface ISubjectOfTeacher
    {
        /// <value>Предмет.</value>
        [ReadMetaDataProperty(nameof(Subject), "Предмет.")]
        ISubject Subject { get; set; }
        /// <value>Процент готовности преподавать. </value>
        [ReadMetaDataProperty(nameof(Percent), "Процент готовности преподавать.")]
        int Percent { get; set; }

    }
}
