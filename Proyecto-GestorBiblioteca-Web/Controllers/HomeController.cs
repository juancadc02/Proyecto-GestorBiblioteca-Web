using DAL;
using DAL.Modelo;
using DAL.Servicios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_GestorBiblioteca_Web.Models;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace Proyecto_GestorBiblioteca_Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        private readonly servicioConsultasImpl servicioConsultas;
        private readonly servicioEncriptarContraseñaImpl servicioEncriptarContraseña;
        public HomeController(ILogger<HomeController> logger)
        {
            servicioEncriptarContraseña = new servicioEncriptarContraseñaImpl();
            servicioConsultas = new servicioConsultasImpl();




            //PRUEBA CRUD AUTORES
            //Autores nuevoAutor = new Autores("Juan Carlos", "Dorado");
            //servicioConsultas.insertarAutor(nuevoAutor);
            //servicioConsultas.listartAutores();
            //servicioConsultas.borrarAutorPorId(1);
            //servicioConsultas.modificarNombreAutor(1, "NuevoNombre");
            //servicioConsultas.modificarApellidosAutor(1, "NuevoApellido");

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
            //List<Libros> listaLibro = new List<Libros>();   
            //DateTime fch_inicio_prestamo = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_fin_prestamo = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_entrega_prestamo = DateTime.Now.ToUniversalTime(); 
            //Prestamos nuevoPrestamos = new Prestamos(1, 1,fch_inicio_prestamo,fch_fin_prestamo,fch_entrega_prestamo,1,listaLibro);
            //servicioConsultas.insertarPrestamos(nuevoPrestamos, 1);
            //
            //servicioConsultas.listaPrestamos();


            //PRUEBA CRUD ESTADO_PRESTAMO
            //Estamos_Prestamo nuevoEstado = new Estamos_Prestamo(1, "Aceptado");
            //servicioConsultas.insertarEstadoPrestamo(nuevoEstado);

            //PRUEBA CRUD USUARIO
            //DateTime fch_fin_bloqueo_usuario = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_alta_usuario = DateTime.Now.ToUniversalTime(); 
            //DateTime fch_baja_usuario = DateTime.Now.ToUniversalTime();
            //string contraseñaEncriptada = servicioEncriptarContraseña.EncriptarContraseña("Hola");
            //Usuarios nuevoUsuario = new Usuarios("29533625S","Juan Carlos","Dorado Castro","658257359","juancarlosdorado02c@gmail.com", contraseñaEncriptada, 1,true, fch_fin_bloqueo_usuario, fch_alta_usuario, fch_baja_usuario);
            //servicioConsultas.insertarUsuario(nuevoUsuario);
            //PRUEBA CRUD ACCESO
            //Accesos nuevoAcceso = new Accesos("ac", "Aceptado");
            //servicioConsultas.insertarAccesos(nuevoAcceso);

            string apiUrl = "https://localhost:7268/api/ControladorUsuarios";

          

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Realiza una solicitud GET a la API y obtén la respuesta como una cadena JSON
                    string jsonResponse = client.DownloadString(apiUrl);

                    // Deserializa los datos JSON en una lista de objetos Usuario
                    Usuarios[] usuarios = JsonConvert.DeserializeObject<Usuarios[]>(jsonResponse);

                    // Muestra los datos de usuarios en el formato deseado
                    foreach (Usuarios usuario in usuarios)
                    {
                        Console.WriteLine("Id: " + usuario.id_usuario);
                        Console.WriteLine("Nombre: " + usuario.nombre_usuario);
                        Console.WriteLine("Apellidos: " + usuario.apellidos_usuario);
                        Console.WriteLine("Correo: " + usuario.email_usuario);
                        Console.WriteLine("Dni: " + usuario.dni_usuario);
                        Console.WriteLine("Telefono: " + usuario.tlf_usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

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