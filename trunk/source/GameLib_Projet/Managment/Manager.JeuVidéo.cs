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
        /// Jeu Vidéo selectionné dans la liste des jeux vidéos dans la vue
        /// </summary>
        private JeuVidéo jeuVidéoSelectionné = null;

        public JeuVidéo JeuVidéoSelectionné
        {
            get { return jeuVidéoSelectionné; }
            set
            {
                jeuVidéoSelectionné = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nombre de jeux total dans l'application
        /// </summary>
        public int NombreJeux => ListeJeuxAux.Count;

        /// <summary>
        /// Tableau de tous les jeux vidéos pour la copie dans la liste auxiliaire
        /// </summary>
        public JeuVidéo[] ListeJeuxArray { get; set; }

        /// <summary>
        /// Liste de tous les jeux vidéos affichés dans la vue de l'application
        /// </summary>
        public List<JeuVidéo> ListeJeux { get; private set; }

        /// <summary>
        /// Liste de tous les jeux vidéos affichés dans la vue de l'application
        /// </summary>
        private ObservableCollection<JeuVidéo> listeJeuxAux;
        public ObservableCollection<JeuVidéo> ListeJeuxAux
        {
            get { return listeJeuxAux; }
            set
            {
                listeJeuxAux = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///  Méthode qui permet à l'administrateur d'ajouter un jeu de la liste de jeu
        /// </summary>
        /// <param name="jeuAAjouter">Jeu qui va être ajouté</param>
        /// <param name="utilisateur1">Utilisateur qui veut ajouter le jeu, normalement admin</param>
        public void AjouterJeu(JeuVidéo jeuAAjouter, UtilisateurConnecté utilisateur)
        {
            if (utilisateur is Administrateur)
            {
                ListeJeux.Add(jeuAAjouter);
                ListeJeuxAux.Add(jeuAAjouter);
            }

        }

        /// <summary>
        /// Méthode qui permet à l'administrateur de supprimer un jeu de la liste de jeu
        /// </summary>
        /// <param name="jeuASupprimer">Jeu qui va être supprimé</param>
        /// <param name="utilisateur1">Utilisateur qui veut supprimer le jeu, normalement admin</param>
        public void SupprimerJeu(JeuVidéo jeuASupprimer, UtilisateurConnecté utilisateur)
        {
            if (utilisateur is Administrateur)
            {
                ListeJeux.Remove(jeuASupprimer);
                ListeJeuxAux.Remove(jeuASupprimer);
            }

        }

        /// <summary>
        /// Méthode qui recherche un jeu grâce au nom rentré dans la barre de recherche de l'application sans avoir le nom complet
        /// </summary>
        /// <param name="nomJeu">Nom du jeu voulu</param>
        /// <returns>Le jeu recherché ou null si rien n'a été trouvé</returns>
        public JeuVidéo RechercherJeuTextBox(string nomJeu)
        {
            return ListeJeux.SingleOrDefault(jeu => jeu.Nom.StartsWith(nomJeu));
        }

        /// <summary>
        /// Méthode qui recherche un jeu et le renvoie seulement si le nom complet est le même
        /// </summary>
        /// <param name="nomJeu">Nom du jeu voulu</param>
        /// <returns>Le jeu recherché ou null si rien n'a été trouvé</returns>
        public JeuVidéo RechercherJeu(string nomJeu)
        {
            return ListeJeux.SingleOrDefault(jeu => jeu.Nom.Equals(nomJeu));
        }
    }
}
