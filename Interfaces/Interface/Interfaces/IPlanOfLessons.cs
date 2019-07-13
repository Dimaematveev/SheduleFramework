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
    /// Интерфейс плана занятий.
    /// </summary>
    [ReadMetaDataInterface(nameof(IPlanOfLessons), "Интерфейс плана занятий.","Первоначально готов.")]
    public interface IPlanOfLessons
    {
        /// <value> Группа. </value>
        [ReadMetaDataProperty(nameof(Group), "Группа.")]
        IGroup Group { get; set; }

        /// <value> Список количества пар за семестр. </value>
        [ReadMetaDataProperty(nameof(NumberOfLesson), "Группа.")]
        List<INumberOfLesson> NumberOfLesson { get; set; }

    }
}
