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
            Console.WriteLine("Test DataContract");

            Manager manager = new Manager(new StubDataManager());
            manager.DataManager = new BddDataManager();
           

            //manager.ListeUtilisateur[1].AjouterFav(manager.ListeJeux[2]);
            Console.WriteLine(manager.ListeUtilisateur[0]);
            manager.SauvegardeDonnées();

            //Manager manager2 = new Manager(new BddDataManager());
            
        }
    }
}
