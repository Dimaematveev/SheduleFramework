using Group.Interfaces;
using Interface.Interface;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    public class Group : IGroupWithConsole
    {
        

        public string NameGroup { get; set; }
        public int NumberOfStutents { get; set; }
        public int Cours { get; set; }
        public string Seminar { get; set; }
        public TypeStudy TypeOfTraining { get; set; }

        public Group(   string nameGroup, 
                        int numberOfStutents, 
                        int cours, 
                        string seminar, 
                        TypeStudy typeOfTraining)
        {
            //TODO: Проверки на null
            NameGroup = nameGroup;
            NumberOfStutents = numberOfStutents;
            Cours = cours;
            Seminar = seminar;
            TypeOfTraining = typeOfTraining;
        }
        public void ToConsole()
        {
            Console.WriteLine(Seminar);
        }
    }
}
