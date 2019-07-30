using Interface.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс преподавателя. 
    /// </summary>
    [ReadMetaDataInterface(nameof(ITeacher), "Интерфейс преподавателя.","НАчально готов.")]
    public interface ITeacher
    {
        /// <value>Какие предметы может вести. </value>
        [ReadMetaDataProperty(nameof(SubjectOfTeachers), "Какие предметы может вести.")]
        List<ISubjectOfTeacher> SubjectOfTeachers { get; set; }
        /// <value> Сертификаты.</value>
        [ReadMetaDataProperty(nameof(Certification), "Сертификаты.")]
        string Certification { get; set; }
        /// <value> Ставка. </value>
        [ReadMetaDataProperty(nameof(Rate), "Ставка.")]
        int Rate { get; set; }
        /// <value> Человек. </value>
        [ReadMetaDataProperty(nameof(Person), "Человек.")]
        IPerson Person { get; set; }
    }
}
