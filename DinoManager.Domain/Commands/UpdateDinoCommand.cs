using Tools.Cqs.Commands;

namespace DinoManager.Domain.Commands
{
    public class UpdateDinoCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Espece { get; }
        public int Poids { get; }
        public int Taille { get; }
        public UpdateDinoCommand(int id, string espece, int poids, int taille)
        {
            Id = id;
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }
    }
}
