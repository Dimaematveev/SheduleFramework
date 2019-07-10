using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Интерфейс тип обучения (очка,...) удалить
    /// </summary>
    [ReadMetaDataInterface(nameof(ITypeStudy), "Интерфейс тип обучения (очка,...)  удалить")]
    public interface ITypeStudy
    {
        /// <value> Тип обучения (очка,...)</value>
        [ReadMetaDataProperty(nameof(TypeOfTraining), "Тип обучения (очка,...)")]
        string TypeOfTraining { get; set; }
    }
}
