using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLessons.Interfaces
{
    interface ITypeLessonsWithConsole: ITypeLessons,IConsole
    {
    }
}
