using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Interface
{
    public interface IFilling1:IFilling,IAuditoryFund
    {
        //TODO:Не знаю
        //void SetVar(Auditory* A, BeginTime* BT, Group* G);
        void Var(char ch);
        //TODO: не знаю
        //void GetVecSP(BeginTime* BT);
        void GetAuditory();
        void GetGroup();
        int RetProvGroup(string str);
    }
}
