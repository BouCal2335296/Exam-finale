using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class Corde
    {
        public int Resistance { get; set; }
        public int Durabiliter { get; set; }

        public Corde() 
        {
            Resistance = DeterminerResistance();
            Durabiliter = DeterminerDurabiliter(Resistance);
        }

        public int DeterminerResistance() 
        {
            Random random = new Random();
            int resistance = random.Next(1, 11);
            return resistance;
        }

        public int DeterminerDurabiliter(int resistance) 
        {
            int durabiliter = 0;

            durabiliter = resistance * 2;

            return durabiliter;
        }

        public override string ToString()
        {
            return $"Resistance : {Resistance} --- Durabiliter : {Durabiliter}";
        }
    }
}
