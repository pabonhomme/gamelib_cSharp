using System;
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

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img\\Minecraft.jpg",
                "Achat définitif", AppDomain.CurrentDomain.BaseDirectory + "../../../img\\mojang.png", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne});

            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img/gtaV.jpg",
                 "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 });

            JeuVidéo jeuvidéo3 = new JeuVidéo("Call of Duty", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img/gtaV.jpg",
                 "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 });

            JeuVidéo jeuvidéo4 = new JeuVidéo("Fifa20", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img/gtaV.jpg",
                 "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
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
            mngr.AjouterJeu(jeuvidéo3, mngr.UtilisateurCourant);
            mngr.AjouterJeu(jeuvidéo4, mngr.UtilisateurCourant);
            /*
            Console.WriteLine("Ajout d'un favori par l'utilisateur courant\n\n");
            mngr.UtilisateurCourant.AjouterFav(jeuvidéo2);
*/
            Console.WriteLine("Description de l'application\n\n");
            Console.WriteLine(mngr);
            
        }
    }
}
