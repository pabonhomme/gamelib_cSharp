using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    public partial class UtilisateurConnecté : IDataErrorInfo
    {
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