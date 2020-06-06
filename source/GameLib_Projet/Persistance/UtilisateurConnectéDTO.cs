using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Concurrent;
using Modele;
using System.Linq;

namespace Persistance
{
    [DataContract]
    class UtilisateurConnectéDTO
    {

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Prénom { get; set; }

        /// <summary>
        /// Date de naissance de l'utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Pseudo de l'utilisateur connecté
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Pseudo { get; set; }

        /// <summary>
        /// Mot de passe de l'utilisateur connecté
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string MotDePasse { get; set; }

        /// <summary>
        /// Mail de l'utilisateur connecté
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Mail { get; set; }

        /// <summary>
        /// Liste des noms des jeux favoris de l'utilisateur connecté
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public List<string> ListeFavoris { get; set; }


    }

    /// <summary>
    /// classe d'ectensions qui permet de passer d'un objet DTO à POCO et inversement
    /// </summary>
    static class UtilisateurConnectéExtensions
    {
        /// <summary>
        /// Méthode qui transforme un utilisateur DTO en utilisateur POCO
        /// </summary>
        /// <param name="dto">utilisateur DTO à transormer</param>
        /// <param name="listeJeux">liste de jeux qui permet de verifier quels jeux vont  devoir être ajouté à la liste de favoris de l'utilisateur</param>
        /// <returns>renvoie l'utilisateur construis à partir de dto</returns>
        public static UtilisateurConnecté ToPOCO(this UtilisateurConnectéDTO dto, IEnumerable<JeuVidéo> listeJeux)
        {
            List<JeuVidéo> listeJeuxfav = new List<JeuVidéo>();
            foreach( string nom in dto.ListeFavoris)
            {
                foreach(JeuVidéo jeu in listeJeux)
                {
                    if( jeu.Nom == nom)
                    {
                        listeJeuxfav.Add(jeu); // si le nom d'un jeu de la liste de jeux et un nom de la liste de noms des jeux favoris sont égaux alors ajout du jeu à la liste de favoris de l'utilisateur POCO créé
                    }
                }
            }
            
            UtilisateurConnecté user = new UtilisateurConnecté(dto.Nom, dto.Prénom, dto.DateNaissance, dto.Pseudo, dto.MotDePasse, dto.Mail, listeJeuxfav );
            return user;
        }

        /// <summary>
        /// Méthode qui transforme une collection d'utilisateur DTO en collection d'utilisateur POCO
        /// </summary>
        /// <param name="dtos">Collection d'utilisateur DTO à transformer en POCO</param>
        /// <param name="listeJeux">Collection de jeux qui va être envoyée dans la méthode ToPOCO</param>
        /// <returns>renvoie la collection d'utilisateurs obtenues à partir de dtos</returns>
        public static IEnumerable<UtilisateurConnecté> ToPOCOS(this IEnumerable<UtilisateurConnectéDTO> dtos, IEnumerable<JeuVidéo> listeJeux)
            => dtos.Select(dto => dto.ToPOCO(listeJeux));

        /// <summary>
        /// méthode qui transforme un utilisateur POCO en utilisateur DTO
        /// </summary>
        /// <param name="UserPoco">Utilisateur POCO à transformer</param>
        /// <returns>renvoie un utitlisateur transformé en DTO</returns>
        public static UtilisateurConnectéDTO ToDTO(this UtilisateurConnecté UserPoco)
            => new UtilisateurConnectéDTO
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
        /// Méthode qui transforme une collection d'utilisateurs POCO en collection de d'utilisateurs DTO
        /// </summary>
        /// <param name="UserPocos">collection d'utilisateurs POCO à transformer</param>
        /// <returns>>collection d'utilisateurs construite à partir de la collection UserPocos</returns>
        public static IEnumerable<UtilisateurConnectéDTO> ToDTOs(this IEnumerable<UtilisateurConnecté> UserPocos)
            => UserPocos.Select(p => p.ToDTO());            
    }
}