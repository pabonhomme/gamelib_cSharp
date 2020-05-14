using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class StubJeuVidéoDataManager : StubDataManager<JeuVidéo>
    {
        public StubJeuVidéoDataManager()
        {
            MyCollection = new List<JeuVidéo>()
            {
                 new JeuVidéo("Minecraft", 4, 29.9f, "Je suis Minecraft", "Minecraft.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img\\Minecraft.jpg",
                "Achat définitif", AppDomain.CurrentDomain.BaseDirectory + "../../../img\\mojang.png", Genre.Aventure, Pegi.Trois, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne}),

                 new JeuVidéo("GTAV", 5, 10f, "Je suis GTAV", "GTAV.youtube.com", AppDomain.CurrentDomain.BaseDirectory + "../../../img/gtaV.jpg",
                 "Achat définitif", "Rockstar", Genre.Action, Pegi.DixHuits, new List<PlateForme>(){
            PlateForme.Pc,PlateForme.Ps4,PlateForme.Xbox360,PlateForme.XboxOne, PlateForme.Ps3 })
            };
        }

        public override JeuVidéo GetByName(string nom)
        {
            return MyCollection.Find(jeu => jeu.Nom.Equals(nom));
        }

        
    }
}
