using Interface.Attributes;
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
    [ReadMetaDataInterface(nameof(IStudent), " Интерфейс студента. Реализует интерфейс человека.")]
    public interface IStudent : IPerson
    {
        /// <value> Группа. </value>
        [ReadMetaDataProperty(nameof(Group), "Группа.")]
        IGroup Group { get; set; }
    }
}
