using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance
{
    public class StubDataManager : IDataManager
    {


        public (IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés) ChargeDonnées()
        {
            List<JeuVidéo> listeJeuxStub = ChargeJeuVidéos();
            List<UtilisateurConnecté> listeUtilisateursStub = ChargeUtilisateursConnectés();
            return (listeJeuxStub.Select(m => m.Clone()).Cast<JeuVidéo>().AsEnumerable(), listeUtilisateursStub);
        }


        private List<JeuVidéo> ChargeJeuVidéos()
        {
            List<JeuVidéo> listeJeux = new List<JeuVidéo>()
            {
                new JeuVidéo("Minecraft", 4, 29.99f, "Minecraft est un jeu vidéo de type « bac à sable » (construction complètement libre). Il s'agit d'un univers composé de voxels et généré aléatoirement, qui intègre un système d'artisanat axé sur l'exploitation puis la transformation de ressources naturelles (minéralogiques, fossiles, animales et végétales). ",
                 "https://youtu.be/MmB9b5njVbA",
                 "Minecraft.jpg", "https://www.instant-gaming.com/fr/442-acheter-cle-minecraft/",
                 ModeleEco.Définitif,
                "mojang.png",
                "Configuration minimale : Intel Core i3-3210 / AMD A8-7600; AMD Radeon R5 / Nvidia Geforce 4xx; 4Go de RAM; 1Go d'Espace Disque; Windows 7/8/10",
                Genre.Aventure, Pegi.Sept, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.Xbox360, PlateForme.XboxOne }),

           new JeuVidéo("GTAV", 5, 15.99f, "GTA V est un jeu en monde ouvert. Comprenez par là que le joueur peut aller où il veut quand il veut pour accomplir des missions ou simplement pour explorer les lieux et pratiquer plusieurs activités. Une liberté d’action que l’on retrouve au cœur même de l’aventure ; il est ainsi possible de remplir chaque mission de nombreuses manières. Au joueur de choisir son approche en choisissant la plus adaptée. L’objectif : organiser une série de braquages dont certains seront aussi épiques que dangereux. À chacun de définir son style et sa façon de procéder.",
                "https://youtu.be/QkkoHAzjnUs",
                "GtaV.jpg", "https://www.instant-gaming.com/fr/186-acheter-cle-rockstar-grand-theft-auto-v/",
                 ModeleEco.Définitif,
                "RockstarGames.png",
                "Configuration minimale : Système d'exploitation : Windows 8.1 64 bits, Windows 8 64 bits, Windows 7 64 bits Service Pack 1 Processeur : Intel Core 2 Quad CPU Q6600 @ 2,40 GHz (4 CPUs) / AMD Phenom 9850 Quad-Core (4 CPUs) @ 2,5 GHz Mémoire : 4 Go Carte graphique : NVIDIA 9800 GT 1 Go / AMD HD 4870 1 Go (DX 10, 10.1, 11) Carte son : 100 % compatible avec DirectX 10 Espace disque dur : 65 Go",
                Genre.Action, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.Xbox360, PlateForme.XboxOne, PlateForme.Ps3 }),

           new JeuVidéo("Call of Duty Modern Warfare 3", 3, 13.99f, "Call of Duty : Modern Warfare 3 (Europe) pour PC est le troisième de la série Modern Warfare, le huitième de la franchise Call of Duty. C'est un jeu de tir à la première personne, avec, similaire aux autres jeux de la série, avec un décor de guerre, ou une série de décors et de lieux prenant place dans le monde entier. Vous et votre équipe êtes chargés de trouver l’ennemi et d'arrêter ses plans infâmes : vous devez d'abord l’éliminer et vous frayer un chemin à travers des hordes d'ennemis pour ce faire.",
                 "https://www.youtube.com/watch?v=coiTJbr9m04",
                 "CallOfDutyMW3.jpg", "https://www.instant-gaming.com/fr/61-acheter-cle-steam-call-of-duty-modern-warfare-3/",
                  ModeleEco.Définitif,
                 "InfinityWard.png",
                 "Configuration minimale : Système d'exploitation : Windows XP / Windows Vista / Windows 7 Processeur : Intel Core 2 Duo E6600 ou équivalent Memoire : 2 Go de RAM Carte graphique : Shader 3.0 ou mieux, NVIDIA GeForce 8600GT ou ATI Radeon X1950 Disque dur : 16 Go de libre",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps3, PlateForme.Xbox360 }),

           new JeuVidéo("Battlefield 5", 2, 16.24f, "Participez au plus grand conflit de l'Histoire avec Battlefield V. La licence revient aux sources et dépeint la Seconde Guerre mondiale comme jamais auparavant. Livrez des batailles multijoueur frénétiques et brutales aux côtés de votre escouade dans des modes imposants comme Grandes opérations et coopératifs comme Tir Groupé. Prenez part aux batailles méconnues de la Guerre avec les récits de guerre du mode solo. Combattez dans des environnements inédits et spectaculaires aux quatre coins du monde et découvrez le Battlefield le plus riche et le plus immersif à ce jour.",
                 "https://www.youtube.com/watch?v=fb1MR85XFOc",
                 "Battlefield5.jpg", "https://www.instant-gaming.com/fr/612-acheter-cle-origin-battlefield-5/",
                  ModeleEco.Définitif,
                 "Dice.png", "Configuration minimale : Processeur : (Intel) Core i5 6600K ou AMD FX-6350, Mémoire : 8 Go de RAM, Carte graphiques : Nvidia GeForce GTX 660 2GB ou AMD Radeon HD 7850 2GB, DirectX 11, Stockage : 50 Go, Système d'exploitation: Windows 7, Windows 8.1 et Windows 10 64 bits. Internet : 512 kbps mini.",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne }),
             new JeuVidéo("Spider-man ", 3, 14.99f, "Spider-Man est un jeu d'action sur PlayStation 4. Le Tisseur est de retour pour le plaisir des joueurs qui pourront alterner phases d'exploration en voltigeant de building en building, phases d’infiltration et affrontements contre les super-vilains comme Le Caïd, Vulture, Electro, Mister Negative, etc.",
                 "https://www.youtube.com/watch?v=q4GdJVvdxss",
                 "spiderman.jpeg", "https://www.instant-gaming.com/fr/3656-acheter-cle-playstation-marvels-spider-man-the-city-that-never-sleeps-ps4/",
                  ModeleEco.Définitif,
                 "InsomniacGames.png", "Il faut avoir au minimum une PS4 pour lancer le jeu.",
                 Genre.Aventure, Pegi.Seize, new List<PlateForme>() {PlateForme.Ps4}),

                new JeuVidéo("Counter Strike Global Offensive", 5, 14.99f, "Counter-Strike : Global Offensive est un FPS multijoueurs en ligne sur PC. Les anti-terroristes et les terroristes s'affrontent dans différents modes de jeu avec une trentaine d'armes différentes, sans compter les grenades.Un mode entraînement permet aux joueurs de s'habituer aux commandes.",
                 "https://www.youtube.com/watch?v=edYCtaNueQY",
                 "csgo.jpeg", "https://www.instant-gaming.com/fr/62-acheter-cle-steam-counter-strike-global-offensive-prime-status-upgrade/",
                  ModeleEco.Définitif,
                 "valve.png", "Système d'exploitation : Windows® 7/Vista/XP Processeur : Intel® Core™ 2 Duo E6600 ou AMD Phenom™ X3 8750 ou meilleur Mémoire vive : 2 GB de mémoire Graphiques : Carte graphique de 256 MB ou plus compatible DirectX 9 et Pixel Shader 3.0 DirectX : Version 9.0c Espace disque : 15 GB d'espace disque disponible",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>() {PlateForme.Pc}),

                new JeuVidéo("Call of Duty Modern Warfare", 3, 53.11f, "Counter-Strike : Global Offensive est un FPS multijoueurs en ligne sur PC. Les anti-terroristes et les terroristes s'affrontent dans différents modes de jeu avec une trentaine d'armes différentes, sans compter les grenades.Un mode entraînement permet aux joueurs de s'habituer aux commandes.",
                 "https://www.youtube.com/watch?v=bH1lHCirCGI",
                 "ModernWarfare.jpeg", "https://www.instant-gaming.com/fr/4394-acheter-cle-call-of-duty-modern-warfare/",
                  ModeleEco.Définitif,
                 "InfinityWard.png", "Système d'exploitation : Windows® 7 64-bit (SP1) or Windows® 10 64-bit Processeur : Intel® Core™ i3-4340 ou AMD FX-6300 Mémoire : 8GB RAM Carte graphique : NVIDIA® GeForce® GTX 670 / NVIDIA® GeForce® GTX 1650 ou AMD Radeon™ HD 7950 – DirectX 12.0 compatible system",
                 Genre.FPS, Pegi.DixHuits, new List<PlateForme>() {PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne}),

                 new JeuVidéo("World of Warcraft", 4, 11.99f, "World of Warcraft sur PC est un jeu de rôle massivement multijoueurs. Au sein du royaume d'Azeroth, rejoignez les forces de la Horde ou de l'Alliance. Créez votre personnage parmi huit races et neuf classes disponibles puis rejoignez ou fondez votre propre guilde. Fabriquez armes et armures et combattez seul ou en groupe face à des armées de démons et autres bestioles plus ou moins attrayante.",
                 "https://www.youtube.com/watch?v=vlVSJ0AvZe0",
                 "Wow.jpg", "https://www.instant-gaming.com/fr/803-acheter-cle-battlenet-world-of-warcraft-carte-30-jours/",
                  ModeleEco.Mensuel,
                 "Blizzard.png", "Système d'exploitation : Windows® 7 64 bits (avec les derniers service packs) Processeur : Intel® Core™ 2 Duo E6600 ou AMD Phenom™ 8750 Carte graphique : NVIDIA® GeForce® 8800 GT 512 Mo ou AMD Radeon™ HD 4850 512 Mo ou Intel® HD Graphics 4000 Mémoire : 2 Go de RAM (4 Go pour les cartes graphiques intégrées, comme les Intel HD Graphics series) Stockage : 5 Go d’espace disponible",
                 Genre.RPG, Pegi.Douze, new List<PlateForme>() {PlateForme.Pc}),

                new JeuVidéo("Mortal Kombat 11", 3, 14.84f, "Mortal Kombat 11 pour PC est un jeu de combat en 2.5D qui marque - comme son nom l'indique - vingt-sept années impressionnantes de Mortal Kombat. Cela offre non seulement aux joueurs un contenu riche (surtout aux nouveaux joueurs), mais cela signifie aussi que les développeurs ont accumulé beaucoup d’expérience et sont donc aujourd’hui capable de faire des jeux de combat fascinants et immersifs. Ce jeu en est la preuve vivante!",
                 "https://www.youtube.com/watch?v=bxFoRCvEjUA",
                 "MortalKombat11.jpg", "https://www.instant-gaming.com/fr/3339-acheter-cle-steam-mortal-kombat-11/",
                 ModeleEco.Définitif,
                 "NetherRealm.png", "OS: 64-bit Windows 7 / Windows 10 Architecture: 64 bits Processeurs :Intel Core i5-750, 2.66 GHz / AMD Phenom II X4 965, 3.4 GHz ou AMD Ryzen™ 3 1200, 3.1 GHz Mémoire: 8 Go RAM Carte graphique (AMD): AMD® Radeon™ HD 7950 ou AMD® Radeon™ R9 270 Carte graphique(NVIDIA): NVIDIA® GeForce™ GTX 670 ou NVIDIA® GeForce™ GTX 1050 DirectX: API 11",
                 Genre.Combat, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne, PlateForme.Switch }),

                new JeuVidéo("Fortnite", 2, 0f, "Fortnite Battle Royale sur PC est le mode JcJ à 100 joueurs de Fortnite, jouable totalement gratuitement. Une carte géante. Un bus de combat. Tout le système de construction de Fortnite, combiné à des batailles ultra intenses en JcJ. Le dernier survivant est le vainqueur.",
                 "https://www.youtube.com/watch?v=hHTE5xg9E-g",
                 "Fortnite.jpg", "https://www.epicgames.com/fortnite/fr/home",
                 ModeleEco.Gratuit,
                 "EpicGame.png","Carte Graphique Intel HD 4000 sur PC ou Intel Iris Pro 5200 sur Mac ; Processeur IntelCore i3 2,4 GHz ; Mémoire vive 4 Go de RAM ; Système d'exploitation Windows 7/8/10 64 bits ou macOS High Sierra (10.13.6+",
                 Genre.Combat, Pegi.Douze, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne, PlateForme.Switch }),

                new JeuVidéo("Civilization VI", 1, 8.49f, "Construisez une civilisation à partir d'un petit village ou d'une colonie jusqu'à l'apogée politique - essentiellement un jeu de société numérique dans lequel vous devez faire de votre empire un leader sur la scène mondiale grâce au commerce, aux affaires, aux batailles et bien plus. Le paysage affecte vos succès, la forêt, le désert et la toundra ayant tous leurs propres avantages et inconvénients pour le joueur, vous devrez donc adapter votre jeu pour tirer le meilleur parti de la région dans laquelle vous jouez.",
                 "https://www.youtube.com/watch?v=5KdE0p2joJw",
                 "CivilizationVI.jpg", "https://www.instant-gaming.com/fr/1437-acheter-cle-steam-civilization-vi/",
                 ModeleEco.Définitif,
                 "Firaxis.png","Système d'exploitation : Windows 7 64 bits / 8.1 64 bits / 10 64 bits ; Processeur : Intel Core i3 2,5 GHz ou AMD Phenom II 2,6 GHz ou supérieur ; Mémoire :  4 Go de RAM ; Disque dur : 13 Go ou plus ; Carte graphique : Carte graphique DirectX 11 de 1 Go (AMD 5570 ou Nvidia 450)",
                 Genre.Stratégie, Pegi.Douze, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne, PlateForme.Switch }),

                new JeuVidéo("Trackmania Stadium", 5, 6.18f, "Contrairement aux autres jeux de courses, dans TrackMania sur PC, seuls les meilleurs temps comptent, dans des circuits farfelus que vous aussi, vous pouvez créer. Vous ne pouvez pas envoyer vos concurrents dans le décor, seul notre niveau de conduite et notre expérience fait la différence. Loopings, virages serrés, rampes d'accélération... De nombreux éléments vous permettent de construire une infinité de circuits que vous pouvez ensuite échanger avec vos amis.",
                 "https://www.youtube.com/watch?v=P5Qnws7Njas",
                 "Trackmania.jpg", "https://www.instant-gaming.com/en/1544-buy-key-steam-trackmania%c2%b2-stadium/",
                 ModeleEco.Définitif,
                 "Nadeo.png","Système d'exploitation : Windows Vista SP2 / 7 / 8 / 10 ; Processeur : Dual core Intel ou AMD 2 GHz au minimum ; Mémoire vive : 2 Go de RAM ; Carte graphique : Carte 512 MB ou plus et compatible DirectX 10, ou Direct 11.",
                 Genre.Action, Pegi.Trois, new List<PlateForme>() { PlateForme.Pc }),

                 new JeuVidéo("Assassin's Creed Origin", 4, 12.99f, "Construisez une civilisation à partir d'un petit village ou d'une colonie jusqu'à l'apogée politique - essentiellement un jeu de société numérique dans lequel vous devez faire de votre empire un leader sur la scène mondiale grâce au commerce, aux affaires, aux batailles et bien plus. Le paysage affecte vos succès, la forêt, le désert et la toundra ayant tous leurs propres avantages et inconvénients pour le joueur, vous devrez donc adapter votre jeu pour tirer le meilleur parti de la région dans laquelle vous jouez.",
                 "https://www.youtube.com/watch?v=cK4iAjzAoas",
                 "AssassinCreedOrigin.jpg", "https://www.instant-gaming.com/fr/1843-acheter-cle-uplay-assassins-creed-origins/",
                 ModeleEco.Définitif,
                 "Ubisoft.png","OS : Windows 7 SP1, Windows 8.1, Windows 10 (versions 64-bit uniquement) ; PROCESSEUR : Intel Core i5-2400s 2.5 GHz ou AMD FX-6350 3.9 GHz ou équivalent ; CARTE GRAPHIQUE : NVIDIA GeForce GTX660 ou AMD R9 270 (2048 MB VRAM avec Shader Model 5.0 ou mieux) MÉMOIRE : 6GB Résolution : 720p / Réglages vidéo : Bas",
                 Genre.Aventure, Pegi.DixHuits, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne}),

                 new JeuVidéo("Fifa 20", 5, 17.99f, "FIFA 20 pour PC est le dernier né des nombreux jeux de la FIFA qui permettent aux joueurs d'affronter une équipe de football (qu'il s'agisse d'une toute nouvelle équipe non testée ou testée, ou d'une équipe immédiatement reconnaissable par tous ceux qui regardent la télévision le samedi après-midi) et de la faire passer en première division de la Ligue ou dans tout autre tournoi où elle veut tenter de se faire une place.",
                 "https://www.youtube.com/watch?v=vgQNOIhRsV4",
                 "Fifa20.jpg", "https://www.instant-gaming.com/fr/4502-acheter-cle-origin-fifa-20/",
                 ModeleEco.Définitif,
                 "EaSports.png","Système d’exploitation : Windows 7/8.1/10 – 64-Bit ; Processeur : AMD Phenom II X4 965, Intel Core i3-2100, ou équivalent ; RAM : 8 Go ; Carte graphique : AMD Radeon HD 7850 2GB, NVIDIA GTX 660 2GB ou équivalent ; Disque dur : Minimum 50 Go",
                 Genre.Sport, Pegi.Trois, new List<PlateForme>() { PlateForme.Pc, PlateForme.Ps4, PlateForme.XboxOne}),
        };



            return listeJeux;
        }

        private List<UtilisateurConnecté> ChargeUtilisateursConnectés()
        {
            List<UtilisateurConnecté> listeUtilisateurs = new List<UtilisateurConnecté>()
            {
                new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com", true, new List<JeuVidéo>()),
                new Administrateur("Chevassus", "Noe", new DateTime(2001, 06, 21), "shotlouf", "MotDePasseNoe", "noe@orange.fr",true, new List<JeuVidéo>()),
                new UtilisateurConnecté("Zemili", "Adel", new DateTime(2001, 12, 16), "adel88", "MotDePasseAdel", "adel@orange.fr",false, new List<JeuVidéo>()),
                new UtilisateurConnecté("Rigaud", "Zoé", new DateTime(2001, 01, 04), "zoezoe", "MotDePasseZoe", "zoe@orange.fr",false, new List<JeuVidéo>())

            };
            return listeUtilisateurs;
        }


        public void SauvegardeDonnées(IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés)
        {
            return;
        }
    }
}
