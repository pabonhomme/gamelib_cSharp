using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Permettant de valider l'entrée d'utilisateur dans un textbox. Ici, les textbox de l'ajout d'un utilisateur.
    /// </summary>
    public partial class UtilisateurConnecté : IDataErrorInfo
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
                    case nameof(Prénom):
                        if (string.IsNullOrWhiteSpace(Prénom))
                        {
                            return "Le Prénom est vide";
                        }
                        break;
                    case nameof(Mail):
                        if (string.IsNullOrWhiteSpace(Mail))
                        {
                            return "Le Mail est vide";
                        }
                        break;
                    case nameof(MotDePasse):
                        if (string.IsNullOrWhiteSpace(MotDePasse))
                        {
                            return "Le MotDePasse est vide";
                        }
                        break;
                    case nameof(Pseudo):
                        if (string.IsNullOrWhiteSpace(Pseudo))
                        {
                            return "Le Pseudo est vide";
                        }
                        break;
                }
                return null;
            }

        }

        public string Error { get; }
    }
}