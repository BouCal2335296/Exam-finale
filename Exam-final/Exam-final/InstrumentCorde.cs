using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class InstrumentCorde
    {
        public string Nom { get; set; }
        public int Prix { get; set; }
        public List<Corde> Cordes { get; set; }
        public Corde InfoCorde { get; set; }

        public InstrumentCorde(string nom, int prix, int nbCorde) 
        {
            Nom = nom;
            Prix = DeterminerPrix();
            Cordes = new List<Corde>();
            InfoCorde = new Corde();
            AjouterCorde(nbCorde);
        }

        public int DeterminerPrix() 
        {
            int prix = 0;
            Random random = new Random();
            prix = random.Next(300, 6001);
            return prix;
        }

        public void AjouterCorde(int nbCorde) 
        {
            Random random = new Random();
            int cpt = 0;
            
            while (cpt >= nbCorde) 
            {
                Cordes.Add(new Corde());
                cpt++;
            }
        }

        public override string ToString()
        {
            return $"Nom : {Nom} --- Prix : {Prix} ---";
        }
    }
}
