using System.ComponentModel.DataAnnotations;
using WebAPI.Services;

namespace WebAPI.Models
{
    public class FilmBody
    {
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(100, ErrorMessage = "Tytuł może mieć maksymalnie 100 znaków.")]
        public string Tytul { get; set; } = null!;

        [Required(ErrorMessage = "Reżyser jest wymagany.")]
        public string Rezyser { get; set; } = null!;

        [Required(ErrorMessage = "Gatunek jest wymagany.")]
        [GenreValidation]
        public string Gatunek { get; set; } = null!;

        [Range(0, 2025, ErrorMessage = "Rok wydania nie może być większy niż 2025.")]
        public int Rok_wydania { get; set; }
    }
}
