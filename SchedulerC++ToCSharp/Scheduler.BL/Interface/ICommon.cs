using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Interface
{
    public interface ICommon
    {
        void GetVar();
        void GetVar1();
        // TODO: Пока не придумал что делать
        void SetVar(IFile file, int line);
        int RetKol();
        int RetLine();
        int RetNumber();

    }
}
