using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс для групп.
    /// </summary>
    public interface IGroup
    {
        /// <value> Название группы (ТВО).</value>
        string NameGroup { get; set; }
        /// <value> Количество студентов.</value>
        int NumberOfStutents { get; set; }
        /// <value> Курс (3).</value>
        int Cours { get; set; }
        /// <value> Семинар (ТВО-3). </value>
        string Seminar { get; set; }
        /// <value> Тип обучения(очка,...) </value>
        string TypeStudy { get; set; }
    }
}
