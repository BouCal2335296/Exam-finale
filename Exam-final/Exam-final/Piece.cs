using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exam_final
{
    internal class Piece
    {
        public enum Difficulter
        {
            facile,
            moyen,
            difficile
        }

        public string Nom { get; set; }
        public Difficulter NvDifficulter { get; set; }
        public int Experience { get; set; }
        public int NvMinimum { get; set; }
        public int Prix { get; set; }

        public Piece()
        {
            Nom = "Piece aléatoire";
            NvDifficulter = Difficulter.facile;
            Experience = DeterminerExperience();
            NvMinimum = DeterminerNiveau();
            Prix = DeterminerPrix();
        }

        public int DeterminerExperience() 
        {
            int experience = 0;
            Random random = new Random();

            if (NvDifficulter == Difficulter.facile)
                experience = random.Next(10, 31);

            else if (NvDifficulter == Difficulter.moyen)
                experience = random.Next(60, 81);

            else if (NvDifficulter == Difficulter.difficile)
                experience = random.Next(100, 151);
            return experience;
        }

        public int DeterminerNiveau() 
        {
            int niveau = 0;

            if (NvDifficulter == Difficulter.facile)
                niveau = 1;
            else if (NvDifficulter == Difficulter.moyen)
                niveau = 3;
            else if (NvDifficulter == Difficulter.difficile)
                niveau = 5;
            return niveau;
        }

        public int DeterminerPrix() 
        {
            int prix = 0;

            if (NvDifficulter == Difficulter.facile)
                prix = 200;
            else if (NvDifficulter == Difficulter.moyen)
                prix = 400;
            else if (NvDifficulter == Difficulter.difficile)
                prix = 600;
            return prix;
        }

        public override string ToString()
        {
            return $"Nom : {Nom} --- Difficulter : {NvDifficulter} --- Expérience : {Experience} --- Niveau requis : {NvMinimum} --- Prix : {Prix}";
        }
    }
}
