using Microsoft.AspNetCore.Mvc;
using Semana9Caso1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Semana9Caso1.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libro> listaLibros = new List<Libro>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(listaLibros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro nuevoLibro)
        {
            if (string.IsNullOrWhiteSpace(nuevoLibro.Titulo) || nuevoLibro.Titulo.Length < 3)
                ModelState.AddModelError("Titulo", "El título es obligatorio y debe tener al menos 3 caracteres");

            if (string.IsNullOrWhiteSpace(nuevoLibro.Autor) || nuevoLibro.Autor.Length < 3)
                ModelState.AddModelError("Autor", "El autor es obligatorio y debe tener al menos 3 caracteres");

            if (string.IsNullOrWhiteSpace(nuevoLibro.Categoria) || nuevoLibro.Categoria == "Seleccione...")
                ModelState.AddModelError("Categoria", "Debe seleccionar una categoría válida");

            if (nuevoLibro.AñoPublic.Year < 1900 || nuevoLibro.AñoPublic.Year > DateTime.Now.Year)
                ModelState.AddModelError("AñoPublic", "El año de publicación debe estar entre 1900 y el año actual, y no puede ser futuro");

            if (nuevoLibro.NumPag <= 0)
                ModelState.AddModelError("NumPag", "El número de páginas debe ser mayor que 0");

            if (string.IsNullOrWhiteSpace(nuevoLibro.Cod))
            {
                ModelState.AddModelError("Cod", "El código interno es obligatorio");
            }
            else
            {
                if (!Regex.IsMatch(nuevoLibro.Cod, @"^LIB-\d{3}$"))
                    ModelState.AddModelError("Cod", "El código debe tener el formato LIB-###");

                if (listaLibros.Any(l => l.Cod == nuevoLibro.Cod))
                    ModelState.AddModelError("Cod", "El código ya existe en la lista");
            }

            if (ModelState.IsValid)
            {
                listaLibros.Add(nuevoLibro);
                return RedirectToAction("Index");
            }

            return View(nuevoLibro);
        }
    }
}
