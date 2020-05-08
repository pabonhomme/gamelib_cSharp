using System;
using Modele;

namespace Test_JeuVidéo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe JeuVidéo");

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", "imgMinecraft.bin", "Achat définitif", "Mojeig", Genre.Aventure , Pegi.trois, PlateForme.Pc  );
            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "Minecraft.youtube.com", "imgGTA5.bin", "Achat définitif", "Rockstar", Genre.Action, Pegi.dixHuits, PlateForme.Ps4);


            Console.WriteLine(jeuvidéo1);
        }
    }
}
