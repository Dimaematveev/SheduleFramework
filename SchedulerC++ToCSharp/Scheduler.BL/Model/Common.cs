using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Common : ICommon
    {
        //TODO: 
        protected MyFile file;
        protected int line;



        public virtual void GetVar()
        {
            throw new NotImplementedException();
        }

        public virtual void GetVar1()
        {
            throw new NotImplementedException();
        }
        //TODO:
        public virtual void SetVar(MyFile file, int line)
        {
            throw new NotImplementedException();
        }
        public int RetKol()
        {
            return file.RetNumberLines();
        }

        public int RetLine()
        {
            return line;
        }

        public virtual int RetNumber()
        {
            throw new NotImplementedException();
        }

        public void SetVar(IFile file, int line)
        {
            throw new NotImplementedException();
        }
    }
}
