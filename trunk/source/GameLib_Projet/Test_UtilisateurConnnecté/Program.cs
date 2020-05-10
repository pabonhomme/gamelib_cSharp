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

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", "imgMinecraft.bin", "Achat définitif", "Mojeig", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne});

            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", "imgGTA5.bin", "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 });

            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo2);



            Console.WriteLine(utilisateur1);

        }
    }
}
