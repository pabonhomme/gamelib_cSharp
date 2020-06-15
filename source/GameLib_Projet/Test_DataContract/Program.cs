using System;
using Modele;
using Managment;
using System.Collections.Generic;
using Persistance;
namespace Test_DataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test DataContract\n\n");

            Console.WriteLine("Instanciation du premier manager\n\n");
            Manager manager = new Manager(new StubDataManager());

            Console.WriteLine("changement de méthode de persistance\n\n");

            manager.DataManager = new BddDataManager();

            Console.WriteLine("Ajout d'un jeu en favori par un utilisateur\n\n");

            manager.ListeUtilisateur[1].AjouterFav(manager.ListeJeux[2]);

            Console.WriteLine("Affichage de l'utilisateur\n\n");
            Console.WriteLine(manager.ListeUtilisateur[0]);

            Console.WriteLine("Sauvegarde des données\n\n");
            manager.SauvegardeDonnées();

            Console.WriteLine("Affichage du premier managerr\n\n");
            Console.WriteLine(manager);

            Console.WriteLine("Instanciation d'un second manager\n\n");
            Manager manager2 = new Manager(new BddDataManager());

            Console.WriteLine("Affichage du second manager pour vérification persistance\n\n");
            Console.WriteLine(manager2);
        }
    }
}
