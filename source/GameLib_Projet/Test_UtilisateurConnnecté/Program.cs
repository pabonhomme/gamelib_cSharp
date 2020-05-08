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

            UtilisateurConnecté utilisateur1 = new UtilisateurConnecté("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "maellissdu63", "polo.clash@gmail.com");

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis une patate verte comme Minecraft", "oui.youtube.com", "img.bin", "Achat définitif", "Marloc", Genre.Aventure, Pegi.trois, PlateForme.Pc);

            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo1);


            Console.WriteLine(utilisateur1);

        }
    }
}
