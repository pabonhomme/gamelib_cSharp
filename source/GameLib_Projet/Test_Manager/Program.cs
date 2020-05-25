﻿using System;
using Modele;
using Managment;
using System.Collections.Generic;

namespace Test_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe Application\n\n");

            Manager mngr = new Manager();

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.99f, "Minecraft est un jeu vidéo de type « bac à sable » (construction complètement libre). Il s'agit d'un univers composé de voxels et généré aléatoirement, qui intègre un système d'artisanat axé sur l'exploitation puis la transformation de ressources naturelles (minéralogiques, fossiles, animales et végétales). ",
                 "https://youtu.be/MmB9b5njVbA",
                 AppDomain.CurrentDomain.BaseDirectory + "../../../img/Minecraft.jpg",
                "Achat définitif", AppDomain.CurrentDomain.BaseDirectory + "../../../img/mojang.png", "Configuration minimale : Intel Core i3-3210 / AMD A8-7600; AMD Radeon R5 / Nvidia Geforce 4xx; 4Go de RAM; 1Go d'Espace Disque; Windows 7/8/10", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne});

            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 15.99f, "GTA V est un jeu en monde ouvert. Comprenez par là que le joueur peut aller où il veut quand il veut pour accomplir des missions ou simplement pour explorer les lieux et pratiquer plusieurs activités. Une liberté d’action que l’on retrouve au cœur même de l’aventure ; il est ainsi possible de remplir chaque mission de nombreuses manières. Au joueur de choisir son approche en choisissant la plus adaptée. L’objectif : organiser une série de braquages dont certains seront aussi épiques que dangereux. À chacun de définir son style et sa façon de procéder.",
                 "https://youtu.be/QkkoHAzjnUs", AppDomain.CurrentDomain.BaseDirectory + "../../../img/GtaV.jpg",
                 "Achat définitif", "Rockstar", "Configuration minimale : Intel Core i3-3210 / AMD A8-7600; AMD Radeon R5 / Nvidia Geforce 4xx; 4Go de RAM; 1Go d'Espace Disque; Windows 7/8/10", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 });


            Console.WriteLine("Création des utilisateurs\n\n");
            mngr.CréerUtilisateur(new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com"));
            mngr.CréerUtilisateur(new UtilisateurConnecté("Chevassus", "Noe", new DateTime(2001, 06, 21), "shotlouf", "MotDePasseNoe", "noe@orange.fr"));
            mngr.CréerUtilisateur(new UtilisateurConnecté("Zemili", "Adel", new DateTime(2001, 12, 16), "adel88", "MotDePasseAdel", "adel@orange.fr"));
            mngr.CréerUtilisateur(new UtilisateurConnecté("Rigaud", "Zoé", new DateTime(2001, 01, 04), "zoezoe", "MotDePasseZoe", "zoe@orange.fr"));

            mngr.ListeUtilisateur.Sort();
            Console.WriteLine("Pour vous connecter, veuillez renseigner votre mot de passe");
            Console.WriteLine(mngr.Connexion(mngr.RechercherUtilisateur("paul_b63"), Console.ReadLine()));

            Console.WriteLine("\n\nAjout des jeux à l'application\n\n");
            mngr.AjouterJeu(jeuvidéo1, mngr.UtilisateurCourant);
            mngr.AjouterJeu(jeuvidéo2, mngr.UtilisateurCourant);

            
            Console.WriteLine("Ajout d'un favori par l'utilisateur courant\n\n");
            mngr.UtilisateurCourant.AjouterFav(jeuvidéo2);

            Console.WriteLine("Description de l'application\n\n");
            Console.WriteLine(mngr);
            
        }
    }
}