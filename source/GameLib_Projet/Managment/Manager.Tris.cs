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
        public void TriGenre(Genre genre)
        {
            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxAux.Where(jeu => jeu.Genre == genre).ToList()) ;
        }
        public void TriLimiteAge(Pegi age)
        {
            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxAux.Where(jeu => jeu.Pegi == age).ToList()) ;
        }
        public void TriNote(int note)
        {
            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxAux.Where(jeu => jeu.Note == note).ToList()) ;
        }
        public void TriPlateForme(PlateForme plateForme)
        {

            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxAux.Where(jeu => jeu.ListePlateFormes.Contains(plateForme)).ToList()) ;
        }
        public void TriFavoris(bool favori)
        {
            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxAux.Where(jeu => jeu.EstFavori == favori).ToList()) ;
        }
        
    }
}
