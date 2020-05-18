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
    public class Navigator : INotifyPropertyChanged
    {
        Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>()
        {
            ["MainWindowUser"] = new MainWindowUser(),
            ["MainWindowAdmin"] = new MainWindowAdmin(),
            ["UC_JeuVideo"] = new UC_JeuVideo(),
            ["UC_AjoutJeu"] = new UC_AjoutJeu(),
            ["UC_Connexion"] = new UC_Connexion(),
            ["UC_CreationCompte"] = new UC_CreationCompte()
        };

        public void NavigateTo(string userControl) { SelectedUserControl = userControls.GetValueOrDefault(userControl); }

        private void InitUserControls()
        {
            (userControls["UC_Connexion"] as UC_Connexion).ButtonClick += (sender, args) => SelectedUserControl = userControls["UC_CreationCompte"];
            (userControls["UC_CreationCompte"] as UC_CreationCompte).DejàCrééClick += (sender, args) => SelectedUserControl = userControls["UC_Connexion"];
            (userControls["UC_CreationCompte"] as UC_CreationCompte).AnnulerClick += (sender, args) => SelectedUserControl = userControls["MainWindowUser"];
            (userControls["UC_CreationCompte"] as UC_CreationCompte).CréerCompte += (sender, args) => SelectedUserControl = userControls["UC_Connexion"];

            SelectedUserControl = userControls["MainWindowUser"];
        }

        public Navigator()
        {
            InitUserControls();
        }

        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                selectedUserControl = value;
                OnPropertyChanged();
            }
        }
        private UserControl selectedUserControl;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));
    }

}
