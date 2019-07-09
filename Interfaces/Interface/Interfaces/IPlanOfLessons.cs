using Interface.Attributes;
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
    [ReadMetaDataInterface(nameof(IPlanOfLessons), "Интерфейс плана занятий.")]
    public interface IPlanOfLessons
    {
        /// <value> Группа. </value>
        [ReadMetaDataProperty(nameof(Group), "Группа.")]
        IGroup Group { get; set; }
        /// <value> Предмет. </value>
        [ReadMetaDataProperty(nameof(Subject), "Предмет.")]
        ISubject Subject { get; set; }
        /// <value> Количество пар за семестр. </value>
        [ReadMetaDataProperty(nameof(NumberSubject), "Количество пар за семестр.")]
        int NumberSubject { get; set; }
    }
}
