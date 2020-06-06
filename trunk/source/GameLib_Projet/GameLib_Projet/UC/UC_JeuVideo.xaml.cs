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
        }
        private void BoutonTrailer_Click(object sender, RoutedEventArgs e)
        {
            // Ici on récupère le lien du trailer du jeu voulu et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Manager.JeuVidéoSelectionné.LienTrailer, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        private void BoutonAchat_Click(object sender, RoutedEventArgs e)
        {
            // Ici on récupère le lien du trailer du jeu voulu et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Manager.JeuVidéoSelectionné.LienAchat, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        private void BoutonSupprimer_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes vous sûr de vouloir supprimer ce jeu ?", "Attention suppression", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.OK)
            {
                Manager.SupprimerJeu(Manager.JeuVidéoSelectionné, Manager.UtilisateurCourant);
            }
            return;



        }

        private void BoutonFavori_Click(object sender, RoutedEventArgs e)
        {
            if(Manager.JeuVidéoSelectionné.EstFavori != true)
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