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
    /// <summary>
    /// Permet le tri des jeux en fonction de divers critères (genre, limite d'âge, note, plateforme, favori)
    /// </summary>
    public static class Tris
    {
        /// <summary>
        /// Méthode qui tri ListeJeuxAux en fonction du genre rentré par l'utilisateur
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="listeJeuxAux"></param>
        /// <returns>Liste triée</returns>
        public static ObservableCollection<JeuVidéo> TriGenre(Genre genre, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Genre == genre).ToList()); //Retourne la listeJeuxAux trié par genre
        }
        /// <summary>
        /// Méthode qui tri ListeJeuxAux en fonction de la limite d'âge rentrée par l'utilisateur
        /// </summary>
        /// <param name="age"></param>
        /// <param name="listeJeuxAux"></param>
        /// <returns>Liste triée</returns>
        public static ObservableCollection<JeuVidéo> TriLimiteAge(Pegi age, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Pegi == age).ToList()); //Retourne la listeJeuxAux trié par limite d'âge
        }
        /// <summary>
        /// Méthode qui tri ListeJeuxAux en fonction de la note rentré par l'utilisateur
        /// </summary>
        /// <param name="note"></param>
        /// <param name="listeJeuxAux"></param>
        /// <returns>Liste triée</returns>
        public static ObservableCollection<JeuVidéo> TriNote(int note, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Note == note).ToList()); //Retourne la listeJeuxAux trié par note
        }
        /// <summary>
        /// Méthode qui tri ListeJeuxAux en fonction de la plateforme rentré par l'utilisateur
        /// </summary>
        /// <param name="plateForme"></param>
        /// <param name="listeJeuxAux"></param>
        /// <returns>Liste triée</returns>
        public static ObservableCollection<JeuVidéo> TriPlateForme(PlateForme plateForme, ObservableCollection<JeuVidéo> listeJeuxAux)
        {

            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.ListePlateFormes.Contains(plateForme)).ToList()); //Retourne la listeJeuxAux trié par plateforme
        }
        /// <summary>
        /// Méthode qui tri ListeJeuxAux en fonction des favoris de l'utilisateur
        /// </summary>
        /// <param name="favori"></param>
        /// <param name="listeJeuxAux"></param>
        /// <returns>Liste triée</returns>
        public static ObservableCollection<JeuVidéo> TriFavoris(bool favori, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.EstFavori == favori).ToList()); //Retourne la listeJeuxAux trié par favori
        }
    }
}
