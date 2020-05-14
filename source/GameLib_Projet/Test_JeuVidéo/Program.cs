using System;
using System.Collections.Generic;
using Modele;

namespace Test_JeuVidéo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe JeuVidéo");

            JeuVidéo jeuvidéo1 = new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img\\Minecraft.jpg",
                "Achat définitif", "Mojeig", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne});

            JeuVidéo jeuvidéo2 = new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img/gtaV.jpg",
                "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 } );

            if( jeuvidéo1 == jeuvidéo2)
            {
                Console.WriteLine("Message s'ils sont égaux avec test ==");
            }
            if (jeuvidéo1.Equals(jeuvidéo2))
            {
                Console.WriteLine("Message s'ils sont égaux avec test equals");
            }

            Console.WriteLine(jeuvidéo1);
        }
    }
}
