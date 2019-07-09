using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    /// <summary>
    /// Интерфейс преподавателя. Реализует интерфейс человека.
    /// </summary>
    public interface ITeacher : IPerson
    {
        /// <value>Какие предметы может вести. </value>
        List<ISubjectOfTeacher> SubjectOfTeachers { get; set; }
        /// <value> Сертификаты.</value>
        string Certification { get; set; }
        /// <value> Ставка. </value>
        int Rate { get; set; }
    }
}
