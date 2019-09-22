using SimpleSheduler.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler.BL
{
    public class Filling<T> where T: BD.Model.IName
    {
        public Filling(T value, PossibleFilling[] possibleFillings)
        {
            Value = value;
            PossibleFillings = possibleFillings;
        }

        public T Value { get; set; }
        public PossibleFilling[] PossibleFillings { get; set; }

    }
}
