using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment
{
    public static class CreationObjectValidator
    {

        public static bool ValidationAjout(object value)
        {
            if (value is UtilisateurConnecté)
            {
                UtilisateurConnecté user = value as UtilisateurConnecté;

                if (string.IsNullOrWhiteSpace(user.Nom))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(user.Prénom))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(user.Mail))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(user.Pseudo))
                {
                    return false;
                }

            }

            if (value is JeuVidéo)
            {
                JeuVidéo jeu = value as JeuVidéo;

                if (string.IsNullOrWhiteSpace(jeu.Nom))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(jeu.LienAchat))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(jeu.LienTrailer))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(jeu.Description))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(jeu.ConfigMini))
                {
                    return false;
                }

            }

            return true;
        }


    }

}
