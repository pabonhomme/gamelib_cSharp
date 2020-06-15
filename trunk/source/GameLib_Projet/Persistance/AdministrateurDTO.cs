using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Persistance
{
    /// <summary>
    /// Classe qui permet la persistance des données de notre application 
    /// </summary>
    [DataContract]
    class AdministrateurDTO : UtilisateurConnectéDTO
    {


    }

    /// <summary>
    /// classe d'extensions qui permet de passer d'un objet DTO à POCO et inversement
    /// </summary>
    static class AdministrateurExtensions
    {
        /// <summary>
        /// Méthode qui transforme un administrateur DTO en administrateur POCO
        /// </summary>
        /// <param name="dto">administrateur DTO à transormer</param>
        /// <param name="listeJeux">liste de jeux qui permet de verifier quels jeux vont  devoir être ajouté à la liste de favoris de l'administrateur</param>
        /// <returns>renvoie l'administrateur construis à partir de dto</returns>
        public static Administrateur ToPOCO(this AdministrateurDTO dto, IEnumerable<JeuVidéo> listeJeux)
        {
            List<JeuVidéo> listeJeuxfav = new List<JeuVidéo>();
            foreach (string nom in dto.ListeFavoris)
            {
                foreach (JeuVidéo jeu in listeJeux)
                {
                    if (jeu.Nom == nom)
                    {
                        listeJeuxfav.Add(jeu); // si le nom d'un jeu de la liste de jeux et un nom de la liste de noms des jeux favoris sont égaux alors ajout du jeu à la liste de favoris de l'administrateur POCO créé
                    }
                }
            }
            Administrateur user = new Administrateur(dto.Nom, dto.Prénom, dto.DateNaissance, dto.Pseudo, dto.MotDePasse, dto.Mail, listeJeuxfav);
            return user;

        }

        /// <summary>
        /// Méthode qui transforme une collection d'administrateur DTO en collection d'administrateur POCO
        /// </summary>
        /// <param name="dtos">Collection d'administrateur DTO à transformer en POCO</param>
        /// <param name="listeJeux">Collection de jeux qui va être envoyée dans la méthode ToPOCO</param>
        /// <returns>renvoie la collection d'administrateurs obtenues à partir de dtos</returns>
        public static IEnumerable<Administrateur> ToPOCOS(this IEnumerable<AdministrateurDTO> dtos, IEnumerable<JeuVidéo> listeJeux)
            => dtos.Select(dto => dto.ToPOCO(listeJeux));

        /// <summary>
        /// méthode qui transforme un administrateur POCO en administrateur DTO
        /// </summary>
        /// <param name="UserPoco">administrateur POCO à transformer</param>
        /// <returns>renvoie un administrateur transformé en DTO</returns>
        public static AdministrateurDTO ToDTO(this Administrateur UserPoco)
            => new AdministrateurDTO
            {
                Nom = UserPoco.Nom,
                Prénom = UserPoco.Prénom,
                DateNaissance = UserPoco.DateNaissance,
                Pseudo = UserPoco.Pseudo,
                MotDePasse = UserPoco.MotDePasse,
                Mail = UserPoco.Mail,
                ListeFavoris = UserPoco.ListeFavoris.Select(j => j.Nom).ToList()
            };

        /// <summary>
        /// Méthode qui transforme une collection d'administrateurs POCO en collection de d'administrateurs DTO
        /// </summary>
        /// <param name="UserPocos">collection d'administrateurs POCO à transformer</param>
        /// <returns>>collection d'administrateurs construite à partir de la collection UserPocos</returns>
        public static IEnumerable<AdministrateurDTO> ToDTOs(this IEnumerable<Administrateur> UserPocos)
            => UserPocos.Select(p => p.ToDTO());
    }
}