using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Interface
{
    public interface IGrou:ICommon
    {
        
        void SetNumberLessons();
        int RetNumberPersons();
        string RetNameSeminar();
        string RetNameSteam();
        string RetNameGroup();
        int RetNumberLesons();

}
}
