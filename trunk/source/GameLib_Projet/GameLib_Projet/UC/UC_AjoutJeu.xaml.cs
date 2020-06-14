using Managment;
using Modele;
using PageAccueil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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

        /// <summary>
        /// Nouveau Jeu Vidéo que l'admin va créer
        /// </summary>
        private JeuVidéo nouveauJeu;

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

        /// <summary>
        /// Permet d'initialiser les textBox et l'openFileDialog de l'UC_AjoutJeuVidéo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChargementAjoutJeuUC(object sender, RoutedEventArgs e)
        {
            NouveauJeu = new JeuVidéo(); //Initialise les infos du nouveau jeux à 0
        }

        /// <summary>
        /// Event pour le navigateur permettant de renvoyer sur l'UC MainWindowUser
        /// </summary>
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

        /// <summary>
        /// Permet d'ajouter l'image de notre nouveau jeu grâce à un OpenFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Permet d'ajouter l'image du studio de développement du nouveau jeu grâce à un OpenFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton permettant de créer le nouveau jeu et contrôle divers de la saise de l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAjouterJeu_click(object sender, RoutedEventArgs e)
        {
            bool v = CreationObjectValidator.ValidationAjout(NouveauJeu); //Met dans la variable v le résultat booleen de la méthode validationAjout qui return false si un des champs rentrés pour créer le jeu n'est pas valide

            if (Manager.RechercherJeu(NouveauJeu.Nom) == null) //Teste si le Nom du jeu n'est pas déja existant dans la ListeJeux
            {
                if (String.IsNullOrWhiteSpace(NouveauJeu.LienImage)) //Teste si le lien d'image est vide
                {
                    MessageBox.Show("Aucune image n'est sélectionnée pour le jeu", "Erreur pas de sélection pour l'image jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (String.IsNullOrWhiteSpace(GenreCombobox.Text) || String.IsNullOrWhiteSpace(NoteCombobox.Text) || String.IsNullOrWhiteSpace(PegiCombobox.Text) || String.IsNullOrWhiteSpace(ModeleEcoCombobox.Text)) //Teste si une ou plusieurs combobox est vide
                {
                    MessageBox.Show("Des éléments sont manquants concernant le modèle économique, le PEGI, le genre ou la note du jeu", "Erreur informations du jeu non valides (combobox)", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (v == false) // Si un des champs rentré par l'utilisateur dans les textbox de l'ajoutJeu n'est pas valide
                {
                    MessageBox.Show("Tous les champs ne sont pas valides. Veuillez réessayer", "Erreur création compte", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (v == true) //Si tous les champs rentrés par l'utilisateurs sont valide et que le jeu existe bien dans ListeJeuxVidéos
                {
                    Manager.AjouterJeu(NouveauJeu, Manager.UtilisateurCourant); //Ajoute le NouveauJeu dans ListeJeux
                    ReinitialiserListeAux();
                    

                    Navigator.NavigateTo("MainWindowUser"); //Renvoie à l'UC MainWindowUser
                }

            }
            else //Sinon le nom du jeu existe déja dans la ListeJeux
            {
                MessageBox.Show("Ce jeu existe déja", "Attention Jeu déja existant", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }


        /// <summary>
        /// SelectionChanged de la combobox du Genre du Nouveaujeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)GenreCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu dans la variable Content
            Genre g = (Genre)Enum.Parse(typeof(Genre), content); //Convertit le string en Enum Genre contenu dans la variable g
            NouveauJeu.Genre = g;

        }

        /// <summary>
        /// SelectionChanged de la combobox du Pegi du Nouveaujeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)PegiCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu contenu dans la variable Content
            Pegi p = (Pegi)Enum.Parse(typeof(Pegi), content); //Convertit le string Content en Enum Pegi contenu dans la variable p
            NouveauJeu.Pegi = p;

        }


        /// <summary>
        /// SelectionChanged de la combobox de la Note du Nouveaujeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)NoteCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string contenu dans la varialbe content
            int a = int.Parse(content); //Convertit le string en int contenu dans la variable a
            NouveauJeu.Note = a;

        }

        /// <summary>
        /// SelectionChanged de la combobox du ModeleEconomique du Nouveaujeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {

            var item = (ComboBoxItem)ModeleEcoCombobox.SelectedValue; //Prend l'élément sélectionné de la combobox
            var content = (string)item.Content; //Convertit le contenu du selectedValue en string
            ModeleEco m = (ModeleEco)Enum.Parse(typeof(ModeleEco), content);
            NouveauJeu.ModeleEco = m;

        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox PC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_PC_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Pc); //Réinitialise l'attribut PC dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxPC.IsChecked == null || CheckBoxPC.IsChecked == false) //Regarde si la CheckBox sélectionnée est pas décochée ou null
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Pc); //Ajoute l'élement PC dans la ListeDePlateForme du NouveauJeu
        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox PS4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_Ps4_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Ps4); //Réinitialise l'attribut Ps4 dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxPs4.IsChecked == null || CheckBoxPs4.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Ps4);
        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox PS3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_Ps3_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Ps3); //Réinitialise l'attribut Ps3 dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxPs3.IsChecked == null || CheckBoxPs3.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Ps3);
        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox Switch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_Switch_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Switch); //Réinitialise l'attribut Switch dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxSwitch.IsChecked == null || CheckBoxSwitch.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Switch);
        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox XboxOne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_XboxOne_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.XboxOne); //Réinitialise l'attribut XboxOne dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxXboxOne.IsChecked == null || CheckBoxXboxOne.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.XboxOne);
        }

        /// <summary>
        /// Rentre dans la méthode si l'utilisateur clique sur la case de la checkbox Xbox360
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlateforme_Xbox360_Click(Object sender, RoutedEventArgs e)
        {
            NouveauJeu.ListePlateFormes.Remove(PlateForme.Xbox360); //Réinitialise l'attribut Xbox360 dans la Liste de plateformes du NouveauJeu évitant que si l'on clique puis déclique la checkbox, la plateforme n'est ajouté qu'une seule fois ou non
            if (CheckBoxX360.IsChecked == null || CheckBoxX360.IsChecked == false)
            {
                return;
            }
            else NouveauJeu.ListePlateFormes.Add(PlateForme.Xbox360);
        }

        /// <summary>
        /// Méthode permettant la réintialisation de la ListeAux
        /// </summary>
        private void ReinitialiserListeAux()
        {
            Manager.ListeJeux.Sort();
            Manager.ListeJeuxArray = new JeuVidéo[Manager.ListeJeux.Count()];

            for (int i = 0; i < Manager.ListeJeux.Count(); i++)
            {
                Manager.ListeJeuxArray[i] = Manager.ListeJeux[i].Clone() as JeuVidéo; //car implémentation ICloneable                                                                      
            }

            Manager.ListeJeuxAux = new ObservableCollection<JeuVidéo>(Manager.ListeJeuxArray);
            Manager.VerifFavoris();
        }
    }

}
