using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Interface
{
    public interface IFile
    {
        void GetVar();

        //TODO: Незнаю пока как реализовать
        //stringstream GetOut(int k);
        int RetNumberLines();
        string RetNameFile();
        void SetVar(string NameFile);
        void SetNumberLines();
        void SetFileOpen();
        void SetFileNotOpen();

    }
}
