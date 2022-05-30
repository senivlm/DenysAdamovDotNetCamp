using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Pair
    {
        private int _number;
        private int _frequence;

        public Pair(int number, int frequence)
        {
            _number = number;
            _frequence = frequence;
        }

        public int Number { get; set; }
        public int Frequence { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Pair pair2)
            {
                return Number == pair2.Number
                    && Frequence == pair2.Frequence;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{Number} - {Frequence}";
        }
    }
}
