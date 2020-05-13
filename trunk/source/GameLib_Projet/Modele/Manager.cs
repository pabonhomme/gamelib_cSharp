using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public class Manager
    {
        public Manager()
        {
            ListeJeux = new ObservableCollection<JeuVidéo>()
            {
                new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", "/img/Minecraft.jpg", "Achat définitif", "Mojeig", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne}),

                 new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", "/img/gtaV.jpg", "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 })

        };
        }

        /// <summary>
        /// Nombre de jeux total dans l'application
        /// </summary>
        public int NombreJeux => ListeJeux.Count;

        /// <summary>
        /// Nombre d'utilisateur total dans l'application
        /// </summary>
        public int NombreUtilisateur => ListeUtilisateur.Count;

        /// <summary>
        /// Liste de tous les jeux vidéos contenus dans l'application
        /// </summary>
        public ObservableCollection<JeuVidéo> ListeJeux { get; private set; } 

        /// <summary>
        /// Liste de tous les utilisateurs contenus dans l'application
        /// </summary>
        public List<UtilisateurConnecté> ListeUtilisateur { get; private set; } = new List<UtilisateurConnecté>();

        /// <summary>
        /// Utilisateur courant de l'application
        /// </summary>
        public UtilisateurConnecté UtilisateurCourant { get; private set; }

        /// <summary>
        /// Méthode qui ajoute un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur à ajouter</param>
        public void CréerUtilisateur(UtilisateurConnecté utilisateur)
        {
            ListeUtilisateur.Add(utilisateur);
        }

        /// <summary>
        /// Méthode qui supprime un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur à supprimer</param>
        public void SupprimerUtilisateur(UtilisateurConnecté utilisateur)
        {
            if(utilisateur is Administrateur)
            {
                return;
            }
            else
            {
                ListeUtilisateur.Remove(utilisateur);
            }
        }

        /// <summary>
        /// Méthode de connexion à l'application
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui souhaite se connecter</param>
        /// <param name="motDePasseVerif">Mot de passe rentré par l'utilisateur lors de sa tentative de connexion</param>
        /// <returns></returns>
        public string Connexion(UtilisateurConnecté utilisateur, string motDePasseVerif)
        {
            if (utilisateur.MotDePasse == motDePasseVerif)
            {
                UtilisateurCourant = utilisateur;
                return "Connexion réussie";
            }
            else return "Connexion échouée";
        }

        /// <summary>
        /// Méthode qui recherche un utilisateur grâce au nom envoyé par l'application
        /// </summary>
        /// <param name="nomUtilisateur">Nom de l'utilisateur voulu</param>
        /// <returns>L'utilisateur recherché ou null si rien n'a été trouvé</returns>
        public UtilisateurConnecté RechercherUtilisateur(string pseudoUtilisateur)
        {
            
            foreach (UtilisateurConnecté utilisateur in ListeUtilisateur)
            {
                if (utilisateur.Pseudo == pseudoUtilisateur)
                {
                    return utilisateur;
                     
                }
            }
            return null;
        }


        /// <summary>
        ///  Méthode qui permet à l'administrateur d'ajouter un jeu de la liste de jeu
        /// </summary>
        /// <param name="jeuAAjouter">Jeu qui va être ajouté</param>
        /// <param name="utilisateur1">Utilisateur qui veut ajouter le jeu, normalement admin</param>
        public void AjouterJeu(JeuVidéo jeuAAjouter, UtilisateurConnecté utilisateur)
        {
            if(utilisateur is Administrateur)
            {
                ListeJeux.Add(jeuAAjouter);
            }

        }

        /// <summary>
        /// Méthode qui permet à l'administrateur de supprimer un jeu de la liste de jeu
        /// </summary>
        /// <param name="jeuASupprimer">Jeu qui va être supprimé</param>
        /// <param name="utilisateur1">Utilisateur qui veut supprimer le jeu, normalement admin</param>
        public void SupprimerJeu(JeuVidéo jeuASupprimer, UtilisateurConnecté utilisateur)
        {
            if (utilisateur is Administrateur)
            {
                ListeJeux.Remove(jeuASupprimer);
            }

        }

        /// <summary>
        /// Méthode qui recherche un jeu grâce au nom rentré dans la barre de recherche de l'application
        /// </summary>
        /// <param name="nomJeu">Nom du jeu voulu</param>
        /// <returns>L'Le jeu recherché ou null si rien n'a été trouvé</returns>
        public JeuVidéo RechercherJeu(string nomJeu)
        {
            
            foreach (JeuVidéo jeu in ListeJeux)
            {
                if (jeu.Nom == nomJeu)
                {
                    return jeu;
                }
            }
            return null;
        }
        
        public override string ToString()
        {
            string appli;
            appli =  $"Nombre de jeux : {NombreJeux}, Utilisateur courant : {UtilisateurCourant.Pseudo} \n";

            appli += "\nListe des jeux : \n\n";

            foreach (JeuVidéo jeu in ListeJeux)
            {
                if (NombreJeux == 0)
                {
                    appli += "Aucun jeux pour le moment dans l'application";
                }
                else { appli += $"{jeu}\n"; }
                
            }

            appli += "\nListe des utilisateurs : \n\n";
            foreach (UtilisateurConnecté user in ListeUtilisateur)
            {
                if (NombreUtilisateur == 0)
                {
                    appli += "Aucun utilisateurs enregistrés pour le moment dans l'application";
                }
                else { appli += $"{user}\n"; }
            }

            return appli;
        }
    }
}
