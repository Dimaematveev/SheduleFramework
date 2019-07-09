using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс аудитории.
    /// </summary>
    public interface IClassRoom
    {
        /// <value> Название аудитории.</value>
        string NameClass { get; set; }
        /// <value> Сколько человек вмещается. </value>
        int NumberOfPeople { get; set; }
    }
}
