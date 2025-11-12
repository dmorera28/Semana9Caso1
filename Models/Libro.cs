using System.ComponentModel.DataAnnotations;

namespace Semana9Caso1.Models
{
    public class Libro
    {
        [Required(ErrorMessage = "El título del libro es obligatorio")]
        [MinLength(3, ErrorMessage = "El título del libro debe tener como mínimo 3 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "El autor del libro debe tener como mínimo 3 caracteres")]
        public string Autor { get; set; } = string.Empty;

        [Required]
        
        public string Categoria { get; set; } = string.Empty;

        [Required]
        public DateTime AñoPublic { get; set; } = DateTime.Now;

        [Required]
        
        public int NumPag { get; set; }

        [Required]
        public string Cod { get; set; } = string.Empty;

        [Required]
        public bool Disponible { get; set; } = true;
    }
}
