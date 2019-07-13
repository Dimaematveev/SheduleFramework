using Interface.Interface;
using NumberOfLesson.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfLesson
{
    public class NumberOfLesson : INumberOfLessonWithConsole
    {
        public ISubject Subject { get; set; }
        public int NumberSubject { get; set; }

        public NumberOfLesson(ISubject subject, int numberSubject)
        {
            Subject = subject;
            NumberSubject = numberSubject;
        }
        public void ToConsole()
        {
            Console.WriteLine($"{Subject.NameSubject} - {NumberSubject}" );
        }
    }
}
