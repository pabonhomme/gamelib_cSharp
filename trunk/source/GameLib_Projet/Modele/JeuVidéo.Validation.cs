using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Permettant de valider l'entrée d'utilisateur dans un textbox. Ici, les textbox de l'ajout d'un JeuVidéo.
    /// </summary>
    public partial class JeuVidéo : IDataErrorInfo
    {

        /// <summary>
        /// Propriété d'extension qui contient tous les cases de validation
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {

                switch (columnName)
                {
                    case nameof(Nom):
                        if (string.IsNullOrWhiteSpace(Nom))
                        {
                            return "Le nom est vide";
                        }
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description))
                        {
                            return "La description est vide";
                        }
                        break;
                    case nameof(ConfigMini):
                        if (string.IsNullOrWhiteSpace(ConfigMini))
                        {
                            return "La configuration minimale est vide";
                        }
                        break;
                    case nameof(LienAchat):
                        if (string.IsNullOrWhiteSpace(LienAchat))
                        {
                            return "Le lien d'achat est vide";
                        }
                        break;
                    case nameof(LienTrailer):
                        if (string.IsNullOrWhiteSpace(LienTrailer))
                        {
                            return "Le lien trailer est vide";
                        }
                        break;

                }
                return null;
            }

        }

        public string Error { get; }
    }
}




