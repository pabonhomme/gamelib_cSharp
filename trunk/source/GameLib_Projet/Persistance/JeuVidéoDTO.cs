using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Persistance
{
    /// <summary>
    /// Classe de Jeu-Vidéo DTO
    /// </summary>
    [DataContract]
    class JeuVidéoDTO
    {
        /// <summary>
        /// Nom du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Nom { get; set; }

        /// <summary>
        /// Note du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public int Note { get; set; }

        /// <summary>
        /// Prix du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public float Prix { get; set; }

        /// <summary>
        /// Description du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Description { get; set; }

        /// <summary>
        /// Lien du trailer du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string LienTrailer { get; set; }

        /// <summary>
        /// Lien de l'image du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string LienImage { get; set; }


        /// <summary>
        /// Lien pour acheter jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string LienAchat { get; set; }

        /// <summary>
        /// Modèle économique du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 7)]
        public ModeleEco ModeleEco { get; set; }

        /// <summary>
        /// Nom du studio de dévelopement
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string StudioDev { get; set; }

        /// <summary>
        /// Précise si le jeu est ajouté en favori par l'utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 9)]
        public bool EstFavori { get; set; }
 
        /// <summary>
        /// Genre du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 10)]
        public Genre Genre { get; set; }

        /// <summary>
        /// Age minimum pour avoir le jeu du jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 11)]
        public Pegi Pegi { get; set; }

        /// <summary>
        /// Configuration minimale pour jouer au jeu
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 12)]
        public string ConfigMini { get; set; }

        /// <summary>
        /// Plate-formes où le jeu est disponible
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 13)]
        public List<PlateForme> ListePlateFormes { get; set; } = new List<PlateForme>();
    }

    /// <summary>
    /// classe d'ectensions qui permet de passer d'un objet DTO à POCO et inversement
    /// </summary>
    static class JeuVidéoExtensions
    {
        /// <summary>
        /// Méthode qui transforme un jeu DTO en jeu POCO
        /// </summary>
        /// <param name="dto">jeu à transformer</param>
        /// <returns>jeu construis à partir de dto</returns>
        public static JeuVidéo ToPOCO(this JeuVidéoDTO dto) 
            => new JeuVidéo(dto.Nom, dto.Note, dto.Prix, dto.Description, dto.LienTrailer, dto.LienImage, dto.LienAchat, dto.ModeleEco, dto.StudioDev, dto.ConfigMini, dto.Genre, dto.Pegi, dto.ListePlateFormes);

        /// <summary>
        /// Méthode qui transforme une collection de jeux DTO en collection de jeux POCO
        /// </summary>
        /// <param name="dtos">collection de jeux dto à transformer</param>
        /// <returns>collection de jeu construite à partir de la collection dtos</returns>
        public static IEnumerable<JeuVidéo> ToPOCOs(this IEnumerable<JeuVidéoDTO> dtos) 
            => dtos.Select(dto => dto.ToPOCO());

        /// <summary>
        /// méthode qui transforme un jeu POCO en jeu DTO
        /// </summary>
        /// <param name="jeuPOCO">jeu POCO à transformer</param>
        /// <returns>jeu DTO construis à partir de jeuPOCO </returns>
        public static JeuVidéoDTO ToDTO(this JeuVidéo jeuPOCO) => new JeuVidéoDTO
        {
            Nom = jeuPOCO.Nom,
            Note = jeuPOCO.Note,
            Prix = jeuPOCO.Prix,
            Description = jeuPOCO.Description,
            LienTrailer = jeuPOCO.LienTrailer,
            LienImage = jeuPOCO.LienImage,
            LienAchat = jeuPOCO.LienAchat,
            ModeleEco = jeuPOCO.ModeleEco,
            StudioDev = jeuPOCO.StudioDev,
            ConfigMini = jeuPOCO.ConfigMini,
            Genre = jeuPOCO.Genre,
            Pegi = jeuPOCO.Pegi,
            ListePlateFormes = jeuPOCO.ListePlateFormes
        };

        /// <summary>
        /// Méthode qui transforme une collection de jeux POCO en collection de jeux DTO
        /// </summary>
        /// <param name="jeuVidéoPocos">collection de jeux POCO à transformer</param>
        /// <returns>collection de jeux construite à partir de la collection jeuVidéoPocos</returns>
        public static IEnumerable<JeuVidéoDTO> ToDTOs(this IEnumerable<JeuVidéo> jeuVidéoPocos) 
            => jeuVidéoPocos.Select(j => j.ToDTO());
    }
}
