﻿using System;
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
        public List<UtilisateurConnecté> ListeUtilisateur { get; private set; }

        /// <summary>
        /// Utilisateur courant de l'application
        /// </summary>
        private UtilisateurConnecté utilisateurCourant = null;

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
    }
}
