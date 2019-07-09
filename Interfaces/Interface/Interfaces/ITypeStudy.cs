using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Интерфейс тип обучения (очка,...)
    /// </summary>
    [ReadMetaDataInterface(nameof(ITypeStudy), "Интерфейс тип обучения (очка,...)")]
    public interface ITypeStudy
    {
        /// <value> Тип обучения (очка,...)</value>
        [ReadMetaDataProperty(nameof(TypeStudy), "Тип обучения (очка,...)")]
        string TypeStudy { get; set; }
    }
}
