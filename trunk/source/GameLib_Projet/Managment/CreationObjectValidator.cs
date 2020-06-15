using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment
{
    /// <summary>
    /// Class permettant la validation de l'ajout d'un utilisateur et d'un jeu vidéo
    /// </summary>
    public static class CreationObjectValidator
    {
        /// <summary>
        /// Méthode permettant le contrôle de saisie de l'ajout d'un jue et d'un utilisateur qui renvoie vrai ou faux.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidationAjout(object value)
        {
            if (value is UtilisateurConnecté) //Si la valeur qu'il reçoit est un utilisateurConnecté
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

            if (value is JeuVidéo) //Si la valeur qu'il reçoit est un JeuVidéo
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
