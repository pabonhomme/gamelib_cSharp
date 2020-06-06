using System;
using Managment;
using System.Collections.Generic;
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
using Modele;
using PageAccueil;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameLib_Projet
{

    /// <summary>
    /// Logique d'interaction pour UC_CreationCompte.xaml
    /// </summary>
    public partial class UC_CreationCompte : UserControl , INotifyPropertyChanged
    {

        public Manager Manager => (Application.Current as App).Manager;

        public static Navigator Navigator  => Navigator.GetInstance();

        private UtilisateurConnecté nouveauUtilisateur;

        public UtilisateurConnecté NouveauUtilisateur
        {
            get { return nouveauUtilisateur; }
            set
            {
                nouveauUtilisateur = value;
                OnPropertyChanged();
            }
        }

        public UC_CreationCompte()
        {
            InitializeComponent();
            
            DataContext = this;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChargementUcCréation(object sender, RoutedEventArgs e)
        {
            NouveauUtilisateur = new UtilisateurConnecté() { DateNaissance = DateTime.Today };
            EmplacementMotDePassePremier.Password = "";
            EmplacementMotDePasseDeuxieme.Password = "";
        }

        public event RoutedEventHandler DejàCrééClick
        {
            add
            {
                BoutonCompteExistant.Click += value;
            }
            remove
            {
                BoutonCompteExistant.Click -= value;
            }
        }

        public event RoutedEventHandler AnnulerCreationClick
        {
            add
            {
                BoutonAnnuler.Click += value;
            }
            remove
            {
                BoutonAnnuler.Click -= value;
            }
        }

        private void PremierMotDePasseEvent(object sender, RoutedEventArgs e)
        {

            NouveauUtilisateur.MotDePasse = EmplacementMotDePassePremier.Password;

        }

        private void DeuxiemeMotDePasseEvent(object sender, RoutedEventArgs e)
        {
            //string deuxiemeMdp = EmplacementMotDePasseDeuxieme.Password;
            //if (deuxiemeMdp != NouveauUtilisateur.MotDePasse)
            //{
            //    MessageBox.Show("Le mot de passe n'est pas le même que celui écrit précédemment", "Attention mot de passe différent", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void BoutonCréer_click(object sender, RoutedEventArgs e)
        {

            if (Manager.RechercherUtilisateur(NouveauUtilisateur.Pseudo) != null)
            {
                MessageBox.Show("Ce pseudo appartient déja à un utilisateur existant.", "Attention ce pseudo est déja utilisé", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                Manager.CréerUtilisateur(NouveauUtilisateur);                
                Navigator.NavigateTo("UC_Connexion");
            }
        }
    }

}
