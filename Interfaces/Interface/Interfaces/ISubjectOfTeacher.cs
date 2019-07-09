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
    public interface ISubjectOfTeacher
    {
        /// <value>Предмет.</value>
        ISubject Subject { get; set; }
        /// <value>Процент готовности преподавать. </value>
        int Percent { get; set; }

    }
}
