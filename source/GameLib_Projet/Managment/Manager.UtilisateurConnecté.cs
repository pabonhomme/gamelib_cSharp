using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Modele;
using Persistance;

namespace Managment
{
    public partial class Manager
    {
        /// <summary>
        /// Nombre d'utilisateur total dans l'application
        /// </summary>
        public int NombreUtilisateur => ListeUtilisateur.Count;

        /// <summary>
        /// Liste de tous les utilisateurs contenus dans l'application
        /// </summary>
        public List<UtilisateurConnecté> ListeUtilisateur { get; private set; } = new List<UtilisateurConnecté>();

        /// <summary>
        /// Utilisateur courant de l'application
        /// </summary>
        private UtilisateurConnecté utilisateurCourant; /*= new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com",true, new List<JeuVidéo>());*/

        public UtilisateurConnecté UtilisateurCourant
        {
            get { return utilisateurCourant; }
            set
            {
                utilisateurCourant = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Méthode de connexion à l'application
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui souhaite se connecter</param>
        /// <returns>vrai si utilisateur trouvé sinon faux</returns>
        public bool Connexion(UtilisateurConnecté utilisateur)
        {
            if (RechercherUtilisateur(utilisateur.Pseudo) == null || RechercherUtilisateur(utilisateur.Pseudo).MotDePasse != utilisateur.MotDePasse)
            {
                return false;
            }
            else
            {
                UtilisateurCourant = RechercherUtilisateur(utilisateur.Pseudo);
                return true;
            }
        }

        /// <summary>
        /// Méthode qui ajoute un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur à ajouter</param>
        public void CréerUtilisateur(UtilisateurConnecté utilisateur)
        {
            ListeUtilisateur.Add(utilisateur);
            SauvegardeDonnées();
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
            SauvegardeDonnées();
        }

        /// <summary>
        /// Méthode qui recherche un utilisateur grâce au nom envoyé par l'application
        /// </summary>
        /// <param name="pseudoUtilisateur">Nom de l'utilisateur voulu</param>
        /// <returns>L'utilisateur recherché ou null si rien n'a été trouvé</returns>
        public UtilisateurConnecté RechercherUtilisateur(string pseudoUtilisateur)
        {

            return ListeUtilisateur.SingleOrDefault(user => user.Pseudo.Equals(pseudoUtilisateur));
        }

        /// <summary>
        /// Méthode permettant l'affichage de l'utilisateur courant
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ToAffichUtilisateurCourant(UtilisateurConnecté user)
        {
            if (user != null)
            {
                return $"Connecté en tant que { user.Pseudo}";

            }
            return string.Empty;
        }
    }
}