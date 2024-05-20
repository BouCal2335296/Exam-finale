using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class Musicien
    {
        public string Nom { get; set; }
        public string InstrumentPref { get; set; }
        public InstrumentCorde Instrument { get; set; }
        public int Niveau { get; set; }
        public int Experience { get; set; }
        public int Argent { get; set; }
        public Piece Piece { get; set; }

        public Musicien() 
        {
            Nom = "Calvin";
            InstrumentPref = "Guitare";
            Instrument = null;
            Niveau = 1;
            Experience = 1;
            Argent = 2500;
            Piece = new Piece();
        }

        public override string ToString()
        {
            return $"Nom : {Nom} --- Instrument : {Instrument.Nom} --- Niveau : {Niveau} --- Experience : {Experience} --- Argent : {Argent} \n\nPiece de départ :\n{Piece}";
        }
    }
}
