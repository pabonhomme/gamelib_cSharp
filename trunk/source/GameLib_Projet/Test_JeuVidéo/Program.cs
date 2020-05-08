using System;
using Modele;

namespace Test_JeuVidéo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe JeuVidéo");

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis une patate verte comme Minecraft", "oui.youtube.com", "img.bin", "Achat définitif", "Marloc", Genre.Aventure , Pegi.trois, PlateForme.Pc  );

            Console.WriteLine(jeuvidéo1);
        }
    }
}
