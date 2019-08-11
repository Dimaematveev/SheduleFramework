using System;
using System.Collections.Generic;
using Interface.Interface;
using Interface.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;

namespace Sheduler.BL
{
    public class Class1
    {
        ISemester semester = A.Fake<ISemester>();
        
    }
}
