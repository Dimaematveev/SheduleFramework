using Interface.Interface;
using Interface.Interfaces;
using SubjectOfTeacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher.Interfaces
{
    interface ITeacherWithConsole<T> : ITeacher<T>, IConsole
    where T: ISubjectOfTeacherWithConsole
    {
    }
}
