using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente un administrateur de l'application
    /// </summary>
    [DataContract]
    public class Administrateur : UtilisateurConnecté
    {
        /// <summary>
        /// Constructeur de l'administrateur
        /// </summary>
        /// <param name="nom">Nom de l'admin</param>
        /// <param name="prénom">Prénom de l'admin</param>
        /// <param name="dateNaissance">Date de naissance de l'admin</param>
        /// <param name="pseudo">Pseudo de l'admin</param>
        /// <param name="motDePasse">Mot de passe de l'admin</param>
        /// <param name="mail">Mail de l'admin</param>
        public Administrateur(string nom, string prénom, DateTime dateNaissance, string pseudo, string motDePasse, string mail, bool isAdmin, List<JeuVidéo> listeFavoris) 
            : base(nom, prénom, dateNaissance, pseudo, motDePasse, mail, isAdmin, listeFavoris) 
        {
        }
    }
}
