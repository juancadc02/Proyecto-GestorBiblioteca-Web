using DAL;
using DAL.Modelo;
using Microsoft.AspNetCore.Mvc;
using Proyecto_GestorBiblioteca_Web.Models;
using System.Diagnostics;

namespace Proyecto_GestorBiblioteca_Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        private readonly servicioConsultasImpl servicioConsultas;
        public HomeController(ILogger<HomeController> logger)
        {
            servicioConsultas = new servicioConsultasImpl();

            //Autores nuevoAutor = new Autores("Juan Carlos", "Dorado");
            //servicioConsultas.insertarAutor(nuevoAutor);
            //servicioConsultas.listartAutores();
            //servicioConsultas.borrarAutorPorId(1);

            //Autores autor = new Autores();
            //List<Autores> lista = new List<Autores>();
            
            //Editoriales editorialLibro = new Editoriales(1);
            //Generos generoLibro = new Generos(1);
            //Colecciones coleccionLibro = new Colecciones(1);
            //Libros nuevoLibro = new Libros("ISBN", "NOMBRE", "EDICION", editorialLibro.id_editoriales, generoLibro.id_genero, coleccionLibro.id_colecciones,lista);

            //servicioConsultas.insertarLibro(nuevoLibro, 1);
            //servicioConsultas.listarLibros();
            //servicioConsultas.borrarLibroPorId(8);
           





           

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}