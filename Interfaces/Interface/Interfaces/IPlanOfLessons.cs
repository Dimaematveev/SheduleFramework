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
    public interface IPlanOfLessons
    {
        /// <value> Группа. </value>
        IGroup Group { get; set; }
        /// <value> Предмет. </value>
        ISubject Subject { get; set; }
        /// <value> Количество пар за семестр. </value>
        int NumberSubject { get; set; }
    }
}
