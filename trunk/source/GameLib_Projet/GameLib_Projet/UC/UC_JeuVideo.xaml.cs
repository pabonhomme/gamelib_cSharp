using Managment;
using Microsoft.VisualBasic;
using Modele;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour UC_JeuVideo.xaml
    /// </summary>
    public partial class UC_JeuVideo : UserControl
    {

        public Manager Manager => (Application.Current as App).Manager;



        public UC_JeuVideo()
        {
            InitializeComponent();
            DataContext = Manager;
        }

        /// <summary>
        /// Bouton avec le logo youtube dans UC_JeuVidéo permettant d'ouvrir la page youtube du trailer du jeu correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonTrailer_Click(object sender, RoutedEventArgs e)
        {
            // Ici on récupère le lien du trailer du jeu voulu et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Manager.JeuVidéoSelectionné.LienTrailer, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Bouton d'achat du jeu permettant d'ouvrir la page d'achat du jeu correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAchat_Click(object sender, RoutedEventArgs e)
        {
            // Ici on récupère le lien du trailer du jeu voulu et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Manager.JeuVidéoSelectionné.LienAchat, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Bouton permettant de supprimer le jeu correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonSupprimer_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes vous sûr de vouloir supprimer ce jeu ?", "Attention suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.OK)
            {
                Manager.SupprimerJeu(Manager.JeuVidéoSelectionné, Manager.UtilisateurCourant);
            }
            return;
        }

        /// <summary>
        /// Bouton permettant l'ajout en favori du jeu correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonFavori_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.JeuVidéoSelectionné.EstFavori != true) //Teste si le bouton est décoché puiqu'avec le binding estFavori du code XAML, il renvoie false
            {
                Manager.UtilisateurCourant.SupprimerFav(Manager.JeuVidéoSelectionné);
                Manager.VerifFavoris();
                //Manager.SauvegardeDonnées();
            }
            else
            {
                Manager.UtilisateurCourant.AjouterFav(Manager.JeuVidéoSelectionné);
                Manager.VerifFavoris();
                //Manager.SauvegardeDonnées();
            }

        }
    }




}