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

        private void ComboBoxGenre_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxGenre = (ComboBox)sender;
            if(ComboBoxGenre.SelectedItem == null)
            {
                ReinitialiserListeAux();
                return;
            }
            var GenreSelectionné = (ComboBoxItem)ComboBoxGenre.SelectedItem; //Prend l'élément sélectionné de la combobox
            var Content = (string) GenreSelectionné.Content;

            Genre g = (Genre)Enum.Parse(typeof(Genre), Content); //Convertit le string en Enum Genre contenu dans la variable g
            Manager.ListeJeuxAux =  Tris.TriGenre(g, Manager.ListeJeuxAux);
            if (Manager.ListeJeuxAux.Count() == 0)
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

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
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Trois, Manager.ListeJeuxAux); 
            }
            if (LimiteSelectionnée == Pegi7)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Sept, Manager.ListeJeuxAux);
            }
            if (LimiteSelectionnée == Pegi12)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Douze, Manager.ListeJeuxAux);
            }
            if (LimiteSelectionnée == Pegi16)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.Seize, Manager.ListeJeuxAux);
            }
            if (LimiteSelectionnée == Pegi18)
            {
                Manager.ListeJeuxAux = Tris.TriLimiteAge(Pegi.DixHuits, Manager.ListeJeuxAux);
            }
            if (Manager.ListeJeuxAux.Count() == 0)
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void ComboBoxNote_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxNote = (ComboBox)sender;
            if (ComboBoxNote.SelectedItem == null)
            {
                ReinitialiserListeAux();
                return;
            }

            var NoteSelectionné = (ComboBoxItem)ComboBoxNote.SelectedItem; //Prend l'élément sélectionné de la combobox
            var Content = (string)NoteSelectionné.Content;
            int note = int.Parse(Content); //Convertit le string  contenu dans la variable Content en int
            Manager.ListeJeuxAux = Tris.TriNote(note, Manager.ListeJeuxAux);
            if (Manager.ListeJeuxAux.Count() == 0)
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();
                MessageBox.Show("Aucun jeu ne correspond à votre recherche. Veuillez réessayez avec un autre critère.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

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
            var Content = (string)PlateFormeSelectionnée.Content;
            PlateForme plateForme = (PlateForme)Enum.Parse(typeof(PlateForme), Content); //Convertit le string Content en Enum Plateforme contenu dans la variable plateForme
            Manager.ListeJeuxAux = Tris.TriPlateForme(plateForme, Manager.ListeJeuxAux);
            if (Manager.ListeJeuxAux.Count() == 0)
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
            
            if(CheckBoxFavoris.IsChecked == true) // vérifie si la textbox est cochée
            {

                Manager.ListeJeuxAux = Tris.TriFavoris(true, Manager.ListeJeuxAux); // Si oui alors tri de la liste auxiliaire avec affichage uniquement favoris
                if (Manager.ListeJeuxAux.Count() == 0) // Si aucun jeu dans la liste de favoris alors message pr utilisateur disant qu'il faut qu'il en ajoute pr utiliser cette chekbox et remise à 0 de la liste auxiliaire
                {
                    ReinitialiserListeAux();
                    ReinitialiserCombobox();
                    MessageBox.Show("Vous n'avez pour l'instant ajouté aucun jeu à votre liste de favoris, veuillez en ajouter pour afficher votre liste de favori", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Information);
                    CheckBoxFavoris.IsChecked = false;
                }
            }
            else if(CheckBoxFavoris.IsChecked == false) // Affichage des jeux non-favoris
            {
                Manager.ListeJeuxAux = Tris.TriFavoris(false, Manager.ListeJeuxAux);
            }

            if(Manager.ListeJeuxAux.Count() == 0) // Si aucun jeu alors remise à 0 de la liste
            {
                ReinitialiserListeAux();
                ReinitialiserCombobox();               
            }
        }


        private void BoutonAccueil_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("MainWindowUser");
            ReinitialiserCombobox();
            Manager.JeuVidéoSelectionné = null;
        }

        private void ReinitialiserListeAux()
        {
            Manager.ListeJeuxArray = new JeuVidéo[Manager.ListeJeux.Count()];

            for (int i = 0; i < Manager.ListeJeux.Count(); i++)
            {
                Manager.ListeJeuxArray[i] = Manager.ListeJeux[i].Clone() as JeuVidéo; //car implémentation ICloneable                                                                      
            }

            Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>(Manager.ListeJeuxArray);
            Manager.VerifFavoris();
        }

        private void ReinitialiserCombobox()
        {
            TextboxRechercheJeu.Text = "";
            ComboBoxGenre.SelectedValue = -1;
            ComboBoxLimiteAge.SelectedValue = -1;
            ComboBoxNote.SelectedValue = -1;
            ComboBoxPlateForme.SelectedValue = -1;
            CheckBoxFavoris.IsChecked = false;
        }

        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_Connexion");
            Manager.JeuVidéoSelectionné = null;
        }

        private void BoutonAjouterJeu_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_AjoutJeu");
            Manager.JeuVidéoSelectionné = null;
        }

        private void TouchePresséeTextBoxRecherche_Event(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if(Manager.RechercherJeuTextBox(TextboxRechercheJeu.Text) != null)
                {
                    Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>() { Manager.RechercherJeu(TextboxRechercheJeu.Text) };
                }
                else
                {
                    MessageBox.Show("Aucun jeu ne correspond à votre recherche. Vérifiez qu'il n'y ai pas d'erreur dans le nom du jeu voulu et réessayez.", "Erreur recherche", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }

        }
        
    }
}
