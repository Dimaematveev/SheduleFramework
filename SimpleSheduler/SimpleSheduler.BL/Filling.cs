using SimpleSheduler.BD;
using SimpleSheduler.BD.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    /// <summary>
    /// Заполнение по 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Filling<T> : IEnumerable where T : IName
    {
        public Filling(T value, PossibleFilling[] possibleFillings)
        {
            Value = value;
            PossibleFillings = possibleFillings;
        }

        public T Value { get; set; }
        public PossibleFilling[] PossibleFillings { get; set; }

        public IEnumerator GetEnumerator()
        {
            return PossibleFillings.GetEnumerator();
        }
        public PossibleFilling this[int index]
        {
            get
            {
                return PossibleFillings[index];
            }
            set
            {
                PossibleFillings[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return PossibleFillings.Length;
            }
        }
    }
}
