using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class Violon : InstrumentCorde
    {
        public string[] nomViolon = ["Guarneri", "Stradivarius", "Amati", "Giuseppe"];
        Random random = new Random();

        public Violon() : base("", 500, 4) 
        {
            Nom = "Violon" + nomViolon[random.Next(0, 4)];
        }

        public string DeterminerNom() 
        {
            string nom = "";
            Random random = new Random();
            nom = nomViolon[random.Next(0, 4)];
            return nom;
        }

        public override string ToString()
        {
            return $"Instrument : Guitare {Nom}\nPrix : {Prix}\nInfo corde\nResistance : {InfoCorde.Resistance}\nDurabiliter : {InfoCorde.Durabiliter}";
        }
    }
}
