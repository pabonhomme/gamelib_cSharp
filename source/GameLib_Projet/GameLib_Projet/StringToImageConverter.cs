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
        public static string CheminImages;

        static StringToImageConverter()
        {
            CheminImages = Path.Combine(Directory.GetCurrentDirectory(), "../img/"); //Path.Combine : combine des chaînes en un chemin d'accès
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string NomImage = value as string;

            if (string.IsNullOrWhiteSpace(NomImage))
            {
                return null;
            }
            string CheminImage = Path.Combine(CheminImages, NomImage);

            return new Uri(CheminImage, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
