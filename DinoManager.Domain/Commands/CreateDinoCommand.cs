using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace DinoManager.Domain.Commands
{
    public class CreateDinoCommand : ICommandDefinition
    {
        public string Espece { get; }
        public int Poids { get; }
        public int Taille { get; }

        public CreateDinoCommand(string espece, int poids, int taille)
        {
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }
    }
}
