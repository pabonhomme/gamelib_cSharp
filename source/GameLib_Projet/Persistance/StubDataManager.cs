using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public abstract class StubDataManager<T> : IDataManager<T> where T : class
    {
        /// <summary>
        /// Collection d'objet
        /// </summary>
        protected List<T> MyCollection { get; set; } = new List<T>();

        /// <summary>
        /// Méthode qui récupère la collection d'objet
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<T> GetAll();
        
        

        /// <summary>
        /// Méthode abstraite qui récupère l'objet dont le nom est rentré en paramètre
        /// </summary>
        /// <param name="nom">Pseudo de l'utilisateur voulu</param>
        /// <returns>Un objet</returns>
        public abstract T GetByName(string nom);
        
    }
}
