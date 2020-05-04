using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class JeuVidéo
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
        /// Surnom du jeu
        /// </summary>
        public string Surnom { get;  set; }

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
        public JeuVidéo(String nom, int note, float prix, String description, String lienTrailer, String lienImage, String modeleEco, string studioDev )
        {
            Nom = nom;
            Prix = prix;
            Note = note;
            Description = description;
            LienTrailer = lienTrailer;
            LienImage = lienImage;
            ModeleEco = modeleEco;
            StudioDev = studioDev;
            Surnom = string.Empty;
        }





    }
}
