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
        /// Variable qui contient les données
        /// </summary>
        public IDataManager DataManager { get; set; }

        /// <summary>
        /// Evenement qui permet de signaler à la vue par un évenement qu'une propriété a changé
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui va tester si la propriété qui l'appelle a changé 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Contructeur de manager
        /// </summary>
        /// <param name="dataManager">Données pour l'application</param>
        public Manager(IDataManager dataManager )
        {
            DataManager = dataManager;
            ChargeDonnées();
        }

        /// <summary>
        /// Constructeur sans paramètres
        /// </summary>
        public Manager()
        {

        }

        public void ChargeDonnées()
        {
            var données = DataManager.ChargeDonnées();
            foreach(var jeu in données.jeuVidéos)
            {
                ListeJeux.Add(jeu);
            }
            ListeJeux.Sort();
            ListeJeuxArray = new JeuVidéo[ListeJeux.Count()];
            for (int i = 0; i < ListeJeux.Count(); i++)
            {
                ListeJeuxArray[i] = ListeJeux[i].Clone() as JeuVidéo; //si vous avez implémenté ICloneable                                                                      
            }

            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxArray);

            foreach (var user in données.utilisateursConnectés)
            {
                ListeUtilisateur.Add(user);
            }
        }


        public void SauvegardeDonnées()
        {
            DataManager.SauvegardeDonnées(ListeJeux, ListeUtilisateur);
        }

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
