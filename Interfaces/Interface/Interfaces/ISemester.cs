using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс семестра.
    /// </summary>
    [ReadMetaDataInterface(nameof(ISemester), "Интерфейс семестра.", "Неплохо сделано.")]
    public interface ISemester
    {
        /// <value> Дата начала семестра.</value>
        [ReadMetaDataProperty(nameof(BeginSemestr), "Дата начала семестра.")]
        DateTime BeginSemestr { get; set; }
        /// <value>Дата окончания семестра.</value>
        [ReadMetaDataProperty(nameof(EndSemestr), "Дата окончания семестра.")]
        DateTime EndSemestr { get; set; }
        /// <value> Список дней в семестре с указание учебных или нет. </value>
        [ReadMetaDataProperty(nameof(DaysOfStudies), "Список дней в семестре с указание учебных или нет.")]
        IDaysOfStudy[] DaysOfStudies { get; set; }


        /// <summary>
        /// У указанного дня недели устанавливает тип дня.
        /// </summary>
        /// <param name="dayOfWeek">День недели.</param>
        /// <param name="numberOfPairsPerDay">Тип дня(выходной, учебный..)</param>
        [ReadMetaDataMethod(nameof(AddDayWeek), "У указанного дня недели устанавливает тип дня.")]
        void AddDayWeek(DayOfWeek dayOfWeek, HowDays numberOfPairsPerDay);

        /// <summary>
        /// У указанного дня устанавливает тип дня.
        /// </summary>
        /// <param name="numberOfPairsPerDay">На какой изменить.</param>
        /// <param name="date">День.</param>
        [ReadMetaDataMethod(nameof(AddDayOne), "У указанного дня устанавливает тип дня.")]
        void AddDayOne(HowDays numberOfPairsPerDay, DateTime date);

        /// <summary>
        /// У указанного диапазона дней устанавливает тип дня.
        /// </summary>
        /// <param name="numberOfPairsPerDay">На какой изменить.</param>
        /// <param name="dateBegin">Дата начала диапазона.</param>
        /// <param name="dateEnd">Дата окончания диапазона.</param>
        [ReadMetaDataMethod(nameof(AddDayMany), "У указанного диапазона дней устанавливает тип дня.")]
        void AddDayMany(HowDays numberOfPairsPerDay, DateTime dateBegin, DateTime dateEnd);
    }
}
