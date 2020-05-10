using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class JeuVidéo
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






    }
}
