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
        public Manager(IDataManager dataManager)
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
        /// <summary>
        /// Méthode permettant de charger les données de l'application
        /// </summary>
        public void ChargeDonnées()
        {
            var données = DataManager.ChargeDonnées();
            foreach (var jeu in données.jeuVidéos)
            {
                ListeJeux.Add(jeu); //Ajoute les jeux chargés à la liste de jeux
            }
            ListeJeux.Sort(); //Trie la liste jeu par ordre alphabétique
            ListeJeuxArray = new JeuVidéo[ListeJeux.Count()]; //Instancie le tableau de tous les jeux vidéos(ListeJeuxArray) pour la copie
            for (int i = 0; i < ListeJeux.Count(); i++)
            {
                ListeJeuxArray[i] = ListeJeux[i].Clone() as JeuVidéo; // sélectionne tous les jeux de ListeJeux, les clonent et les mets dans le tableau ListeJeuxArray                                                                  
            }

            ListeJeuxAux = new ObservableCollection<JeuVidéo>(ListeJeuxArray); //Instancie la ListeJeuxAux qui sert pour les tris à partir du tableau ListeJeuxArray


            foreach (var user in données.utilisateursConnectés)
            {
                ListeUtilisateur.Add(user); //Ajoute les utilisateurs chargés à la liste d'utilisateur
            }
        }

        /// <summary>
        /// Méthode permettant la sauvegarde des données
        /// </summary>
        public void SauvegardeDonnées()
        {
            DataManager.SauvegardeDonnées(ListeJeux, ListeUtilisateur);
        }

        /// <summary>
        /// Méthode permettant de mettre à jour les jeux favoris de l'utilisateurs dans la listeJeuxAux qui sert pour les tris
        /// </summary>
        public void VerifFavoris()
        {
            foreach (UtilisateurConnecté user in ListeUtilisateur) //Pour tous les utilisatuers de la ListeUtilisateur
            {

                if (user.Equals(UtilisateurCourant)) //Si un des utilsiateur de la ListeUtilisateur est égal à l'utilisateur courant de l'appli
                {
                    user.ListeFavoris = UtilisateurCourant.ListeFavoris; //On récupère la liste de favoris de l'utilisateur courant
                    foreach (JeuVidéo jeuAux in ListeJeuxAux)
                    {
                        foreach (JeuVidéo jeuUser in UtilisateurCourant.ListeFavoris) //Pour tous les jeux vidéos de la liste favori de l'utilisateur courant
                        {

                            if (jeuUser.Equals(jeuAux)) //Si le jeu favori de l'utilisateur courant est égal au jeu vidéo de la ListeJeuAux
                            {
                                jeuAux.EstFavori = true; //On met les jeux de ListeJeuxAux en favori en fonction des favoris de l'utilisateur connecté
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
