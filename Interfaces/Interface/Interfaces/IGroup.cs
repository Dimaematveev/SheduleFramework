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
    public enum TypeStudy:int
    {
        /// <value>Дневное обучение = 0.</value>
        FullTimeEducation =0,
        /// <value>Заочное обучение = 1.</value>
        ExtraMuralStudies = 1,
        /// <value>Вечернее обучение = 2.</value>
        EveningClass = 2
    }
    /// <summary>
    /// Интерфейс для групп.
    /// </summary>
    [ReadMetaDataInterface(nameof(IGroup), "Интерфейс для групп.", "Простейшее сделано.")]
    public interface IGroup
    {
        /// <value> Название группы (ТВО).</value>
        [ReadMetaDataProperty(nameof(NameGroup), "Название группы (ТВО).")]
        string NameGroup { get; set; }
        /// <value> Список студентов.</value>
        [ReadMetaDataProperty(nameof(Students), "Список студентов.")]
        List<IStudent> Students{ get; set;}
        /// <value> Количество студентов.</value>
        [ReadMetaDataProperty(nameof(NumberOfStutents), "Количество студентов.")]
        int NumberOfStutents { get; }
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
