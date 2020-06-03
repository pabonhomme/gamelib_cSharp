using Managment;
using Modele;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings.Web;
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
    /// Logique d'interaction pour UC_AjoutJeu.xaml
    /// </summary>
    public partial class UC_AjoutJeu : UserControl, INotifyPropertyChanged
    {
        public Manager Manager => (Application.Current as App).Manager;

        public static Navigator Navigator => Navigator.GetInstance();


        private JeuVidéo nouveauJeu;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public JeuVidéo NouveauJeu
        {
            get { return nouveauJeu; }

            set
            {
                nouveauJeu = value;
                OnPropertyChanged();

            }
        }
        public UC_AjoutJeu()
        {

            InitializeComponent();
            DataContext = this;
        }

        private void ChargementAjoutJeuUC(object sender, RoutedEventArgs e)
        {
            NouveauJeu = new JeuVidéo();
        }

        public event RoutedEventHandler AnnulerAjoutJeuClick
        {
            add
            {
                AnnulerBouton.Click += value;
            }

            remove
            {
                AnnulerBouton.Click += value;
            }

        }


        private void AjoutImageJeu_click(object sender, RoutedEventArgs e)
        {
            //Configuration OpenFile dialogue box
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //OpenFileDialog : Affiche une boite de dialogue qui invite l'utilisateur à ouvrir un fichier.
            dialog.InitialDirectory = "C:\\Users\\Public\\Pictures";
            dialog.FileName = "Images"; //Nom du fichier par défaut
            dialog.DefaultExt = ".jpg | .png | .gif | .jpeg"; //Extension fichier par défaut
            dialog.Filter = "All images files(.jpg, .png, .gif, .jpeg)| *.jpg; *.png; *.gif; *.jpeg; | JPG files(.jpg) | *.jpg | PNG files(.png) | *.png | GIF files(.gif) | *.gif | JPEG files(.jpeg) | *.jpeg"; //Filtrer les fichiers par extension

            //Afficher la boîte de dialogue d'ouverture de fichier
            bool? result = dialog.ShowDialog();

            //Traiter les résultats de la boîte de dialogue d'ouverture du fichier
            if (result == true)
            {

                //Ouverture fichier
                FileInfo InfoFichier = new FileInfo(dialog.FileName);
                string NomImage = InfoFichier.Name;

                if (File.Exists(System.IO.Path.Combine(StringToImageConverter.CheminImages, NomImage)))
                {
                    var jeu = Manager.ListeJeux.SingleOrDefault(jeu => jeu.LienImage == InfoFichier.Name); //Utilisation du Linq pour savoir si l'image est déja utilisé par un jeu
                    if (jeu != null) //Si un jeu existe avec la meme image
                    {
                        MessageBox.Show("Cette image de jeu est déja utilisée, veuillez la changer", "Erreur image jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; //Alors lien image du studioDev = à ceux des jeux déja présents
                    }
                    else
                    {
                        NouveauJeu.LienImage = NomImage;
                        return;
                    }



                }

                File.Copy(dialog.FileName, System.IO.Path.Combine(StringToImageConverter.CheminImages, NomImage)); //Si non, copie de l'image dans le dossier du projet avec comme nom celui de l'image qu'on ajoute
                NouveauJeu.LienImage = NomImage;

            }
        }
        private void AjoutImageStudioDev_click(object sender, RoutedEventArgs e)
        {
            //Configuration OpenFile dialogue box
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //OpenFileDialog : Affiche une boite de dialogue qui invite l'utilisateur à ouvrir un fichier.
            dialog.InitialDirectory = "C:\\Users\\Public\\Pictures";
            dialog.FileName = "Images"; //Nom du fichier par défaut
            dialog.DefaultExt = ".jpg | .png | .gif | .jpeg"; //Extension fichier par défaut
            dialog.Filter = "All images files(.jpg, .png, .gif, .jpeg)| *.jpg; *.png; *.gif; *.jpeg; | JPG files(.jpg) | *.jpg | PNG files(.png) | *.png | GIF files(.gif) | *.gif | JPEG files(.jpeg) | *.jpeg"; //Filtrer les fichiers par extension

            //Afficher la boîte de dialogue d'ouverture de fichier
            bool? result = dialog.ShowDialog();

            //Traiter les résultats de la boîte de dialogue d'ouverture du fichier
            if (result == true)
            {

                //Ouverture fichier
                FileInfo InfoFichier = new FileInfo(dialog.FileName); // sert de wrapper (emballage) pour un chemin d'accès de fichier.
                string NomImage = InfoFichier.Name; //Nom du fichier qu'on souhaite ajouter

                if (File.Exists(System.IO.Path.Combine(StringToImageConverter.CheminImages, NomImage))) // On teste si l'image qu'on veut ajouter existe
                {
                    NouveauJeu.StudioDev = NomImage; //Si oui on donne juste comme contenu du studio de Dev, le nom de l'image qu'on veut ajouter
                    return;
                }

                File.Copy(dialog.FileName, System.IO.Path.Combine(StringToImageConverter.CheminImages, NomImage)); //Si non, copie de l'image dans le dossier du projet avec comme nom celui de l'image qu'on ajoute
                NouveauJeu.StudioDev = NomImage;
            }
        }
        private void BoutonAjouterJeu_click(object sender, RoutedEventArgs e)
        {
            if (Manager.RechercherJeu(NouveauJeu.Nom) == null)
            {
                if (String.IsNullOrWhiteSpace(NouveauJeu.LienImage))
                {
                    MessageBox.Show("Aucune image n'est sélectionnée pour le jeu", "Erreur pas de sélection pour l'image jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Manager.AjouterJeu(NouveauJeu, Manager.UtilisateurCourant);

                Navigator.NavigateTo("MainWindowUser");

            }
            else
            {
                MessageBox.Show("Ce jeu existe déja", "Attention Jeu déja existant", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)GenreCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu dans la variable Content
            Genre g = (Genre)Enum.Parse(typeof(Genre), content); //Convertit le string en Enum Genre contenu dans la variable g
            NouveauJeu.Genre = g;

        }
        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)PegiCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu contenu dans la variable Content
            Pegi p = (Pegi)Enum.Parse(typeof(Pegi), content); //Convertit le string Content en Enum Pegi contenu dans la variable p
            NouveauJeu.Pegi = p;

        }


        private void ComboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)NoteCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu dans la varialbe content
            int a = int.Parse(content); //Convertit le string en int contenu dans la variable a
            NouveauJeu.Note = a;

        }
        private void ComboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)ModeleEcoCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string
            NouveauJeu.ModeleEco = content;

        }

        private void CheckBoxPlateforme_PC_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Pc);
            if (CheckBoxPC.IsChecked == null || CheckBoxPC.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Pc);
        }

        private void CheckBoxPlateforme_Ps4_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Ps4);
            if (CheckBoxPs4.IsChecked == null || CheckBoxPs4.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Ps4);
        }

        private void CheckBoxPlateforme_Ps3_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Ps3);
            if (CheckBoxPs3.IsChecked == null || CheckBoxPs3.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Ps3);
        }

        private void CheckBoxPlateforme_Switch_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Switch);
            if (CheckBoxSwitch.IsChecked == null || CheckBoxSwitch.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Switch);
        }

        private void CheckBoxPlateforme_XboxOne_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.XboxOne);
            if (CheckBoxXboxOne.IsChecked == null || CheckBoxXboxOne.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.XboxOne);
        }

        private void CheckBoxPlateforme_Xbox360_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Xbox360);
            if (CheckBoxX360.IsChecked == null || CheckBoxX360.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Xbox360);
        }
    }

}
