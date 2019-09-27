using Scheduler.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.BL.Model
{
    public class Fillin: IFillin
    {
        //TODO:
        protected  Auditory[] audit;
        protected Group[] grou;
        protected BeginTime[] tim;

        //TODO
        public void GetVar()
        {
            //cout << "Call '" << typeid(Fillin).name() << "' static number='" << number << "' id='" << id << "' " << endl;
            for (int i = 0; i < grou[0].RetKol(); i++)
            {
                grou[i].GetVar();
            }

            audit[0].GetVar();
            //cout << "NumberPersons:'" << PeopleClassroom << "' NameGroup:'" << NumberClassroom << "'" << endl;
        }

        //TODO:
        public virtual void SetVar(Auditory[] audit, BeginTime[] tim, Group[] grou)
        {
            this.audit = audit;
            this.tim = tim;
            this.grou = grou;
        }



    }
}
