using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс студента. Реализует интерфейс человека.
    /// </summary>
    public interface IStudent : IPerson
    {
        /// <value> Группа. </value>
        IGroup Group { get; set; }
    }
}
