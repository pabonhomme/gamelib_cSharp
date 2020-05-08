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

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", "imgMinecraft.bin", "Achat définitif", "Mojeig", Genre.Aventure, Pegi.trois, PlateForme.Pc);
            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "Minecraft.youtube.com", "imgGTA5.bin", "Achat définitif", "Rockstar", Genre.Action, Pegi.dixHuits, PlateForme.Ps4);

            Administrateur admin1 = new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com");
            UtilisateurConnecté utilisateur1 = new UtilisateurConnecté("Chevassus", "Noe", new DateTime(2001, 06, 23), "shotlouf", "MotDePasseNoe", "noe@orange.fr");

            appli.AjouterJeu(jeuvidéo1, admin1);

            appli.AjouterJeu(jeuvidéo2, utilisateur1);


            Console.WriteLine(appli);

        }
    }
}
