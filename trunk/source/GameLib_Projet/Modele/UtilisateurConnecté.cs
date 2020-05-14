﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class UtilisateurConnecté : IEquatable<UtilisateurConnecté>, IComparable<UtilisateurConnecté>, IComparable
    {

        /// Nom de l'utilisateur
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Prénom de l'utilisateur
        /// </summary>
        public string Prénom { get; private set; }

        /// <summary>
        /// Age de l'utilisateur
        /// </summary>
        /// 
        public int Age { get; private set; }

        /// <summary>
        /// Date de naissance de l'utilisateur
        /// </summary>
        /// 
        public DateTime DateNaissance { get; private set; }

        /// <summary>
        /// Pseudo de l'utilisateur connecté
        /// </summary>
        public string Pseudo { get; private set; }

        /// <summary>
        /// Mot de passe de l'utilisateur connecté
        /// </summary>
        public string MotDePasse { get; private set; }

        /// <summary>
        /// Mail de l'utilisateur connecté
        /// </summary>
        public string Mail { get; private set; }

        /// <summary>
        /// Nombre de favoris de l'utilisateur connecté
        /// </summary>
        public int NombreFavoris => ListeFavoris.Count;

        /// <summary>
        /// Liste des favoris de l'utilisateur connecté
        /// </summary>
        public List<JeuVidéo> ListeFavoris { get; private set; } = new List<JeuVidéo>();

        /// <summary>
        /// Constructeur d'un utilisateur connecté
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="prénom">Prénom de l'utilisateur</param>
        /// <param name="dateNaissance">Age de l'utilisateur</param>
        /// <param name="pseudo">Pseudo de l'utilisateur</param>
        /// <param name="motDePasse">Mot de passe de l"utilisateur</param>
        /// <param name="mail">Mail de l'utilisateur</param>
        /// <param name="nombreFavoris">Nombre de favroi de l'utilisateur</param>
        public UtilisateurConnecté(string nom, string prénom, DateTime dateNaissance, string pseudo, string motDePasse, string mail)
        {
            Nom = nom;
            Prénom = prénom;
            DateNaissance = dateNaissance;
            Pseudo = pseudo;
            MotDePasse = motDePasse;
            Mail = mail;
            Age = CalculAge(DateNaissance);
        }

        /// <summary>
        /// Méthode qui calcul l'âge de l'utilisateur à partir de sa date de naissance
        /// </summary>
        /// <param name="dateNaissance">Date de naissance de l'utilisateur</param>
        /// <returns>Age de l'utilisateur</returns>
        private int CalculAge(DateTime dateNaissance)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateNaissance.Year;
            if (dateNaissance > now.AddYears(-age))
                age--;
            return age;
        }

        /// <summary>
        /// Méthode pour ajouter un favori à sa liste de favoris
        /// </summary>
        /// <param name="jeu">Jeu vidéo à ajouter en favori</param>
        public void AjouterFav(JeuVidéo jeuFav)
        {
            ListeFavoris.Add(jeuFav);
           
        }
        /// <summary>
        /// Méthode pour supprimer un favori de sa liste de favoris
        /// </summary>
        /// <param name="jeu">Jeu vidéo à supprimer</param>
        public void SupprimerFav(JeuVidéo jeuFav)
        {
            ListeFavoris.Remove(jeuFav);
           
        }


        public override string ToString()
        {
            string user;
          
            user = $"Nom : {Nom} Prénom : {Prénom} Age : {Age} Pseudo : {Pseudo} Mot de passe : {MotDePasse} Mail : {Mail} Nombre de favoris : {NombreFavoris} ";
            
            user += "\nListe des jeux favoris : \n";

            foreach (JeuVidéo jeu in ListeFavoris)
            {
                if (NombreFavoris == 0)
                {
                    user += "Aucun favoris pour le moment";
                }
                else { user += $"{jeu}\n"; }
               
            }
            return user;
        }

        /// <summary>
        /// Vérifie si l'objet obj est égal à cet utilisateur ou non
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'utilisateur</param>
        /// <returns>vrai si c'est égal et non si ce n'est pas le cas</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is UtilisateurConnecté))
            {
                return false;
            }
            return Equals((UtilisateurConnecté)obj);
        }

        /// <summary>
        /// Vérifie si l'utilisateur est égal à cet utilisateur
        /// </summary>
        /// <param name="autre">L'autre jeu-vidéo à comparer</param>
        /// <returns>vrai si c'est égal</returns>
        public bool Equals(UtilisateurConnecté autre)
        {
            return (this.Pseudo == autre.Pseudo);
        }

        /// <summary>
        /// Méthode qui réécrit l'opérateur ==
        /// </summary>
        /// <param name="user1">Utilisateur à comparer</param>
        /// <param name="user2">Utilisateur à comparer</param>
        /// <returns>true si égal et false sinon</returns>
        public static bool operator ==(UtilisateurConnecté user1, UtilisateurConnecté user2)
        {
            return user1.Equals(user2);
        }

        /// <summary>
        /// Méthode qui réécrit l'opérateur !=
        /// </summary>
        /// <param name="user1">Utilisateur à comparer</param>
        /// <param name="user2">Utilisateur à comparer</param>
        /// <returns>true si différent et false sinon</returns>
        public static bool operator !=(UtilisateurConnecté user1, UtilisateurConnecté user2)
        {
            return !user1.Equals(user2);
        }

        /// <summary>
        /// Réécriture getHashCode
        /// </summary>
        /// <returns>hashCode de pseudo</returns>
        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();

        }

        /// <summary>
        /// Compare l'instance actuelle avec un autre objet du même type
        /// </summary>
        /// <param name="other">Utilisateur à comparer</param>
        /// <returns>int superieur à 0 si cette instance suit other dans l'ordre de tri, inf à 0 sinon précède et 0 si même position</returns>
        public int CompareTo(UtilisateurConnecté other)
        {
            return Pseudo.CompareTo(other.Pseudo);
        }

        /// <summary>
        /// Compare l'instance actuelle avec un autre objet du même type
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>int superieur à 0 si cette instance suit other dans l'ordre de tri, inf à 0 sinon précède et 0 si même position</returns>
        int IComparable.CompareTo(object obj)
        {
            if(!(obj is UtilisateurConnecté))
            {
                throw new ArgumentException ("L'argument n'est pas un utilisateur connecté", "obj" );
            }
            UtilisateurConnecté autreUser = obj as UtilisateurConnecté;
            return this.CompareTo(autreUser);
        }
    }
}
