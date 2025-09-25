using DinoManager.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoManager.Dal.Mappers
{
    internal static class Mappers
    {
        internal static Dino ToDino(this IDataRecord record)
        {
            return new Dino() { Id = (int)record["Id"], Espece = (string)record["Espece"], Poids = (int)record["Poids"], Taille = (int)record["Taille"] };
        }
    }
}
