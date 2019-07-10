using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Interfaces
{
    interface IPersonWithConsole:IPerson, IConsole
    {
    }
}
