using System.ComponentModel.DataAnnotations;

namespace DinoManager.Api.Models.Dtos
{
    public class UpdateDinoDto
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Espece { get; }

        [Range(1, int.MaxValue)]
        public int Poids { get; }

        [Range(1, int.MaxValue)]
        public int Taille { get; }

        public UpdateDinoDto(string espece, int poids, int taille)
        {
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }
    }
}
