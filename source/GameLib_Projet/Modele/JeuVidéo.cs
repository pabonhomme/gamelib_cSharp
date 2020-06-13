using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente un jeu vidéo de l'application
    /// </summary>
    public partial class JeuVidéo : IEquatable<JeuVidéo>, IComparable<JeuVidéo>, IComparable, INotifyPropertyChanged, ICloneable
    {
       
        /// <summary>
        /// Nom du jeu
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Note du jeu
        /// </summary>
        public int Note { get; set; }

        /// <summary>
        /// Prix du jeu
        /// </summary>
        public float Prix { get; set; }

        /// <summary>
        /// Description du jeu
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lien du trailer du jeu
        /// </summary>
        public string LienTrailer { get; set; }

        /// <summary>
        /// Lien de l'image du jeu
        /// </summary>
        private string lienImage;
        public string LienImage
        {
            get { return lienImage; }

            set
            {
                lienImage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Lien pour acheter jeu
        /// </summary>
        public string LienAchat { get; set; }

        /// <summary>
        /// Modèle économique du jeu
        /// </summary>
        public ModeleEco ModeleEco { get; set; }

        private string affichModeleEco;
        /// <summary>
        /// Méthode qui renvoie la propriété calculée affichModeleEco
        /// </summary>
        public string AffichModeleEco
        {
            get
            {
                if (ModeleEco == ModeleEco.Définitif)
                    affichModeleEco = "Achat définitif";
                if (ModeleEco == ModeleEco.Mensuel)
                    affichModeleEco = "Achat mensuel";
                if (ModeleEco == ModeleEco.Gratuit)
                    affichModeleEco = "Gratuit";

                return affichModeleEco;
            }

        }

        /// <summary>
        /// Nom du studio de dévelopement
        /// </summary>
        private string studioDev;
        public string StudioDev
        {
            get { return studioDev; }

            set
            {
                studioDev = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Précise si le jeu est ajouté en favori par l'utilisateur
        /// </summary>
        private bool estFavori = false;
        public bool EstFavori
        {
            get { return estFavori; }
            set
            {
                estFavori = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Genre du jeu
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Age minimum pour avoir le jeu du jeu
        /// </summary>
        public Pegi Pegi { get; set; }

        /// <summary>
        /// Lien de l'image âge minimum pegi
        /// </summary>
        public string LienPegi => GetLinkPegi(Pegi);

        /// <summary>
        /// Configuration minimale pour jouer au jeu
        /// </summary>
        public string ConfigMini { get; set; }

        /// <summary>
        /// Phrase pour la vue qui affiche toutes les plateformes
        /// </summary>
        private StringBuilder affichPlateFormes;

        /// <summary>
        /// Méthode qui renvoie la propriété calculée affichPlateForme
        /// </summary>
        public StringBuilder AffichPlateForme
        {
            get {
                affichPlateFormes = new StringBuilder();
                affichPlateFormes.Append("Ce jeu est disponible sur : ");
                foreach (PlateForme plateForme in ListePlateFormes)
                {
                    affichPlateFormes.AppendFormat("{0}, ", plateForme);
                }
                affichPlateFormes.Append("n'attendez pas !");
                return affichPlateFormes;
            }
        }

        /// <summary>
        /// Phrase pour la vue qui affiche le prix du jeu
        /// </summary>
        private StringBuilder affichPrix;

        /// <summary>
        /// Méthode qui renvoie la propriété 
        /// </summary>
        public StringBuilder AffichPrix
        {
            get
            {
                affichPrix = new StringBuilder();
                affichPrix.AppendFormat("Acheter dès {0}€", Prix);
                return affichPrix;
            }
        }



        /// <summary>
        /// Plate-formes où le jeu est disponible
        /// </summary>
        public List<PlateForme> ListePlateFormes { get; set; } = new List<PlateForme>();

        /// <summary>
        /// Evenement qui permet de signaler à la vue par un évenement qu'une propriété a changé
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui va tester si la propriété qui l'appelle a changé 
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom du jeu</param>
        /// <param name="note">Note du jeu</param>
        /// <param name="prix">Prix du jeu</param>
        /// <param name="description">Description du jeu</param>
        /// <param name="lienTrailer">Lien du trailer du jeu</param>
        /// <param name="lienImage">Lien de l'image du jeu</param>
        /// <param name="lienAchat">Lien pour acheter le jeu</param>
        /// <param name="modeleEco">Modèle économique du jeu</param>
        /// <param name="studioDev">Nom du studio de développement</param>
        /// <param name="configMini">Configuration minimale pour jouer au jeu</param>
        /// <param name="genre">Genre du jeu</param>
        /// <param name="pegi">Age minimum pour avoir le jeu du jeu</param>
        /// <param name="plateFormes">Plate-formes où le jeu est disponible</param>
        public JeuVidéo(string nom, int note, float prix, string description, string lienTrailer, string lienImage, string lienAchat, ModeleEco modeleEco, string studioDev, string configMini, Genre genre, Pegi pegi, List<PlateForme> plateFormes)
        {
            Nom = nom;
            Note = note;
            Prix = prix;
            Description = description;
            LienTrailer = lienTrailer;
            LienImage = lienImage;
            LienAchat = lienAchat;
            ModeleEco = modeleEco;
            StudioDev = studioDev;
            ConfigMini = configMini;
            Genre = genre;
            Pegi = pegi;
            ListePlateFormes = plateFormes;
        }
        
        public JeuVidéo()
        {
            Nom = string.Empty;
            Prix = 0;
            Description = string.Empty;
            LienTrailer = string.Empty;
            LienImage = string.Empty;
            LienAchat = string.Empty;
            StudioDev = string.Empty;
            ConfigMini = string.Empty;
        }

        private string GetLinkPegi(Pegi pegi)
        {
            if (pegi == Pegi.Trois)
            {
                return "Pegi3.jpg";
            }
            if (pegi == Pegi.Sept)
            {
                return "Pegi7.jpg";
            }
            if (pegi == Pegi.Douze)
            {
                return "Pegi12.jpg";
            }
            if (pegi == Pegi.Seize)
            {
                return "Pegi16.jpg";
            }
            if (pegi == Pegi.DixHuits)
            {
                return "Pegi18.png";
            }
            else return null;
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

            foreach (PlateForme plateForme in ListePlateFormes)
            {
                jeu += $"{plateForme}\n";
            }
            //jeu += AffichPlateForme;

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
            return Equals(jeuVidéo1, jeuVideo2);
        }

        /// <summary>
        /// Méthode qui réécrit l'opérateur !=
        /// </summary>
        /// <param name="jeuVidéo1">Jeu à comparer</param>
        /// <param name="jeuVidéo2">Jeu à comparer</param>
        /// <returns>true si différent et false sinon</returns>
        public static bool operator !=(JeuVidéo jeuVidéo1, JeuVidéo jeuVidéo2)
        {
            return !Equals(jeuVidéo1, jeuVidéo2);
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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
