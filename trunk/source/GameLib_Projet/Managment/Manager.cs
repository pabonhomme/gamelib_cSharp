using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Modele;
using Persistance;

namespace Managment
{
    public class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructeur de Manager
        /// </summary>
        /// <param name="jeuVidéoDataManager">Objet contenant une collection de jeux-vidéos</param>
        /// <param name="utilisateurConnectéDataManager">Objet contenent une collection d'utilisateurs connectés</param>
        public Manager(IDataManager<JeuVidéo> jeuVidéoDataManager, IDataManager<UtilisateurConnecté> utilisateurConnectéDataManager)
        {
            JeuVidéoDataManager = jeuVidéoDataManager;
            UtilisateurConnectéDataManager = utilisateurConnectéDataManager;
            ListeJeux = new ObservableCollection<JeuVidéo>(JeuVidéoDataManager.GetAll());
            ListeUtilisateur = UtilisateurConnectéDataManager.GetAll().ToList();
        }

        public Manager()
        {

        }

        /// <summary>
        /// Jeu Vidéo selectionné dans la liste des jeux vidéos dans la vue
        /// </summary>
        private JeuVidéo jeuVidéoSelectionné = null;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public JeuVidéo JeuVidéoSelectionné
        {
            get { return jeuVidéoSelectionné;  }
            set
            {
                jeuVidéoSelectionné = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Collection de jeux-vidéos
        /// </summary>
        private IDataManager<JeuVidéo> JeuVidéoDataManager { get; set; }

        /// <summary>
        /// Collection d'utilisateurs
        /// </summary>
        private IDataManager<UtilisateurConnecté> UtilisateurConnectéDataManager { get; set; }

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
        public List<UtilisateurConnecté> ListeUtilisateur { get; private set; }

        /// <summary>
        /// Utilisateur courant de l'application
        /// </summary>
        private UtilisateurConnecté utilisateurCourant = new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com") ;

        public UtilisateurConnecté UtilisateurCourant
        {
            get { return utilisateurCourant;  }
            set
            {
                utilisateurCourant = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Méthode qui ajoute un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur à ajouter</param>
        public void CréerUtilisateur(UtilisateurConnecté utilisateur)
        {
            utilisateur.CalculAge(utilisateur.DateNaissance);
            ListeUtilisateur.Add(utilisateur);
        }

        /// <summary>
        /// Méthode qui supprime un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur à supprimer</param>
        public void SupprimerUtilisateur(UtilisateurConnecté utilisateur)
        {
            if (utilisateur is Administrateur)
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
            if (utilisateur is Administrateur)
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

        /// <summary>
        /// Réécriture de la méthode toString
        /// </summary>
        /// <returns>Description du manager</returns>
        public override string ToString()
        {
            string appli;
            appli = $"Nombre de jeux : {NombreJeux}, Utilisateur courant : {UtilisateurCourant.Pseudo} \n";

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
