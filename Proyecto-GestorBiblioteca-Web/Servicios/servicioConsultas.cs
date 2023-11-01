using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Interfaz que define los metodos de consulta sobre la base de datos gestorBibliotecaC
    /// </summary>
    public interface servicioConsultas
    {
        #region CRUD AUTORES
        /// <summary>
        /// Interfaz del metodo que inserta un nuevo autor en la base de datos.
        /// </summary>
        /// <param name="nuevoAutor"></param>
        public void insertarAutor(Autores nuevoAutor);
        /// <summary>
        /// Interfaz de metodo que devuelve un listado de todos los autores de la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<Autores> listartAutores();
        /// <summary>
        /// Interfaz de metodo que elimina un autor de la base de datos por el id del autor
        /// </summary>
        /// <param name="idAutor"></param>
        public void borrarAutorPorId(int idAutor);
        #endregion

        #region CRUD LIBRO

        public void insertarLibro(Libros nuevoLibro);
        public List<Libros> listarLibros();
        public void borrarLibroPorId(int idLibro);

        #endregion

        public void insertarRelAutoresLibros(Rel_Autores_Libros rel_autores_libros);
    }
}
