using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanOfLessons.Interfaces
{
    interface IPlanOfLessonsWithConsole: IPlanOfLessons, IConsole
    {
    }
}
