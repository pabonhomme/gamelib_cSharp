using Modele;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Persistance
{
    /// <summary>
    /// Classe qui permet contient des collections d'objets DTO ( Data Transfert Object)
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
        

    }
}
