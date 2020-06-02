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
    public partial class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructeur de Manager
        /// </summary>
        /// <param name="jeuVidéoDataManager">Objet contenant une collection de jeux-vidéos</param>
        /// <param name="utilisateurConnectéDataManager">Objet contenent une collection d'utilisateurs connectés</param>
        public Manager(IDataManager<JeuVidéo> jeuVidéoDataManager, IDataManager<UtilisateurConnecté> utilisateurConnectéDataManager)
        {
            JeuVidéoDataManager = jeuVidéoDataManager;
            UtilisateurConnectéDataManager = utilisateurConnectéDataManager;
            ListeUtilisateur = UtilisateurConnectéDataManager.GetAll().ToList();
            ListeJeux = JeuVidéoDataManager.GetAll().ToList();
            ListeJeux.Sort();
            ListeJeuxArray = new JeuVidéo[ListeJeux.Count()];
            for (int i = 0; i < ListeJeux.Count(); i++)
            {
                ListeJeuxArray[i] = ListeJeux[i].Clone() as JeuVidéo; //si vous avez implémenté ICloneable                                                                      
            }
            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxArray);
            
        }

        public Manager()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Collection de jeux-vidéos
        /// </summary>
        private IDataManager<JeuVidéo> JeuVidéoDataManager { get; set; }

        /// <summary>
        /// Collection d'utilisateurs
        /// </summary>
        private IDataManager<UtilisateurConnecté> UtilisateurConnectéDataManager { get; set; }

        public void VerifFavoris()
        {

            foreach (UtilisateurConnecté user in ListeUtilisateur)
            {

                if (user.Equals(UtilisateurCourant))
                {
                    user.ListeFavoris = UtilisateurCourant.ListeFavoris;
                    foreach (JeuVidéo jeuAux in ListeJeuxAux)
                    {                        
                        foreach (JeuVidéo jeuUser in UtilisateurCourant.ListeFavoris)
                        {

                            if (jeuUser.Equals(jeuAux))
                            {
                                jeuAux.EstFavori = true;
                            }
                        }
                    }

                }
            }
            
        }

        /// <summary>
        /// Réécriture de la méthode toString
        /// </summary>
        /// <returns>Description du manager</returns>
        public override string ToString()
        {
            string appli;
            appli = $"Nombre de jeux : {NombreJeux}, Utilisateur courant : {UtilisateurCourant.Pseudo} \n";

            appli += "\nListe des jeux : \n\n";

            foreach (JeuVidéo jeu in ListeJeuxAux)
            {
                if (NombreJeux == 0)
                {
                    appli += "Aucun jeux pour le moment dans l'application";
                }
                else { appli += $"{jeu}\n"; }

            }

            appli += "\nListe des utilisateurs : \n\n";
            foreach (UtilisateurConnecté user in ListeUtilisateur)
            {
                if (NombreUtilisateur == 0)
                {
                    appli += "Aucun utilisateurs enregistrés pour le moment dans l'application";
                }
                else { appli += $"{user}\n"; }
            }

            return appli;
        }        
    }
}
