using Microsoft.AspNetCore.Mvc;
using Semana9Caso1.Models;
using Semana9Caso1.Data;
using System;
using System.Collections.Generic;

namespace Semana9Caso1.Controllers
{
    public class LibrosController : Controller
    {
        private readonly LibrosRepo _repositorio = new LibrosRepo();

        public IActionResult Index()
        {
            var libros = _repositorio.ObtenerTodos();
            return View(libros);
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = ObtenerCategorias();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            ViewBag.Categorias = ObtenerCategorias();

            if (libro.Categoria == "Seleccione...")
                ModelState.AddModelError("Categoria", "Debe seleccionar una categoría válida.");

            int añoActual = DateTime.Now.Year;
            if (libro.AñoPublic.Year < 1900 || libro.AñoPublic.Year > añoActual)
                ModelState.AddModelError("AñoPublic", $"El año debe estar entre 1900 y {añoActual}.");

            if (libro.NumPag <= 0)
                ModelState.AddModelError("NumPag", "El número de páginas debe ser mayor que 0.");

            if (!ModelState.IsValid)
                return View(libro);

            if (!_repositorio.Agregar(libro))
            {
                ModelState.AddModelError("Cod", "El código interno ya existe en el registro.");
                return View(libro);
            }

            TempData["Mensaje"] = "Libro agregado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private List<string> ObtenerCategorias()
        {
            return new List<string>
            {
                "Seleccione...",
                "Drama",
                "Acción",
                "Terror",
                "Romance",
                "Comedia",
                "Otro"
            };
        }
    }
}



