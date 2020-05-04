using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class UtilisateurConnecté
    {
        /// <summary>
        /// Contructeur
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur connecté</param>
        /// <param name="motDePasse">Mot de passe de l'utilisateur connecté</param>
        /// <param name="mail">Mail de l'utilisateur connecté</param>
        public UtilisateurConnecté(string pseudo, string motDePasse, string mail)
        {
            Pseudo = pseudo;
            MotDePasse = motDePasse;
            Mail = mail;
        }

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
        private List<JeuVidéo> ListeFavoris = new List<JeuVidéo>();

        /// <summary>
        /// Méthode pour ajouter un favori à sa liste de favoris
        /// </summary>
        /// <param name="jeu">Jeu vidéo à ajouter en favori</param>
        public void AjouterFav(JeuVidéo jeu)
        {
            ListeFavoris.Add(jeu);
        }
        /// <summary>
        /// Méthode pour supprimer un favori de sa liste de favoris
        /// </summary>
        /// <param name="jeu">Jeu vidéo à supprimer</param>
        public void SupprimerFav(JeuVidéo jeu)
        {
            ListeFavoris.Remove(jeu);
        }

        /// <summary>
        /// Méthode pour modifier le surnom du jeu
        /// </summary>
        /// <param name="jeu">Jeu à modifier</param>
        /// <param name="surnom">Surnom à insérer</param>
        /// <returns></returns>
        public string ModifSurnomJeu(JeuVidéo jeu, String surnom)
        {
            return jeu.Surnom = surnom;
        }







    }
}
