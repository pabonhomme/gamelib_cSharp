using Modele;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Persistance
{
    /// <summary>
    /// Classe qui contient des collections d'objets DTO ( Data Transfert Object)
    /// </summary>
    [DataContract]
    class DataToPersist
    {
        /// <summary>
        /// Liste de jeux DTO
        /// </summary>
        [DataMember]
        public List<JeuVidéoDTO> ListeJeux { get; set; } = new List<JeuVidéoDTO>();

        /// <summary>
        /// Liste d'utilisateurs DTO
        /// </summary>
        [DataMember]
        public List<UtilisateurConnectéDTO> ListeUtilisateurs { get; set; } = new List<UtilisateurConnectéDTO>();

        /// <summary>
        /// Liste d'administrateurs DTO
        /// </summary>
        [DataMember]
        public List<AdministrateurDTO> ListeAdministrateurs { get; set; } = new List<AdministrateurDTO>();

    }
}
