using System;
using Modele;
using System.Collections.Generic;

namespace Test_UtilisateurConnnecté
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test pour l'utilisateur connecté");

            UtilisateurConnecté utilisateur1 = new UtilisateurConnecté("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com");

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", "imgMinecraft.bin", "Achat définitif", "Mojeig", Genre.Aventure, Pegi.trois, PlateForme.Pc);
            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "Minecraft.youtube.com", "imgGTA5.bin", "Achat définitif", "Rockstar", Genre.Action, Pegi.dixHuits, PlateForme.Ps4);

            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo1);


            Console.WriteLine(utilisateur1);

        }
    }
}
