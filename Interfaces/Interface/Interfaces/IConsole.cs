using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Интерфейс для консоли.
    /// </summary>
    [ReadMetaDataInterface(nameof(IConsole), "Интерфейс для консоли.","Где-то подреализовывал)")]
    public interface IConsole
    {
        /// <summary>
        /// Метод для вывода в консоль.
        /// </summary>
        [ReadMetaDataMethod(nameof(ToConsole), "Метод для вывода в консоль.")]
        void ToConsole();
    }
}
