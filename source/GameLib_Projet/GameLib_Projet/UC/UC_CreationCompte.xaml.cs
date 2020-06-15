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
    public partial class UC_CreationCompte : UserControl, INotifyPropertyChanged
    {

        public Manager Manager => (Application.Current as App).Manager;

        public static Navigator Navigator => Navigator.GetInstance();

        /// <summary>
        /// Nouvel utilisateur
        /// </summary>
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
        /// Méthode appelée lors du chargement de UC_CréationCompte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChargementUcCréation(object sender, RoutedEventArgs e)
        {
            NouveauUtilisateur = new UtilisateurConnecté() { DateNaissance = DateTime.Today };
            EmplacementMotDePassePremier.Password = "";
            EmplacementMotDePasseDeuxieme.Password = "";
        }

        /// <summary>
        /// Evenement appelé dans le navigator permettant de revenir sur l'UC_Connexion
        /// </summary>
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

        /// <summary>
        /// Evenement appelé dans le navigator permettant de revenir sur l'UC_Connexion
        /// </summary>
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

        /// <summary>
        /// Evenement qui fait référence à la première PassWordBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PremierMotDePasseEvent(object sender, RoutedEventArgs e)
        {

            NouveauUtilisateur.MotDePasse = EmplacementMotDePassePremier.Password;

        }

        /// <summary>
        /// Evenement qui fait référence à la deuxième PassWordBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeuxiemeMotDePasseEvent(object sender, RoutedEventArgs e)
        {

            return;

        }

        /// <summary>
        /// Méthode appelée lors du clique du bouton crée situé dans l'UC_CreationUtilisateur et qui permet de créer un NouveauUtilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonCréer_click(object sender, RoutedEventArgs e)
        {
            bool v = CreationObjectValidator.ValidationAjout(NouveauUtilisateur); //Met dans la variable v le résultat booleen de la méthode validationAjout qui return false si un des champs rentrés n'est pas valide

            if (v == false)
            {
                MessageBox.Show("Tous les champs ne sont pas valides. Veuillez réessayer", "Erreur création compte", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Manager.RechercherUtilisateur(NouveauUtilisateur.Pseudo) != null)
            {
                MessageBox.Show("Ce pseudo appartient déja à un utilisateur existant. Veuillez réessayer", "Attention ce pseudo est déja utilisé", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(NouveauUtilisateur.MotDePasse))
            {
                MessageBox.Show("Votre mot de passe n'est pas valide. Veuillez réessayer", "Mot de passe Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (EmplacementMotDePassePremier.Password != EmplacementMotDePasseDeuxieme.Password)
            {
                MessageBox.Show("Vos deux mots de passe ne correspondent pas. Veuillez réessayer", "Mot de passe Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (v == true)
            {
                Manager.CréerUtilisateur(NouveauUtilisateur);
                Navigator.NavigateTo("UC_Connexion");
            }





        }

    }
}
