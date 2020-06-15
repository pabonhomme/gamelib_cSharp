using System;
using Modele;
using System.Collections.Generic;

namespace Test_UtilisateurConnnecté
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test pour l'utilisateur connecté\n");

            UtilisateurConnecté utilisateur1 = new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com", new List<JeuVidéo>()) ;
            UtilisateurConnecté utilisateur2 = new Administrateur("Chevassus", "Noe", new DateTime(2001, 06, 21), "shotlouf", "MotDePasseNoe", "noe@orange.fr", new List<JeuVidéo>());
            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.99f, "Minecraft est un jeu vidéo de type « bac à sable » (construction complètement libre). Il s'agit d'un univers composé de voxels et généré aléatoirement, qui intègre un système d'artisanat axé sur l'exploitation puis la transformation de ressources naturelles (minéralogiques, fossiles, animales et végétales). ",
                 "https://youtu.be/MmB9b5njVbA",
                 AppDomain.CurrentDomain.BaseDirectory + "../../../img/Minecraft.jpg", "https://www.instant-gaming.com/fr/442-acheter-cle-minecraft/",
                ModeleEco.Définitif, AppDomain.CurrentDomain.BaseDirectory + "../../../img/mojang.png",
                "Configuration minimale : Intel Core i3-3210 / AMD A8-7600; AMD Radeon R5 / Nvidia Geforce 4xx; 4Go de RAM; 1Go d'Espace Disque; Windows 7/8/10",
                Genre.Aventure, Pegi.Trois, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.Xbox360, PlateForme.XboxOne });

            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 15.99f, "GTA V est un jeu en monde ouvert. Comprenez par là que le joueur peut aller où il veut quand il veut pour accomplir des missions ou simplement pour explorer les lieux et pratiquer plusieurs activités. Une liberté d’action que l’on retrouve au cœur même de l’aventure ; il est ainsi possible de remplir chaque mission de nombreuses manières. Au joueur de choisir son approche en choisissant la plus adaptée. L’objectif : organiser une série de braquages dont certains seront aussi épiques que dangereux. À chacun de définir son style et sa façon de procéder.",
                 "https://youtu.be/QkkoHAzjnUs",
                 AppDomain.CurrentDomain.BaseDirectory + "../../../img/GtaV.jpg", "https://www.instant-gaming.com/fr/186-acheter-cle-rockstar-grand-theft-auto-v/",
                 ModeleEco.Définitif, AppDomain.CurrentDomain.BaseDirectory + "../../../img/RockstarGames.png",
                 "Configuration minimale : Système d'exploitation : Windows 8.1 64 bits, Windows 8 64 bits, Windows 7 64 bits Service Pack 1 Processeur : Intel Core 2 Quad CPU Q6600 @ 2,40 GHz (4 CPUs) / AMD Phenom 9850 Quad-Core (4 CPUs) @ 2,5 GHz Mémoire : 4 Go Carte graphique : NVIDIA 9800 GT 1 Go / AMD HD 4870 1 Go (DX 10, 10.1, 11) Carte son : 100 % compatible avec DirectX 10 Espace disque dur : 65 Go",
                 Genre.Action, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.Xbox360, PlateForme.XboxOne, PlateForme.Ps3 });



            Console.WriteLine("Ajout en favoris de deux jeux\n");
            utilisateur1.AjouterFav(jeuvidéo1);
            utilisateur1.AjouterFav(jeuvidéo2);

            Console.WriteLine(utilisateur1);

            Console.WriteLine("\nSuppression des favoris du deuxiemes jeu\n");
            utilisateur1.SupprimerFav(jeuvidéo2);

            Console.WriteLine(utilisateur1);

            Console.WriteLine("\nTest des protocoles d'égalités\n");
            if (utilisateur1 == utilisateur2)
            {
                Console.WriteLine("Message s'ils sont égaux avec test ==");
            }
            if (utilisateur1.Equals(utilisateur1))
            {
                Console.WriteLine("Message s'ils sont égaux avec test equals");
            }
        }
    }
}
