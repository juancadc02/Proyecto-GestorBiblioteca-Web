using DAL;
using DAL.Modelo;
using Microsoft.AspNetCore.Mvc;
using Proyecto_GestorBiblioteca_Web.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Proyecto_GestorBiblioteca_Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        private readonly servicioConsultasImpl servicioConsultas;
        public HomeController(ILogger<HomeController> logger)
        {
            servicioConsultas = new servicioConsultasImpl();

            //PRUEBA CRUD AUTORES
            //Autores nuevoAutor = new Autores("Juan Carlos", "Dorado");
            //servicioConsultas.insertarAutor(nuevoAutor);
            //servicioConsultas.listartAutores();
            //servicioConsultas.borrarAutorPorId(1);

            //PRUEBA  LIBRO
            //Autores autor = new Autores();
            //List<Autores> lista = new List<Autores>();
            //Editoriales editorialLibro = new Editoriales(1);
            //Generos generoLibro = new Generos(1);
            //Colecciones coleccionLibro = new Colecciones(1);
            //Libros nuevoLibro = new Libros("ISBN", "NOMBRE", "EDICION", editorialLibro.id_editoriales, generoLibro.id_genero, coleccionLibro.id_colecciones,lista);
            //servicioConsultas.insertarLibro(nuevoLibro, 1);
            //servicioConsultas.listarLibros();
            //servicioConsultas.borrarLibroPorId(8);

            //PRUEBA CRUD EDITORIAL
            //Editoriales nuevaEditorial = new Editoriales("Nombre Editorial");
            //servicioConsultas.insertarEditorial(nuevaEditorial);

            //PRUEBA CRUD GENEROS
            //Generos nuevoGenero = new Generos("Nombre Genero", "Descripcion Genero");
            //servicioConsultas.insertarGenero(nuevoGenero);

            //PRUEBA CRUD COLECCIONES
            //Colecciones nuevaColeccion = new Colecciones("Nueva Coleccion");
            //servicioConsultas.insertarColecciones(nuevaColeccion);





            //PRUEBA CRUD PRESTAMO
            List<Libros> listaLibro = new List<Libros>();   
            DateTime fch_inicio_prestamo = DateTime.Now.ToUniversalTime(); 
            DateTime fch_fin_prestamo = DateTime.Now.ToUniversalTime(); 
            DateTime fch_entrega_prestamo = DateTime.Now.ToUniversalTime(); 
            Prestamos nuevoPrestamos = new Prestamos(1, 1,fch_inicio_prestamo,fch_fin_prestamo,fch_entrega_prestamo,1,listaLibro);
            servicioConsultas.insertarPrestamos(nuevoPrestamos, 1);
            servicioConsultas.listaPrestamos();


            //PRUEBA CRUD ESTADO_PRESTAMO
            //Estamos_Prestamo nuevoEstado = new Estamos_Prestamo(1, "Aceptado");
            //servicioConsultas.insertarEstadoPrestamo(nuevoEstado);

            //PRUEBA CRUD USUARIO
            //DateTime fch_fin_bloqueo_usuario = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_alta_usuario = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_baja_usuario = DateTime.Now.ToUniversalTime();
            //Usuarios nuevoUsuario = new Usuarios("29533625S","Juan Carlos","Dorado Castro","658257359","juancarlosdorado02c@gmail.com","123",1,true, fch_fin_bloqueo_usuario, fch_alta_usuario, fch_baja_usuario);
            //servicioConsultas.insertarUsuario(nuevoUsuario);
            //PRUEBA CRUD ACCESO
            //Accesos nuevoAcceso = new Accesos("ac", "Aceptado");
            //servicioConsultas.insertarAccesos(nuevoAcceso);



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