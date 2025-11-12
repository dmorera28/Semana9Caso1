using System.ComponentModel.DataAnnotations;

namespace Semana9Caso1.Models
{
    public class Libro
    {
        [Required(ErrorMessage = "El título del libro es obligatorio")]
        [MinLength(3, ErrorMessage = "El título del libro debe tener como mínimo 3 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar el nombre del autor del libro")]
        [MinLength(3, ErrorMessage = "El autor del libro debe tener como mínimo 3 caracteres")]
        public string Autor { get; set; } = string.Empty;

        [Required]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar el año de publicación del libro")]
        [DataType(DataType.Date)]
        public DateTime AñoPublic { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Debe ingresar el número de páginas del libro")]
        public int NumPag { get; set; }

        [Required(ErrorMessage = "Debe ingresar el código del libro")]
        [RegularExpression(@"^(LIB)-\d+$", ErrorMessage = "El código del libro debe comenzar con ´LIB-´ en mayúsculas antes de ingresar los números correspondientes")]
        public string Cod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe indicar la disponibilidad del libro")]
        public bool Disponible { get; set; } = true;
    }
}
