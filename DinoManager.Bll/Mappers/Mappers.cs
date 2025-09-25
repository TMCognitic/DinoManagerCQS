using DinoManager.Bll.Entities;
using DalDino = DinoManager.Dal.Entities.Dino;

namespace DinoManager.Bll.Mappers
{
    internal static class Mappers
    {
        internal static DalDino ToDal(this Dino dino)
        { 
            return new DalDino() { Id = dino.Id, Espece = dino.Espece, Poids = dino.Poids, Taille = dino.Taille };
        }

        internal static Dino ToBll(this DalDino dino)
        {
            return new Dino(dino.Id, dino.Espece, dino.Poids, dino.Taille);
        }
    }
}
