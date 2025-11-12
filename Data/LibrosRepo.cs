using Semana9Caso1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Semana9Caso1.Data
{
    public class LibrosRepo
    {
        private static List<Libro> _libros = new List<Libro>();

        public List<Libro> ObtenerTodos() => _libros;

        public bool Agregar(Libro libro)
        {
            if (_libros.Any(l => l.Cod.Equals(libro.Cod, System.StringComparison.OrdinalIgnoreCase)))
                return false;

            _libros.Add(libro);
            return true;
        }
    }
}

