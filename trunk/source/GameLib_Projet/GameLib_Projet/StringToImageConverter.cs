using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace GameLib_Projet
{
    public class StringToImageConverter : IValueConverter
    {
        /// <summary>
        /// Converter permettant de donner le même chemin d'accès à toutes les images de l'application
        /// </summary>
        public static string CheminImages;

        static StringToImageConverter()
        {
            CheminImages = Path.Combine(Directory.GetCurrentDirectory(), "../img/"); //Path.Combine : combine des chaînes en un chemin d'accès
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string NomImage = value as string; //Nom de l'image que l'on reçoit 

            if (string.IsNullOrWhiteSpace(NomImage))
            {
                return null;
            }
            string CheminImage = Path.Combine(CheminImages, NomImage); //Combine le chemin d'accès à toutes les images de l'appli + le nom de l'image souhaitée

            return new Uri(CheminImage, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
