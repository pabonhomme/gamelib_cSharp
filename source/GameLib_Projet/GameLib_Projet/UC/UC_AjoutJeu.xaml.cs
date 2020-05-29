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
    /// Logique d'interaction pour UC_AjoutJeu.xaml
    /// </summary>
    public partial class UC_AjoutJeu : UserControl
    {
        public UC_AjoutJeu()
        {
            InitializeComponent();
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
            public event RoutedEventHandler AjouterJeuBoutonClick
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
    }
}
