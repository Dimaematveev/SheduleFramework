using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Interface
{
    public interface IAuditoryFund
    {
        void SetMass();
        void SetTable();
        void GetTable(int col);

    }
}
