using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Persistance
{
    /// <summary>
    /// Classe qui permet la persistance des données de notre application 
    /// </summary>
    public class BddDataManager : IDataManager
    {
        /// <summary>
        /// Chemin relatif qui situe le dossier dans lequel on veut sauvegarder les données
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");

        /// <summary>
        /// Nom du fichier dans lequel on veut sauvegarder les données
        /// </summary>
        public string FileName { get; set; } = "Game_Lib.XML";

        /// <summary>
        /// Combinaison du chemin et du nom du fichier à l'aide la méthode combine
        /// </summary>
        string DataFile => Path.Combine(FilePath, FileName);

        /// <summary>
        /// Liste de jeux qui va récuperer les données chargées
        /// </summary>
        internal List<JeuVidéo> ListeJeux { get; set; } = new List<JeuVidéo>();

        /// <summary>
        /// Liste d'utilisateurs connectés qui va récuperer les données chargées
        /// </summary>
        internal List<UtilisateurConnecté> ListeUtilisateurConnecté { get; set; } = new List<UtilisateurConnecté>();

        /// <summary>
        /// Propriété qui va serialiser et deserialiser les données dans le fichier voulu, on lui demande de garder les references (ListeFavoris d'un utilisateur)
        /// </summary>
        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(DataToPersist),
                                                 new DataContractSerializerSettings()
                                                 {
                                                     PreserveObjectReferences = true
                                                 });

        /// <summary>
        /// Méthode qui va charger les données contenues dans le fichier de sauvegarde
        /// </summary>
        /// <returns>Elle renvoie la liste de jeux clonés et d'utilisateurs chargés dans la méthode </returns>
        public (IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés) ChargeDonnées()
        {
            if (!File.Exists(DataFile)) // vérification que le fichier existe
            {
                throw new FileNotFoundException("Le fichier n'a pas été trouvé"); // lance un exception si pas trouvé
            }

            DataToPersist dataToPersist; // initialisation des collections DTO

            using (Stream s = File.OpenRead(DataFile)) // instanciation du flux de donnée s en lecture -> on utilise using pour pas oublier de fermer le fichier car appel implicite et automatique de dispose() pour nettoyer données non-managées
            {
                dataToPersist = Serializer.ReadObject(s) as DataToPersist; // déserialisation des données qui sont mises dans les collections DTO
            }

            ListeJeux = dataToPersist.ListeJeux.ToPOCOs().ToList(); // transformation de la ListeJeux DTO en ListeJeux POCO (objet métier)
            ListeUtilisateurConnecté = dataToPersist.ListeUtilisateurs.ToPOCOS(ListeJeux).ToList(); // transformation de la ListeUtilisateur DTO en ListeJeux POCO (objet métier)

            return (ListeJeux.Select(m => m.Clone()).Cast<JeuVidéo>().AsEnumerable(), ListeUtilisateurConnecté); // Renvoie des deux liste dont Listjeux a ses jeux clonés pour eviter problème référence dans le modèle
        }

        /// <summary>
        /// Méthode qui sauvegarde les données dans un fichier de sauvegarde
        /// </summary>
        /// <param name="jeuVidéos">Liste de jeux à sauvegarder</param>
        /// <param name="utilisateursConnectés">Liste d'utilisateurs à sauvegarder</param>
        public void SauvegardeDonnées(IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés)
        {            
            if (!Directory.Exists(FilePath)) // vérification que le dossier de sauvegarde existe
            {
                Directory.CreateDirectory(FilePath); // Si non-existant alors on le crée
            }

            DataToPersist dataToPersist = new DataToPersist(); // initialisation des collections DTO
            dataToPersist.ListeJeux.AddRange(jeuVidéos.ToDTOs()); // Ajouts des jeux POCO en jeux DTO pour être persistés
            dataToPersist.ListeUtilisateurs.AddRange(utilisateursConnectés.ToDTOs()); // Ajouts des utlisateurs POCO en jeux DTO pour être persistés

            var paramètres = new XmlWriterSettings() { Indent = true }; // instancie une classe qui permet de choisir des paramètres pour l'écriture dans le fichier de sauvegarde

            using (TextWriter tw = File.CreateText(DataFile))// instanciation du flux de donnée t en écriture -> on utilise using pour pas oublier de fermer le fichier car appel implicite et automatique de dispose() pour nettoyer données non-managées
            {
                using (XmlWriter writer = XmlWriter.Create(tw, paramètres)) // using qui permet d'écrire la liste de jeux vidéos dans le fichier voulu à l'aide de serializer. Le writer permet de donner des paramètres (indentation)
                {
                    Serializer.WriteObject(writer, dataToPersist); // sérialisation des données dans le fichier voulu avec les paramètres voulus
                }
            }
        }
    }
}
