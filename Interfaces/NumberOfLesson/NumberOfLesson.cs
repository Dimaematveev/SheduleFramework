using Interface.Interface;
using NumberOfLesson.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfLesson
{
    /// <summary>
    /// Класс количества пар в семестр.
    /// </summary>
    public class NumberOfLesson : INumberOfLessonWithConsole
    {
        /// <value> Предмет. </value>
        public ISubject Subject { get; set; }
        /// <value> Количество пар за семестр. </value>
        public int NumberSubject { get; set; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="subject">Предмет.</param>
        /// <param name="numberSubject">Пар за семестр.</param>
        public NumberOfLesson(ISubject subject, int numberSubject)
        {
            if (subject==null)
            {
                throw new ArgumentNullException("Должен передаваться предмет, а не пустое значение.", nameof(subject));
            }
            if (numberSubject<=0)
            {
                throw new ArgumentException("Количество пар за семестр должно быть больше нуля.", nameof(numberSubject));
            }
            Subject = subject;
            NumberSubject = numberSubject;
        }
        /// <summary>
        /// Класс в строку.
        /// </summary>
        /// <returns>Строка.</returns>
        public override string ToString()
        {
            return $"{Subject.NameSubject} - {NumberSubject}";
        }
        /// <summary>
        /// Вывод на консоль.
        /// </summary>
        public void ToConsole()
        {
            Console.WriteLine(ToString());
        }
    }
}
