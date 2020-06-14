using System;
using Modele;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace GameLib_Projet
{
    /// <summary>
    /// Converter permettant de changer la visibilité du bouton ajouter jeu dans le MainWindow ou supprimer jeu dans l'UC_JeuVidéo en fonction de si l'utilisateur est administrateur ou non
    /// </summary>
    public class AdminBoutonsToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Administrateur)
            {
                return Visibility.Visible;
            }
            else return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
