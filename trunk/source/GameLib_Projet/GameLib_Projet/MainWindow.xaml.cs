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

namespace GameLib_Projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Manager => (Application.Current as App).Manager;
        public static Navigator Navigator { get; set; } = new Navigator();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
       
        private void BoutonAccueil_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("MainWindowUser");
            Manager.JeuVidéoSelectionné = null;
        }

        private void BoutonConnexion_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_Connexion");
            Manager.JeuVidéoSelectionné = null;
        }

        private void BoutonAjouterJeu_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("UC_AjoutJeu");
            
        }

    }
}
