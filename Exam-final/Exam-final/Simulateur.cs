using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_final
{
    internal class Simulateur
    {
        List<Piece> lstPiece = new List<Piece>();
        List<Piece> lstPiecePosseder = new List<Piece>();

        public void DemarerSimulation()
        {
            Musicien musicien = new Musicien();

            Console.WriteLine($"Nom : {musicien.Nom}\nNiveau : {musicien.Niveau}\nArgent : {musicien.Argent}\nInstrument : {musicien.Instrument}");
            Console.WriteLine("Appuyer sur une touche pour continuer");
            Console.ReadKey();
            DetermineInstrument(musicien);
        }

        public void DetermineInstrument(Musicien musicien)
        {
            Guitare guitare1 = new Guitare();
            Guitare guitare2 = new Guitare();
            Guitare guitare3 = new Guitare();
            Violon violon1 = new Violon();
            Violon violon2 = new Violon();

            if (guitare1.Prix > guitare2.Prix && guitare1.Prix > guitare3.Prix && guitare1.Prix > violon1.Prix && guitare1.Prix > violon2.Prix)
                musicien.Instrument = guitare1;
            if (guitare2.Prix > guitare1.Prix && guitare2.Prix > guitare3.Prix && guitare2.Prix > violon1.Prix && guitare2.Prix > violon2.Prix)
                musicien.Instrument = guitare2;
            if (guitare3.Prix > guitare1.Prix && guitare3.Prix > guitare2.Prix && guitare3.Prix > violon1.Prix && guitare3.Prix > violon2.Prix)
                musicien.Instrument = guitare3;
            if (violon1.Prix > guitare1.Prix && violon1.Prix > guitare2.Prix && violon1.Prix > guitare3.Prix && violon1.Prix > violon2.Prix)
                musicien.Instrument = violon1;
            if (violon2.Prix > guitare1.Prix && violon2.Prix > guitare2.Prix && violon2.Prix > guitare3.Prix && violon2.Prix > violon1.Prix)
                musicien.Instrument = violon2;

            Console.WriteLine($"{musicien.Nom} détient maintenant : {musicien.Instrument.Nom}");
            Console.WriteLine($"Appuyer sur une touche pour continuer");
            Console.ReadKey();
            AfficherInterface(musicien);
        }

        public void AfficherInterface(Musicien musicien)
        {
            int reponse = 0;
            do
            {
                Defi(musicien);
                Console.Clear();
                Console.WriteLine("Que souhaitez-vous faire ?");
                Console.WriteLine("1 - Voir le statut du musicien");
                Console.WriteLine("2 - Pratiquer");
                Console.WriteLine("3 - Réparer son instrument");
                Console.WriteLine("4 - Acheter une nouvelle pièce");
                Console.WriteLine("5 - Joueur pour un public");
                reponse = Convert.ToInt32(Console.ReadLine());

                switch (reponse)
                {
                    case 1:
                        AfficherStatutMusicien(musicien);
                        break;
                    case 2:
                        Pratiquer(musicien);
                        break;
                    case 3:
                        ReparerInstrument(musicien);
                        break;
                    case 4:
                        AcheterPiece(musicien);
                        break;
                    case 5:
                        break;
                }
            } while (reponse != 0);
        }

        public void AfficherStatutMusicien(Musicien musicien)
        {
            Console.WriteLine($"Nom : {musicien.Nom}\nNiveau : {musicien.Niveau}\nExpérience : {musicien.Experience}\nArgent : {musicien.Argent}\nInstrument : {musicien.Instrument}");
            Console.ReadKey();
        }

        public void Pratiquer(Musicien musicien)
        {
            int cpt = 0;
            int reponse = 0;

            foreach (Piece piece in lstPiecePosseder)
            {
                Console.WriteLine($"{cpt} - {piece}");
                cpt++;
            }
            if (lstPiecePosseder.Count == 0)
            {
                Console.WriteLine($"Vous ne posseder pas de piece");
            }
            else
            {
                Console.WriteLine($"\n Choisir la piece");
                reponse = Convert.ToInt32(Console.ReadLine());

                if (musicien.Instrument.InfoCorde.Durabiliter > 0)
                {
                    musicien.Experience += lstPiece[reponse].Experience;
                    musicien.Instrument.InfoCorde.Durabiliter -= 2;
                    Console.WriteLine($"Vous venez de vous pratiquer !!");
                    Console.WriteLine($"\nMaintenant votre expérience est de {musicien.Experience}");
                }
                else
                    Console.WriteLine($"Votre corde n'a plus de durabiliter");
            }

            Console.ReadKey();
        }

        public void ReparerInstrument(Musicien musicien)
        {
            if (musicien.Instrument.InfoCorde.Durabiliter <= 0)
            {
                musicien.Instrument.InfoCorde.Durabiliter += 20;
                Console.WriteLine($"Votre corde est réparer");
            }
            else
                Console.WriteLine($"Il reste encore de la durabiliter à votre équipement");
            Console.ReadKey();
        }

        public void AcheterPiece(Musicien musicien)
        {
            lstPiece.Add(new Piece());
            lstPiece.Add(new Piece());
            lstPiece.Add(new Piece());
            int cpt = 0;
            int reponse = 0;

            foreach (Piece piece in lstPiece)
            {
                Console.WriteLine($"{cpt} - {piece}");
                cpt++;
            }

            Console.WriteLine($"Qu'elle piece souhaitez-vous acheter ?");
            reponse = Convert.ToInt32(Console.ReadLine());

            if (musicien.Argent >= lstPiece[reponse].Prix)
            {
                lstPiecePosseder.Add(lstPiece[reponse]);
                musicien.Argent -= lstPiece[reponse].Prix;
                Console.WriteLine($"Vous venez d'acquérir la pièce nommé {lstPiece[reponse].Nom}");
            }
            else
                Console.WriteLine($"Pas assez d'argent");
            Console.ReadKey();
        }

        public void JoueurDevantPublic(Musicien musicien)
        {
            int cpt = 0;
            int reponse = 0;

            foreach (Piece piece in lstPiece)
            {
                Console.WriteLine($"{cpt} - {piece}");
                cpt++;
            }
            Console.WriteLine($"\n Choisir la piece");
            reponse = Convert.ToInt32(Console.ReadLine());

            if (musicien.Instrument.InfoCorde.Durabiliter > 0)
            {
                musicien.Experience += lstPiece[reponse].Experience;
                musicien.Instrument.InfoCorde.Durabiliter -= 2;
                musicien.Argent += lstPiece[reponse].NvMinimum * lstPiece[reponse].Prix;
                Console.WriteLine($"Vous venez de vous pratiquer !!");
                Console.WriteLine($"\nMaintenant votre expérience est de {musicien.Experience}");
            }
            else
                Console.WriteLine($"Votre corde n'a plus de durabiliter");

            Console.ReadKey();
        }

        public void Defi(Musicien musicien) 
        {
            Random random = new Random();
            int chance = random.Next(0, 101);

            if (chance >= 90) 
            {
                musicien.Niveau = 5;
            }
        }
    }
}
