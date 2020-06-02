﻿using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance
{
    public class StubJeuVidéoDataManager : StubDataManager<JeuVidéo>
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public StubJeuVidéoDataManager()
        {
            MyCollection = new List<JeuVidéo>()
            {
                 new JeuVidéo("Minecraft", 4, 29.99f, "Minecraft est un jeu vidéo de type « bac à sable » (construction complètement libre). Il s'agit d'un univers composé de voxels et généré aléatoirement, qui intègre un système d'artisanat axé sur l'exploitation puis la transformation de ressources naturelles (minéralogiques, fossiles, animales et végétales). ",
                 "https://youtu.be/MmB9b5njVbA",
                 "Minecraft.jpg",  "https://www.instant-gaming.com/fr/442-acheter-cle-minecraft/",
                "Achat définitif",
                "mojang.png",
                "Configuration minimale : Intel Core i3-3210 / AMD A8-7600; AMD Radeon R5 / Nvidia Geforce 4xx; 4Go de RAM; 1Go d'Espace Disque; Windows 7/8/10",
                Genre.Aventure, Pegi.Trois, new List<PlateForme>(){ PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne}),

                 new JeuVidéo("GTAV", 5, 15.99f, "GTA V est un jeu en monde ouvert. Comprenez par là que le joueur peut aller où il veut quand il veut pour accomplir des missions ou simplement pour explorer les lieux et pratiquer plusieurs activités. Une liberté d’action que l’on retrouve au cœur même de l’aventure ; il est ainsi possible de remplir chaque mission de nombreuses manières. Au joueur de choisir son approche en choisissant la plus adaptée. L’objectif : organiser une série de braquages dont certains seront aussi épiques que dangereux. À chacun de définir son style et sa façon de procéder.",
                 "https://youtu.be/QkkoHAzjnUs",
                 "GtaV.jpg",  "https://www.instant-gaming.com/fr/186-acheter-cle-rockstar-grand-theft-auto-v/",
                 "Achat définitif",
                 "RockstarGames.png",
                 "Configuration minimale : Système d'exploitation : Windows 8.1 64 bits, Windows 8 64 bits, Windows 7 64 bits Service Pack 1 Processeur : Intel Core 2 Quad CPU Q6600 @ 2,40 GHz (4 CPUs) / AMD Phenom 9850 Quad-Core (4 CPUs) @ 2,5 GHz Mémoire : 4 Go Carte graphique : NVIDIA 9800 GT 1 Go / AMD HD 4870 1 Go (DX 10, 10.1, 11) Carte son : 100 % compatible avec DirectX 10 Espace disque dur : 65 Go",
                 Genre.Action, Pegi.DixHuits, new List<PlateForme>(){ PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 }),

                 new JeuVidéo("Call of Duty Modern Warfare 3", 3, 13.99f, "Call of Duty : Modern Warfare 3 (Europe) pour PC est le troisième de la série Modern Warfare, le huitième de la franchise Call of Duty. C'est un jeu de tir à la première personne, avec, similaire aux autres jeux de la série, avec un décor de guerre, ou une série de décors et de lieux prenant place dans le monde entier. Vous et votre équipe êtes chargés de trouver l’ennemi et d'arrêter ses plans infâmes : vous devez d'abord l’éliminer et vous frayer un chemin à travers des hordes d'ennemis pour ce faire.",
                 "https://www.youtube.com/watch?v=coiTJbr9m04",
                 "CallOfDutyMW3.jpg", "https://www.instant-gaming.com/fr/61-acheter-cle-steam-call-of-duty-modern-warfare-3/",
                 "Achat définitif",
                 "InfinityWard.png",
                 "Configuration minimale : Système d'exploitation : Windows XP / Windows Vista / Windows 7 Processeur : Intel Core 2 Duo E6600 ou équivalent Memoire : 2 Go de RAM Carte graphique : Shader 3.0 ou mieux, NVIDIA GeForce 8600GT ou ATI Radeon X1950 Disque dur : 16 Go de libre",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>(){ PlateForme.Pc, PlateForme.Ps3, PlateForme.Xbox360}),

                 new JeuVidéo("Battlefield 5", 2, 16.24f, "Participez au plus grand conflit de l'Histoire avec Battlefield V. La licence revient aux sources et dépeint la Seconde Guerre mondiale comme jamais auparavant. Livrez des batailles multijoueur frénétiques et brutales aux côtés de votre escouade dans des modes imposants comme Grandes opérations et coopératifs comme Tir Groupé. Prenez part aux batailles méconnues de la Guerre avec les récits de guerre du mode solo. Combattez dans des environnements inédits et spectaculaires aux quatre coins du monde et découvrez le Battlefield le plus riche et le plus immersif à ce jour.",
                 "https://www.youtube.com/watch?v=fb1MR85XFOc",
                 "Battlefield5.jpg", "https://www.instant-gaming.com/fr/612-acheter-cle-origin-battlefield-5/",
                 "Achat définitif",
                 "Dice.png", "Configuration minimale : Processeur : (Intel) Core i5 6600K ou AMD FX-6350, Mémoire : 8 Go de RAM, Carte graphiques : Nvidia GeForce GTX 660 2GB ou AMD Radeon HD 7850 2GB, DirectX 11, Stockage : 50 Go, Système d'exploitation: Windows 7, Windows 8.1 et Windows 10 64 bits. Internet : 512 kbps mini.",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>(){ PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne})
            };
        }

        public override IEnumerable<JeuVidéo> GetAll()
        {
            return MyCollection.Select(m => m.Clone()).Cast<JeuVidéo>().AsEnumerable();
        }

        /// <summary>
        /// Méthode qui récupère le jeu-vidéo dont le nom est rentré en paramètre
        /// </summary>
        /// <param name="nom">Nom du jeu-vidéo voulu</param>
        /// <returns>Un jeu-vidéo</returns>
        public override JeuVidéo GetByName(string nom)
        {
            return MyCollection.Find(jeu => jeu.Nom.Equals(nom));
        }

    }
}
