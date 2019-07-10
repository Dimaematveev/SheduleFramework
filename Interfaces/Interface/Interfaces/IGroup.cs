using Interface.Attributes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Тип обучения.
    /// </summary>
    public enum TypeStudy:int { FullTimeEducation=0, ExtraMuralStudies=1, EveningClass=2 }
    /// <summary>
    /// Интерфейс для групп.
    /// </summary>
    [ReadMetaDataInterface(nameof(IGroup), "Интерфейс для групп.")]
    public interface IGroup
    {
        /// <value> Название группы (ТВО).</value>
        [ReadMetaDataProperty(nameof(NameGroup), "Название группы (ТВО).")]
        string NameGroup { get; set; }
        /// <value> Количество студентов.</value>
        [ReadMetaDataProperty(nameof(NumberOfStutents), "Количество студентов.")]
        int NumberOfStutents { get; set; }
        /// <value> Курс (3).</value>
        [ReadMetaDataProperty(nameof(Cours), "Курс (3).")]
        int Cours { get; set; }
        /// <value> Семинар (ТВО-3). </value>
        [ReadMetaDataProperty(nameof(Seminar), "Семинар (ТВО-3).")]
        string Seminar { get; set; }
        /// <value> Тип обучения(очка,...). </value>
        [ReadMetaDataProperty(nameof(TypeOfTraining), "Тип обучения(очка,...).")]
        TypeStudy TypeOfTraining { get; set; }
    }
}
