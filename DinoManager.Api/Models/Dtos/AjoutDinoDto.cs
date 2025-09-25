using System.ComponentModel.DataAnnotations;

namespace DinoManager.Api.Models.Dtos
{
    public class AjoutDinoDto
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Espece { get; }

        [Range(1, int.MaxValue)]
        public int Poids { get; }

        [Range(1, int.MaxValue)]
        public int Taille { get; }

        public AjoutDinoDto(string espece, int poids, int taille)
        {
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }
    }
}
