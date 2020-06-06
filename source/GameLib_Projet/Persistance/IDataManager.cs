using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface IDataManager
    {
        (IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés) ChargeDonnées();

        void SauvegardeDonnées(IEnumerable<JeuVidéo> jeuVidéos, IEnumerable<UtilisateurConnecté> utilisateursConnectés);

    }
}
