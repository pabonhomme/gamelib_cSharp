using System;
using Modele;
using System.Collections.Generic;

namespace Test_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe Application");

            Application appli = new Application();

            Administrateur admin1 = new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "maellissdu63", "polo.clash@gmail.com");
            UtilisateurConnecté utilisateur1 = new UtilisateurConnecté("Chevassus", "Noe", new DateTime(2001, 06, 23), "shotlouf", "zgegdu63", "noe@orange.fr");

            appli.AjouterJeu( new JeuVidéo("Minecraft", 4, 29.9f, "Je suis une patate verte comme Minecraft", "oui.youtube.com", "img.bin", "Achat définitif", "Marloc", Genre.Aventure, Pegi.trois, PlateForme.Pc), utilisateur1);

            Console.WriteLine(appli);

        }
    }
}
