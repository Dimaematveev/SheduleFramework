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
        public List<IStudent> Students { get; set; }
        public int NumberOfStutents { get => Students.Count; }
        public int Cours { get; set; }
        public string Seminar { get; set; }
        public TypeStudy TypeOfTraining { get; set; }
        

        public Group(   string nameGroup,
                        List<IStudent> students, 
                        int cours, 
                        string seminar, 
                        TypeStudy typeOfTraining)
        {

            if (string.IsNullOrWhiteSpace(nameGroup))
            {
                throw new ArgumentNullException("Имя группы не должно быть пустым!", nameof(nameGroup));
            }
            if (students.Count<= 0 || students == null)
            {
                throw new ArgumentNullException($"Количество студентов в группе должно быть больше нуля!",nameof(students));
            }
            if (cours < 1 || cours>5)
            {
                throw new ArgumentException($"Курс должен быть больше нуля и не превышать 5!", nameof(cours));
            }
            if (string.IsNullOrWhiteSpace(seminar))
            {
                throw new ArgumentNullException("Семинар не должен быть пустым.", nameof(seminar));
            }
            NameGroup = nameGroup;
            Students = students;
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
