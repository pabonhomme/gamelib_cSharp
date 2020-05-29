using Managment;
using Modele;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UC_Connexion()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ChargementUcConnexion(object sender, RoutedEventArgs e)
        {
            nouveauUtilisateurCourant = new UtilisateurConnecté();
            EmplacementMotDePasse.Password = "";
        }

        private void MotDePasseEvent(object sender, RoutedEventArgs e)
        {

            NouveauUtilisateurCourant.MotDePasse = EmplacementMotDePasse.Password;

        }

        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            if (!Manager.Connexion(NouveauUtilisateurCourant))
            {
                MessageBox.Show("Le pseudo ou le mot de passe est érroné, veuillez réessayer", "Attention identifiants invalides", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Bienvenue sur votre application GameLib, vous êtes connecté", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    Navigator.NavigateTo("MainWindowUser");
                }
            }
        }


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
