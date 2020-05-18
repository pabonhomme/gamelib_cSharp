using System;
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

namespace GameLib_Projet
{
    /// <summary>
    /// Logique d'interaction pour UC_CreationCompte.xaml
    /// </summary>
    public partial class UC_CreationCompte : UserControl
    {
        public UC_CreationCompte()
        {
            InitializeComponent();
        }

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

        public event RoutedEventHandler AnnulerClick
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

        public event RoutedEventHandler CréerCompte
        {
            add
            {
                BoutonCréerCompte.Click += value;
            }
            remove
            {
                BoutonCréerCompte.Click -= value;
            }
        }
    }
}
