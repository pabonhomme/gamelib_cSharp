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

namespace GameLib_Projet
{

    /// <summary>
    /// Logique d'interaction pour UC_CreationCompte.xaml
    /// </summary>
    public partial class UC_CreationCompte : UserControl
    {

        public Manager Manager => (Application.Current as App).Manager;

        public UtilisateurConnecté NouveauUtilisateur { get; set; }


        public UC_CreationCompte()
        {
            InitializeComponent();
            NouveauUtilisateur = new UtilisateurConnecté();
            DataContext = this;

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

        public event RoutedEventHandler CréerCompteClick
        {
            add
            {
                BoutonCréerCompte.Click += value;
            }
            remove
            {
                BoutonCréerCompte.Click -= value;
            }
        }
        private void PremierMotDePasseEvent(object sender, RoutedEventArgs e)
        {

            NouveauUtilisateur.MotDePasse = EmplacementMotDePassePremier.Password;

        }

        private void DeuxiemeMotDePasseEvent(object sender, RoutedEventArgs e)
        {



        }

        private void BoutonCréer_click(object sender, RoutedEventArgs e)
        {
            if (Manager.RechercherUtilisateur(NouveauUtilisateur.Pseudo) != null)
            {
                MessageBox.Show("Ce pseudo appartient déja à un utilisateur existant.", "Attention ce pseudo est déja utilisé", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }

            Manager.CréerUtilisateur(NouveauUtilisateur);
        }
    }

}
