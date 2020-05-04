using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    class Utilisateur
    {
        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Prénom de l'utilisateur
        /// </summary>
        public string Prénom { get; private set; }

        /// <summary>
        /// Age de l'utilisateur
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="prénom">Prénom de l'utilisateur</param>
        /// <param name="age">Age de l'utilisateur</param>
        public Utilisateur(string nom, string prénom, int age)
        {
            Nom = nom;
            Prénom = prénom;
            Age = age;
        }
    }
}
