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
    public static class Tris
    {
        public static ObservableCollection<JeuVidéo> TriGenre(Genre genre, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
           return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Genre == genre).ToList());
        }
        public static ObservableCollection<JeuVidéo> TriLimiteAge(Pegi age, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Pegi == age).ToList());
        }
        public static ObservableCollection<JeuVidéo> TriNote(int note, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.Note == note).ToList());
        }
        public static ObservableCollection<JeuVidéo> TriPlateForme(PlateForme plateForme, ObservableCollection<JeuVidéo> listeJeuxAux)
        {

            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.ListePlateFormes.Contains(plateForme)).ToList());
        }
        public static ObservableCollection<JeuVidéo> TriFavoris(bool favori, ObservableCollection<JeuVidéo> listeJeuxAux)
        {
            return listeJeuxAux = new ObservableCollection<JeuVidéo>(listeJeuxAux.Where(jeu => jeu.EstFavori == favori).ToList());
        }
    }
}
