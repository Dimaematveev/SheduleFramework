using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Интерфейс гендера.
    /// </summary>
    [ReadMetaDataInterface(nameof(IGender), "Интерфейс гендера.","Простейший создан")]
    public interface IGender
    {
        /// <value> Название гендера.</value>
        [ReadMetaDataProperty(nameof(NameGender), "Название гендера.")]
        string NameGender { get; set; }
    }
}
