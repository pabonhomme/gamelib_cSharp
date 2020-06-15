using Modele;
using Managment;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace GameLib_Projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Manager => (Application.Current as App).Manager;
        public static Navigator Navigator { get; set; } = Navigator.GetInstance();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// SelectionChanged de la combobox de Genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxGenre_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxGenre = (ComboBox)sender;
            if (ComboBoxGenre.SelectedItem == null)
            {
                ReinitialiserListeAux();
                return;
            }
            var GenreSelectionné = (ComboBoxItem)ComboBoxGenre.SelectedItem; //Prend l'élément sélectionné de la combobox
            var Content = (string)GenreSelectionné.Content; //Convertit le genreSelectionné en string

            Genre g = (Genre)Enum.Parse(typeof(Genre), Content); //Convertit le string en Enum Genre contenu dans la variable g
            Manager.ListeJeuxAux = Tris.TriGenre(g, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant le genre selectionné par l'utilisateur
            if (Manager.ListeJeuxAux.Count() == 0) //Si pas de jeux trouvé pour le genre sélectionné alors remise à 0 de la ListeJeuxAux
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// SelectionChanged de la combobox Limite d'âge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxLimiteAge_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxLimiteAge = (ComboBox)sender;
            if (ComboBoxLimiteAge.SelectedItem == null)
            {
                ReinitialiserListeAux();
                return;
            }
            var LimiteSelectionnée = (ComboBoxItem)ComboBoxLimiteAge.SelectedItem; //Prend l'élément sélectionné de la combobox

            if (LimiteSelectionnée == Pegi3)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Trois, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant Pegi3 selectionné par l'utilisateur
            }
            if (LimiteSelectionnée == Pegi7)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Sept, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant Pegi7 selectionné par l'utilisateur
            }
            if (LimiteSelectionnée == Pegi12)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Douze, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant Pegi12 selectionné par l'utilisateur
            }
            if (LimiteSelectionnée == Pegi16)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Seize, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant Pegi16 selectionné par l'utilisateur
            }
            if (LimiteSelectionnée == Pegi18)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.DixHuits, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant Pegi18 selectionné par l'utilisateur
            }
            if (Manager.ListeJeuxAux.Count() == 0) //Si pas de jeux trouvé pour le Pegi sélectionné alors remise à 0 de la ListeJeuxAux
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// SelectionChanged de la combobox Note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxNote_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxNote = (ComboBox)sender;
            if (ComboBoxNote.SelectedItem == null)
            {
                ReinitialiserListeAux();
                return;
            }

            var NoteSelectionné = (ComboBoxItem)ComboBoxNote.SelectedItem; //Prend l'élément sélectionné de la combobox
            var Content = (string)NoteSelectionné.Content; //Convertit l'élément sélectionné en string
            int note = int.Parse(Content); //Convertit le string  contenu dans la variable Content en int
            Manager.ListeJeuxAux = Tris.TriNote(note, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant la note selectionnée par l'utilisateur
            if (Manager.ListeJeuxAux.Count() == 0) //Si pas de jeux trouvé pour la note sélectionnée alors remise à 0 de la ListeJeuxAux
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// SelectionChanged de la combobox PlateForme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPlateForme_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxPlateForme = (ComboBox)sender;
            if (ComboBoxPlateForme.SelectedItem == null)
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                return;
            }

            var PlateFormeSelectionnée = (ComboBoxItem)ComboBoxPlateForme.SelectedItem; //Prend l'élément sélectionné de la combobox
            var Content = (string)PlateFormeSelectionnée.Content; //Convertit l'élement selectionné en string
            PlateForme plateForme = (PlateForme)Enum.Parse(typeof(PlateForme), Content); //Convertit le string Content en Enum Plateforme contenu dans la variable plateForme
            Manager.ListeJeuxAux = Tris.TriPlateForme(plateForme, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux possedant la PlateForme selectionnée par l'utilisateur
            if (Manager.ListeJeuxAux.Count() == 0) //Si pas de jeux trouvé pour la PlateForme sélectionnée alors remise à 0 de la ListeJeuxAux
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// Méthode Click qui met à jour la liste auxiliaire si la checkbox est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxFavoris_Click(object sender, RoutedEventArgs e)
        {

            if (CheckBoxFavoris.IsChecked == true) // vérifie si la textbox est cochée
            {

                Manager.ListeJeuxAux = Tris.TriFavoris(true, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux mis en favori par l'utilisateur connecté

                if (Manager.ListeJeuxAux.Count() == 0) // Si aucun jeu dans la liste de favoris alors message pr utilisateur disant qu'il faut qu'il en ajoute pr utiliser cette chekbox et remise à 0 de la liste auxiliaire
                {
                    ReinitialiserListeAux();
                    ReinitialiserCombobox();
                    MessageBox.Show("Vous n'avez pour l'instant ajouté aucun jeu à votre liste de favoris, veuillez en ajouter pour afficher votre liste de favori", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Information);
                    CheckBoxFavoris.IsChecked = false;
                }
            }
            else if (CheckBoxFavoris.IsChecked == false) // Affichage des jeux non-favoris
            {
                Manager.ListeJeuxAux = Tris.TriFavoris(false, Manager.ListeJeuxAux); //Mets dans la ListeJeuxAux, les jeux non favori de l'utilisateur connecté
            }

            if (Manager.ListeJeuxAux.Count() == 0)
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
            }

        }

        /// <summary>
        /// Bouton accueil permettant de naviguer à l'UC MainWindowUser, et réinitialise les combobox et la ListeJeuxAux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAccueil_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("MainWindowUser");
            ReinitialiserListeAux();
            ReinitialiserCombobox();
            Manager.JeuVidéoSelectionné = null;
        }

        /// <summary>
        /// Méthode permettant de réinitialiser la ListeJeuxAux
        /// </summary>
        private void ReinitialiserListeAux()
        {
            Manager.ListeJeuxArray = new JeuVidéo[Manager.ListeJeux.Count()]; // Instancie le tableau de tous les jeux vidéos (ListeJeuxArray) pour la copie 

            for (int i = 0; i < Manager.ListeJeux.Count(); i++)
            {
                Manager.ListeJeuxArray[i] = Manager.ListeJeux[i].Clone() as JeuVidéo; //car implémentation ICloneable, sélectionne tous les jeux de ListeJeux, les clonent et les mets dans le tableau ListeJeuxArray                                                                        
            }

            Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>(Manager.ListeJeuxArray); //Instancie la ListeJeuxAux qui sert pour les tris à partir du tableau ListeJeuxArray
            Manager.VerifFavoris(); //Mets à jour les jeux favoris de l'utilisateurs dans la listeJeuxAux qui sert pour les tris

        }

        /// <summary>
        /// Méthode permettant de réinitialiser les combobox
        /// </summary>
        private void ReinitialiserCombobox()
        {
            TextboxRechercheJeu.Text = "";
            ComboBoxGenre.SelectedValue = -1;
            ComboBoxLimiteAge.SelectedValue = -1;
            ComboBoxNote.SelectedValue = -1;
            ComboBoxPlateForme.SelectedValue = -1;
            CheckBoxFavoris.IsChecked = false;
        }

        /// <summary>
        /// Bouton de connexion permettant de naviguer vers l'UC_Connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_Connexion");
            Manager.JeuVidéoSelectionné = null;
        }

        /// <summary>
        /// Bouton d'ajout jeu permettant de naviguer vers l'UC_Ajoutjeu (visible uniquement si l'utilisateur est administrateur)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAjouterJeu_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_AjoutJeu");
            Manager.JeuVidéoSelectionné = null;
        }

        /// <summary>
        /// Evenement de la textBox de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TouchePresséeTextBoxRecherche_Event(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) //Si la touche pressée est la touche entrée
            {
                if (Manager.RechercherJeuTextBox(TextboxRechercheJeu.Text).Count() != 0) //Si des jeux sont trouvés concernant le texte rentré par l'utilisateur
                {
                    Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>(Manager.RechercherJeuTextBox(TextboxRechercheJeu.Text));
                }
                else
                {
                    MessageBox.Show("Aucun jeu ne correspond à votre recherche. Vérifiez qu'il n'y ai pas d'erreur dans le nom du jeu voulu et réessayez.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        /// <summary>
        /// Méthode click du BoutonYoutube permettant de lancer Youtube sur son navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonYoutube_Click(object sender, RoutedEventArgs e)
        {
            // Ici on met le lien de youtube et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = "https://www.youtube.com/", UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Méthode click du BoutonTwitch permettant de lancer Twitch sur son navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonTwitch_Click(object sender, RoutedEventArgs e)
        {
            // Ici on met le lien de twitch et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = "https://www.twitch.tv/", UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Méthode click du BoutonTwitter permettant de lancer Twitter sur son navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonTwitter_Click(object sender, RoutedEventArgs e)
        {
            // Ici on met le lien de twitter et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = "https://twitter.com/", UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Méthode click du BoutonInstagram permettant de lancer Instagram sur son navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonInstagram_Click(object sender, RoutedEventArgs e)
        {
            // Ici on met le lien d'instagram et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = "http://instagram.com/", UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Méthode click du BoutonFacebook permettant de lancer facebook sur son navigateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BoutonFacebook_Click(object sender, RoutedEventArgs e)
        {
            // Ici on met le lien de facebook et on lance le navigateur par défaut pour ouvrir le lien
            var info = new System.Diagnostics.ProcessStartInfo { FileName = "https://www.facebook.com/", UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }



    }
}