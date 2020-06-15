using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace GameLib_Projet
{
    /// <summary>
    /// Navigateur de l'application
    /// </summary>
    public class Navigator : INotifyPropertyChanged
    {
        Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>()
        {
            ["MainWindowUser"] = new MainWindowUser(),
            ["UC_JeuVideo"] = new UC_JeuVideo(),
            ["UC_AjoutJeu"] = new UC_AjoutJeu(),
            ["UC_Connexion"] = new UC_Connexion(),
            ["UC_CreationCompte"] = new UC_CreationCompte()
        };

        /// <summary>
        /// Méthode permettant de naviguer vers un userControl dont le nom reçu en paramètre
        /// </summary>
        /// <param name="userControl"> nom du UserControl</param>
        public void NavigateTo(string userControl)
        {
            SelectedUserControl = userControls.GetValueOrDefault(userControl);
        }

        /// <summary>
        /// Méthode permettant de s'abonner à un UserControl prédéfini pour chaque évènement click dans le Xaml
        /// </summary>
        private void InitUserControls()
        {
            (userControls["UC_Connexion"] as UC_Connexion).PremièreConnexionClick += (sender, args) => SelectedUserControl = userControls["UC_CreationCompte"];
            (userControls["UC_CreationCompte"] as UC_CreationCompte).DejàCrééClick += (sender, args) => SelectedUserControl = userControls["UC_Connexion"];
            (userControls["UC_CreationCompte"] as UC_CreationCompte).AnnulerCreationClick += (sender, args) => SelectedUserControl = userControls["MainWindowUser"];
            (userControls["UC_AjoutJeu"] as UC_AjoutJeu).AnnulerAjoutJeuClick += (sender, args) => SelectedUserControl = userControls["MainWindowUser"];


            SelectedUserControl = userControls["MainWindowUser"]; //Définit par défault le UserControl sélectionné
        }

        /// <summary>
        /// instance unique du navigator 
        /// </summary>
        private static Navigator instanceUnique;

        /// <summary>
        /// Méthode qui vérifie qu'il n'y ai pas d'instance de navigator déja créée, si non alors elle l'instancie
        /// </summary>
        /// <returns>Navigator créé instanceUnique déja instanciée</returns>
        public static Navigator GetInstance() // singleton
        {
            if (instanceUnique == null)
            {
                instanceUnique = new Navigator();
            }
            return instanceUnique;
        }

        /// <summary>
        /// Méthode de navigation
        /// </summary>
        private Navigator()
        {
            InitUserControls();
        }

        /// <summary>
        /// User control sélectionné
        /// </summary>
        private UserControl selectedUserControl;
        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                selectedUserControl = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Evenement qui permet de signaler à la vue par un évenement qu'une propriété a changé
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui va tester si la propriété qui l'appelle a changé 
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));
    }

}
