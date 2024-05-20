using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class Guitare : InstrumentCorde
    {
        enum TypeG
        {
            Acousitque,
            Basse,
            Electrique
        }
        Random random = new Random();

        string[] nomGuitare = ["Accoustique", "Basse", "Electrique"];

        public Guitare() : base("", 600, 4)
        {
            Nom = "Guitar" + nomGuitare[random.Next(0, 3)];
        }

        public override string ToString()
        {
            return $"Instrument : Guitare {Nom}\nPrix : {Prix}\nInfo corde\nResistance : {InfoCorde.Resistance}\nDurabiliter : {InfoCorde.Durabiliter}";
        }
    }
}
