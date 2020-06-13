using Managment;
using Modele;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLib_Projet
{
    /// <summary>
    /// Logique d'interaction pour UC_Connexion.xaml
    /// </summary>
    public partial class UC_Connexion : UserControl , INotifyPropertyChanged
    {
        public Manager Manager => (Application.Current as App).Manager;

        public static Navigator Navigator => Navigator.GetInstance();

        /// <summary>
        /// nouveauUtilisateur
        /// </summary>
        private UtilisateurConnecté nouveauUtilisateurCourant;

        public UtilisateurConnecté NouveauUtilisateurCourant
        {
            get { return nouveauUtilisateurCourant; }
            set
            {
                nouveauUtilisateurCourant = value;
                OnPropertyChanged();
            }
        }

        private string messageEstConnecté;

        public string MessageEstConnecté
        {
            get { return messageEstConnecté; }
            set
            {
                messageEstConnecté = value;
                OnPropertyChanged();
            }
        }



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

        public UC_Connexion()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Méthode appelée lors du chargement de l'UC Connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChargementUcConnexion(object sender, RoutedEventArgs e)
        {
            NouveauUtilisateurCourant = new UtilisateurConnecté(); //Instancie un nouveauUtilisateurCourant null ce qui permet d'initialiser la textBox pseudo
            EmplacementMotDePasse.Password = ""; //Initialise le passwordBox mot de passe
        }

        /// <summary>
        /// PasswordChanged Event du textBox EmplacementMotDePasse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotDePasseEvent(object sender, RoutedEventArgs e)
        {

            NouveauUtilisateurCourant.MotDePasse = EmplacementMotDePasse.Password; //Récupère le mot de passe entré dans la texbox et le set comme celui de l'utilisateurCourant

        }

        /// <summary>
        /// Bouton de connexion présent dans l'UC_Connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            if (!Manager.Connexion(NouveauUtilisateurCourant)) //Si les infos entrées dans l'UC ne correspondent pas à un utilisateur de la ListeUtilisateur de GameLib
            {
                MessageBox.Show("Le pseudo ou le mot de passe est érroné, veuillez réessayer", "Attention identifiants invalides", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
                MessageBoxResult result = MessageBox.Show("Bienvenue sur votre application GameLib, vous êtes connecté", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK) //Si l'on clique sur le MessageBoxButton OK
                {
                    Navigator.NavigateTo("MainWindowUser"); //Navigue to l'UC MainWindowUser
                    MessageEstConnecté = Manager.ToAffichUtilisateurCourant(NouveauUtilisateurCourant);
                    Manager.ListeJeuxArray = new JeuVidéo[Manager.ListeJeux.Count()]; // Instancie le tableau de tous les jeux vidéos (ListeJeuxArray) pour la copie 
                    
                    for (int i = 0; i < Manager.ListeJeux.Count(); i++)
                    {
                        Manager.ListeJeuxArray[i] = Manager.ListeJeux[i].Clone() as JeuVidéo; //si vous avez implémenté ICloneable, sélectionne tous les jeux de ListeJeux, les clonent et les mets dans le tableaa ListeJeuxArray                                                                      
                    }
                    
                    Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>(Manager.ListeJeuxArray); //Instancie la ListeJeuxAux qui sert pour les tris à partir du tableau ListeJeuxArray
                    Manager.VerifFavoris(); //Mets à jour les jeux favoris de l'utilisateurs dans la listeJeuxAux qui sert pour les tris
                }
            }
        }

        /// <summary>
        /// Bouton permettant de naviguer vers l'UC MainWindowUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAnnulerConnexion_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("MainWindowUser");
        }

        /// <summary>
        /// Event pour le navigateur permettant de renvoyer sur l'UC CreationCompte
        /// </summary>
        public event RoutedEventHandler PremièreConnexionClick
        {
            add
            {
                BoutonPremièreConnexion.Click += value;
            }
            remove
            {
                BoutonPremièreConnexion.Click -= value;
            }
        }

    }
}
