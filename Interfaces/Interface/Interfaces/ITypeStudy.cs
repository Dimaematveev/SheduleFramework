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
    public interface ITypeStudy
    {
        /// <value> Тип обучения (очка,...)</value>
        string TypeStudy { get; set; }
    }
}
