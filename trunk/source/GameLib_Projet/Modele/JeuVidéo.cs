using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class JeuVidéo : IEquatable<JeuVidéo>, IComparable<JeuVidéo>, IComparable
    {
       
        /// <summary>
        /// Nom du jeu
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Note du jeu
        /// </summary>
        public int Note { get; private set; }

        /// <summary>
        /// Prix du jeu
        /// </summary>
        public float Prix { get; private set; }

        /// <summary>
        /// Description du jeu
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Lien du trailer du jeu
        /// </summary>
        public string LienTrailer { get; private set; }

        /// <summary>
        /// Lien de l'image du jeu
        /// </summary>
        public string LienImage { get; private set; }

        /// <summary>
        /// Modèle économique du jeu
        /// </summary>
        public string ModeleEco { get; private set; }

        /// <summary>
        /// Nom du studio de dévelopement
        /// </summary>
        public string StudioDev { get; private set; }

        /// <summary>
        /// Genre du jeu
        /// </summary>
        public Genre Genre { get; private set; }

        /// <summary>
        /// Age minimum pour avoir le jeu du jeu
        /// </summary>
        public Pegi Pegi { get; private set; }

        /// <summary>
        /// Plate-formes où le jeu est disponible
        /// </summary>
        public List<PlateForme> ListePlateFormes { get; private set; } = new List<PlateForme>();


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom du jeu</param>
        /// <param name="note">Note du jeu</param>
        /// <param name="prix">Prix du jeu</param>
        /// <param name="description">Description du jeu</param>
        /// <param name="lienTrailer">Lien du trailer du jeu</param>
        /// <param name="lienImage">Lien de l'image du jeu</param>
        /// <param name="modeleEco">Modèle économique du jeu</param>
        /// <param name="studioDev">Nom du studio de développement</param> 
        /// <param name="genre">Genre du jeu</param>
        /// <param name="pegi">Age minimum pour avoir le jeu du jeu</param>
        /// <param name="plateFormes">Plate-formes où le jeu est disponible</param>
        public JeuVidéo(string nom, int note, float prix, string description, string lienTrailer, string lienImage, string modeleEco, string studioDev, Genre genre, Pegi pegi, List<PlateForme> plateFormes)
        {
            Nom = nom;
            Note = note;
            Prix = prix;
            Description = description;
            LienTrailer = lienTrailer;
            LienImage = lienImage;
            ModeleEco = modeleEco;
            StudioDev = studioDev;
            Genre = genre;
            Pegi = pegi;
            ListePlateFormes = plateFormes;
        }

        /// <summary>
        /// Réécriture de la méthode toString
        /// </summary>
        /// <returns>Description du Jeu-vidéo</returns>
        public override string ToString()
        {
            string jeu;
            jeu = $"Nom : {Nom} Note : {Note} Prix : {Prix} Description : {Description} Lien du trailer : {LienTrailer} Lien de l'image : {LienImage} Genre du jeu : {Genre} ";

            jeu += "\nListe des Plates formes où le jeu est disponible : \n";

            foreach (PlateForme plateForme in ListePlateFormes )
            {
                jeu += $"{plateForme}\n";
            }
            return jeu;
        }


        /// <summary>
        /// Vérifie si l'objet obj est égal à ce jeu-vidéo ou non
        /// </summary>
        /// <param name="obj">L'objet à comparer avec ce jeu-vidéo</param>
        /// <returns>vrai si c'est égal et non si ce n'est pas le cas</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is JeuVidéo))
            {
                return false;
            }
            return Equals((JeuVidéo)obj);
        }

        /// <summary>
        /// Vérifie si le jeu vidéo est égal à ce jeu-vidéo
        /// </summary>
        /// <param name="autre">L'autre jeu-vidéo à comparer</param>
        /// <returns>vrai si c'est égal</returns>
        public bool Equals(JeuVidéo autre)
        {
            return (this.Nom == autre.Nom);
        }

        /// <summary>
        /// Méthode qui réécrit l'opérateur ==
        /// </summary>
        /// <param name="jeuVidéo1">Jeu à comparer</param>
        /// <param name="jeuVideo2">Jeu à comparer</param>
        /// <returns>true si égal et false sinon</returns>
        public static bool operator ==(JeuVidéo jeuVidéo1, JeuVidéo jeuVideo2)
        {
            return jeuVidéo1.Equals(jeuVideo2);
        }

        /// <summary>
        /// Méthode qui réécrit l'opérateur !=
        /// </summary>
        /// <param name="jeuVidéo1">Jeu à comparer</param>
        /// <param name="jeuVidéo2">Jeu à comparer</param>
        /// <returns>true si différent et false sinon</returns>
        public static bool operator !=(JeuVidéo jeuVidéo1, JeuVidéo jeuVidéo2)
        {
            return !jeuVidéo1.Equals(jeuVidéo2);
        }

        /// <summary>
        /// Réécriture getHashCode
        /// </summary>
        /// <returns>hashCode de Nom</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();

        }

        /// <summary>
        /// Compare l'instance actuelle avec un autre objet du même type
        /// </summary>
        /// <param name="other">Jeu à comparer</param>
        /// <returns>int superieur à 0 si cette instance suit other dans l'ordre de tri, inf à 0 sinon précède et 0 si même position</returns>
        public int CompareTo(JeuVidéo other)
        {
            return Nom.CompareTo(other.Nom);
        }

        /// <summary>
        /// Compare l'instance actuelle avec un autre objet du même type
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>int superieur à 0 si cette instance suit other dans l'ordre de tri, inf à 0 sinon précède et 0 si même position</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is JeuVidéo))
            {
                throw new ArgumentException("L'argument n'est pas un jeu-vidéo", "obj");
            }
            JeuVidéo autreJeu = obj as JeuVidéo;
            return this.CompareTo(autreJeu);
        }


    }
}
