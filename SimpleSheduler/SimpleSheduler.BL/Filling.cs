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


        public object Clone()
        {

            T newValue = Value.Clone() as T;

            PossibleFilling[] newPossibleFillings = new PossibleFilling[PossibleFillings.Length];
            for (int i = 0; i < PossibleFillings.Length; i++)
            {
                newPossibleFillings[i] = PossibleFillings[i].Clone() as PossibleFilling;
            }
            Filling<T> newFilling = new Filling<T>(newValue, newPossibleFillings);
            return newFilling;

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
