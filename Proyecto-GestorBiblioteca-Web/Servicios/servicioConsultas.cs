﻿using DAL.Modelo;
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
        /// <summary>
        /// Interfaz del metodo que modifica el nombre del autor a traves de su id.
        /// </summary>
        public void modificarNombreAutor(int idAutor,string nuevoNombre);
        #endregion


        #region CRUD LIBRO

        /// <summary>
        /// Interza del metodo que inserta un nuevo libro en la base de datos y inserta en la tabla
        /// REL_AUTORES_LIBROS el idLibro y el idAutor del libro
        /// Recibe (El objeto nuevoLibro,idAutor del libro nuevo)
        /// </summary>
        /// <param name="nuevoLibro"></param>
        /// <param name="idAutor"></param>
        public void insertarLibro(Libros nuevoLibro,int idAutor);
        /// <summary>
        /// Interfaz del metodo que devuelve el listado de libros de la base de datos.
        /// </summary>
        /// <returns>Devuelve el listado de libros </returns>
        public List<Libros> listarLibros();
        /// <summary>
        /// Interfaz del metodo que elimina un libro de la base de datos a traves del id
        /// Recibe (idLibro)
        /// </summary>
        /// <param name="idLibro"></param>
        public void borrarLibroPorId(int idLibro);

        #endregion

        #region CRUD EDITORIALES
        /// <summary>
        /// Interfaz del metodo que inserta una nueva editorial en la base de datos.
        /// Recibe (El objeto nuevaEditorial)
        /// </summary>
        /// <param name="nuevaEditorial"></param>
        public void insertarEditorial(Editoriales nuevaEditorial);
        /// <summary>
        /// Interfaz del metodo que elimina una editorial de la base de datos a traves del id.
        /// Recibe(idEditorial)
        /// </summary>
        /// <param name="idEditorialPorId"></param>
        public void borrarEditorialPorId(int idEditorialPorId);
        /// <summary>
        /// Interfaz del metodo que devuelve el listado de editoriales de la base de datos.
        /// </summary>
        /// <returns>Devuelve el listado de editoriales</returns>
        public List<Editoriales> listarEditoriales();
        #endregion

        #region CRUD GENEROS
        /// <summary>
        /// Interfaz del metodo que inserta un nuevo genero en la base de datos.
        /// Recibe(El objeto nuevoGenero)
        /// </summary>
        /// <param name="nuevoGenero"></param>
        public void insertarGenero(Generos nuevoGenero);
        /// <summary>
        /// Interfaz del metodo que elimina un genero de la base de datos a traves del id
        /// Recibe(idGenero)
        /// </summary>
        /// <param name="generoId"></param>
        public void borrarGeneroPorId(int generoId);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de generos de la base de datos
        /// </summary>
        /// <returns>Devuelve el listado de generos</returns>
        public List<Generos> listarGeneros();
        #endregion

        #region CRUD COLECCIONES
        /// <summary>
        /// Interfaz del metodo que inserta una nueva coleccion en la base de datos.
        /// Recibe(El objeto nuevaColeccion)
        /// </summary>
        /// <param name="nuevaColeccion"></param>
        public void insertarColecciones(Colecciones nuevaColeccion);
        /// <summary>
        /// Interfaz del metodo que elimina una coleccion de la base de datos a traves del id
        /// Recibe(idColeccion)
        /// </summary>
        /// <param name="idColeccionEliminar"></param>
        public void eliminarColeccionPorId(int idColeccionEliminar);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de colecciones de la base de datos 
        /// </summary>
        /// <returns>Devuelve el listado de colecciones</returns>
        public List<Colecciones> listaColecciones();
        #endregion
        #region CRUD PRESTAMOS
        /// <summary>
        /// Interfaz del metodo que inserta un nuevo prestamo en la base de datos y inserta en la tabla
        /// REL_LIBROS_PRESTAMOS el idPrestamo y el idLibro
        /// Recibe(El objeto nuevoPrestamo y el idLibro)
        /// </summary>
        /// <param name="nuevoPrestamo"></param>
        /// <param name="idLibro"></param>
        public void insertarPrestamos(Prestamos nuevoPrestamo, int idLibro);
        /// <summary>
        /// Interfaz del metodo que elimina un prestamo de la base de datos a traves del id
        /// Recibe(idPrestamo)
        /// </summary>
        /// <param name="idPrestamo"></param>
        public void borrarPrestamoId(int idPrestamo);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de prestamos de la base de datos
        /// </summary>
        /// <returns>Devuelve el listado de prestamos</returns>
        public List<Prestamos> listaPrestamos();

        #endregion

        #region CRUD ESTADO_PRESTAMO

        /// <summary>
        /// Interfaz del metodo que inserta en la base de datos un nuevo estado
        /// Recibe(El objeto nuevoPrestamo)
        /// </summary>
        /// <param name="nuevaEstado"></param>
        public void insertarEstadoPrestamo(Estamos_Prestamo nuevaEstado);
        /// <summary>
        /// Interfaz del metodo que elimina de la base de datos un estado a traves del id
        /// Recibe(idEstado)
        /// </summary>
        /// <param name="idEstadoPrestamo"></param>
        public void borrarEstadoPrestamoPorId(int idEstadoPrestamo);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de estado de la base de datos 
        /// </summary>
        /// <returns>Devulve listad de estado</returns>
        public List<Estamos_Prestamo> listaEstadoPrestamo();

        #endregion

        #region CRUD USUARIOS
        /// <summary>
        /// Interfaz del metodo que inserta en la base de datos un nuevo usuario
        /// Recibe(El objeto nuevoUsuario)
        /// </summary>
        /// <param name="nuevoUsuario"></param>
        public void insertarUsuario(Usuarios nuevoUsuario);
        /// <summary>
        /// Interfaz del metodo que elimina de la base de datos un usuario a traves del id
        /// Recibe(idUsuario)
        /// </summary>
        /// <param name="idUsuario"></param>
        public void borrarUsuarioPorId(int idUsuario);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de usuario de la base de datos 
        /// </summary>
        /// <returns>Devuelve listado de usuarios</returns>
        public List<Usuarios> listaUsuarios();
        #endregion

        #region CRUD ACCESOS

        /// <summary>
        /// Interfaz del metodo que inserta en la base de datos un nuevo acceso
        /// Recibe(El objeto nuevoAcceso)
        /// </summary>
        /// <param name="nuevoAcceso"></param>
        public void insertarAccesos(Accesos nuevoAcceso);
        /// <summary>
        /// Interfaz del metodo que elimina de la base de datos un acceso a traves del id
        /// Recibe(idAcceso)
        /// </summary>
        /// <param name="idAcceso"></param>
        public void borrarAccesoPorId(int idAcceso);
        /// <summary>
        /// Interfaz del metodo que devuelve un listado de acceso de la base de datos 
        /// </summary>
        /// <returns>Devuelve listado de acceso</returns>
        public List<Accesos> listaAccesos();
        #endregion
    }


}
