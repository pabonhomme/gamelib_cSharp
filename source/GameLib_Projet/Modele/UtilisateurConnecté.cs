using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class UtilisateurConnecté
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

    }
}
