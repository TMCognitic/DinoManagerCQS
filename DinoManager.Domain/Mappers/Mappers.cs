using DinoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoManager.Domain.Mappers
{
    internal static class Mappers
    {
        internal static Dino ToDino(this IDataRecord record)
        {
            return new Dino((int)record["Id"], (string)record["Espece"], (int)record["Poids"], (int)record["Taille"]);
        }
    }
}
