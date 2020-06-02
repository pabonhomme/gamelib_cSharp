using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class StubUtilisateurConnectéDataManager : StubDataManager<UtilisateurConnecté>
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public StubUtilisateurConnectéDataManager()
        {
            MyCollection = new List<UtilisateurConnecté>()
            {
                new Administrateur("Bonhomme", "Paul", new DateTime(2001, 11, 18), "paul_b63", "MotDePassePaul", "polo.clash@gmail.com"),
                new UtilisateurConnecté("Chevassus", "Noe", new DateTime(2001, 06, 21), "shotlouf", "MotDePasseNoe", "noe@orange.fr"),
                new UtilisateurConnecté("Zemili", "Adel", new DateTime(2001, 12, 16), "adel88", "MotDePasseAdel", "adel@orange.fr"),
                new UtilisateurConnecté("Rigaud", "Zoé", new DateTime(2001, 01, 04), "zoezoe", "MotDePasseZoe", "zoe@orange.fr")

            };
        }

        public override IEnumerable<UtilisateurConnecté> GetAll()
        {
            return MyCollection;
        }

        /// <summary>
        /// Méthode qui récupère l'utilisateur dont le pseudo est rentré en paramètre
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur voulu</param>
        /// <returns>Un utilisateur connecté</returns>
        public override UtilisateurConnecté GetByName(string pseudo)
        {
            return MyCollection.Find(user => user.Pseudo.Equals(pseudo));
        }
    }
}
