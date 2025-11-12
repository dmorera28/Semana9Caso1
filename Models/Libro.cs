using System.ComponentModel.DataAnnotations;


namespace Semana9Caso1.Models
{
    public class Libro
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Categoria { get; set; }

        public DateTime AñoPublic { get; set; }

        public int NumPag { get; set; }

        public string Cod { get; set; }

        public bool Disponible { get; set; }
    }
}
