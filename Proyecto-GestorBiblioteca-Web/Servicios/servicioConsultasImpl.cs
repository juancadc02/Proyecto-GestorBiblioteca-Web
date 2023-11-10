using DAL.Modelo;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class servicioConsultasImpl : servicioConsultas
    {
        #region CRUD AUTORES
        public void insertarAutor(Autores nuevoAutor)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                 nuevoAutor = new Autores
                {
                    nombre_autor=nuevoAutor.nombre_autor,
                    apellidos_autor=nuevoAutor.apellidos_autor
                };
                contexto.Autores.Add(nuevoAutor);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tAutor insertado: {0},{1}",nuevoAutor.nombre_autor,nuevoAutor.apellidos_autor);
            }
        }
        public List<Autores> listartAutores()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaAutores= contexto.Autores.ToList();

                if (listaAutores.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun autor.");
                }
                else
                {
                    Console.WriteLine("\nLista de autores:");

                    foreach(var autores in listaAutores)
                    {
                        Console.WriteLine("\n\n\t{0}  {1}  {2}",autores.id_autor,autores.nombre_autor,autores.apellidos_autor);
                    }
                }
                return listaAutores;
            }
        }
        public void borrarAutorPorId(int idAutor)
        {
           using(var contexto = new gestorBibliotecaDbContext())
            {
                var autorEliminarPorId = contexto.Autores.SingleOrDefault(l=>l.id_autor == idAutor);

                if (autorEliminarPorId != null)
                {
                    contexto.Autores.Remove(autorEliminarPorId);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tSe ha eliminado correctamente el autor: {0} {1} {2}",autorEliminarPorId.id_autor,autorEliminarPorId.nombre_autor,autorEliminarPorId.apellidos_autor);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado el autor");
                }
            }


        }
        public void modificarNombreAutor(int idAutor, string nuevoNombre)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var autorModificar = contexto.Autores.FirstOrDefault(a=>a.id_autor==idAutor);

                if (idAutor != null)
                {
                    autorModificar.nombre_autor= nuevoNombre;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tNombre actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el autor");
                }
            }
        }
        public void modificarApellidosAutor(int idAutor, string nuevoApellido)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var autorModificar = contexto.Autores.FirstOrDefault(a => a.id_autor == idAutor);

                if (idAutor != null)
                {
                    autorModificar.apellidos_autor = nuevoApellido;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tApellido actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el autor");
                }
            }
        }


        #endregion

        #region CRUD Libros
        public void insertarLibro(Libros nuevoLibro, int idAutor)
        {
            using (var context = new gestorBibliotecaDbContext())
            {
                //busco el id del autor
                Autores autor = context.Autores.Find(idAutor);

                if (autor != null)
                {
                    // Añadir el autor al libro
                    nuevoLibro.Autores.Add(autor);

                    // Agregar el libro a la base de datos
                    context.Libros.Add(nuevoLibro);

                    context.SaveChanges();
                }
            }

        }
        public List<Libros> listarLibros()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaLibro=contexto.Libros.ToList();

                if (listaLibro.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun libro");
                }
                else
                {
                    foreach(var libro in listaLibro)
                    {
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",libro.id_libro,libro.isbn_libro,libro.nombre_libro,libro.edicion_libro,libro.id_editorial,libro.id_genero,libro.id_coleccion);
                    }
                }
                return listaLibro;
            }
        }
        public void borrarLibroPorId(int idLibro)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var libroEliminarPorId = contexto.Libros.SingleOrDefault(l => l.id_libro == idLibro);

                if (libroEliminarPorId != null)
                {
                    contexto.Libros.Remove(libroEliminarPorId);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tSe ha eliminado correctamente el libro: {0} {1} {2}", libroEliminarPorId.id_libro, libroEliminarPorId.isbn_libro, libroEliminarPorId.nombre_libro);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado el libro");
                }


            }
        }
        public void modificarIsbnLibro(int idLibro, string nuevoIsbn)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var isbnLibroModificar = contexto.Libros.FirstOrDefault(l=>l.id_libro==idLibro);

                if (isbnLibroModificar != null)
                {
                    isbnLibroModificar.isbn_libro = nuevoIsbn;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t ISBN actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ningun libro con id:{0}",idLibro);
                }
            }
        }

        public void modificarTituloLibro(int idLibro, string nuevoTitulo)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var tituloLibroModificar = contexto.Libros.FirstOrDefault(l=>l.id_libro==idLibro);

                if (tituloLibroModificar != null)
                {
                    tituloLibroModificar.nombre_libro = nuevoTitulo;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tTitulo actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ningun libro con id:{0}", idLibro);
                }
            }
        }

        public void modificarEdicionLibro(int idLibro, string nuevaEdicion)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var edicionLibroModificar=contexto.Libros.FirstOrDefault(l=>l.id_libro== idLibro);

                if (edicionLibroModificar != null)
                {
                    edicionLibroModificar.edicion_libro= nuevaEdicion;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tEdicion actualizada");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ningun libro con id:{0}", idLibro);
                }
            }
        }
        #endregion

        #region CRUD EDITORIAL
        public void insertarEditorial(Editoriales nuevaEditorial)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                nuevaEditorial = new Editoriales
                {
                    nombre_editorial = nuevaEditorial.nombre_editorial
                };

                contexto.Editoriales.Add(nuevaEditorial);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\t Nueva editorial: IdEditorio: {0} NombreEditorial:{1}",nuevaEditorial.id_editoriales,nuevaEditorial.nombre_editorial);
            }
        }

        public void borrarEditorialPorId(int idEditorialPorId)
        {
           using(var contexto = new gestorBibliotecaDbContext())
            {
                var editorialEliminarId=contexto.Editoriales.SingleOrDefault(l=>l.id_editoriales==idEditorialPorId);

                if (idEditorialPorId != null)
                {
                    contexto.Editoriales.Remove(editorialEliminarId);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Se ha eliminado la editorial: IdEditorial:{0} ",idEditorialPorId);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado la editorial");
                }
            }

        }

        public List<Editoriales> listarEditoriales()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaEditoriales =contexto.Editoriales.ToList();

                if (listaEditoriales.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ninguna editorial");
                }
                else
                {
                    foreach(var editorial in listaEditoriales)
                    {
                        Console.WriteLine("\n\n\t{0} {1}",editorial.id_editoriales,editorial.nombre_editorial);
                    }
                }
                return listaEditoriales;
            }
        }

        public void modificarNombreEditorial(int idEditorial, string nuevoNombreEditorial)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var nombreEditorialModificar = contexto.Editoriales.FirstOrDefault(e=>e.id_editoriales==idEditorial);

                if (nombreEditorialModificar != null)
                {
                    nombreEditorialModificar.nombre_editorial= nuevoNombreEditorial;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tNombre editorial actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ninguna editorial con id:{0}", idEditorial);
                }
            }
        }
        #endregion

        #region CRUD GENERO
        public void insertarGenero(Generos nuevoGenero)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                nuevoGenero = new Generos
                {
                    nombre_genero=nuevoGenero.nombre_genero,
                    descripcion_genero=nuevoGenero.descripcion_genero
                };

                contexto.Generos.Add(nuevoGenero);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\t Nuevo genero: IdGenero:{0} NombreGenero:{1} DescripcionGenero:{2}",nuevoGenero.id_genero,nuevoGenero.nombre_genero,nuevoGenero.descripcion_genero);
            }
        }

        public void borrarGeneroPorId(int generoId)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var generoBorrarId = contexto.Generos.SingleOrDefault(l => l.id_genero == generoId);

                if( generoBorrarId != null )
                {
                    contexto.Generos.Remove(generoBorrarId );
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tSe ha borrado el genero: IdGenero:{0}",generoBorrarId);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado el genero");
                }
            }
        }

        public List<Generos> listarGeneros()
        {
           using(var contexto= new gestorBibliotecaDbContext())
            {
                var listaGenero = contexto.Generos.ToList();

                if (listaGenero.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun dato.");
                }
                else
                {
                    foreach(var genero in listaGenero)
                    {
                        Console.WriteLine("\n\n\t {0} {1} {2}",genero.id_genero,genero.nombre_genero,genero.descripcion_genero);
                    }
                }
                return listaGenero;
            }
        }

        public void modificarNombreGenero(int idGenero, string nuevoNombreGenero)
        {

            using(var contexto = new gestorBibliotecaDbContext())
            {
                var nombreGeneroModificar = contexto.Generos.FirstOrDefault(g => g.id_genero == idGenero);
                if (nombreGeneroModificar != null)
                {
                    nombreGeneroModificar.nombre_genero= nuevoNombreGenero;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tNombre genero actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ningun genero con id:{0}", idGenero);
                }
            }
        }
        public void modificarDescripcionGenero(int idGenero, string nuevaDescripcionGenero)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var descripcionGeneroModificar = contexto.Generos.FirstOrDefault(g=>g.id_genero==idGenero);
                if (descripcionGeneroModificar != null)
                {
                    descripcionGeneroModificar.descripcion_genero = nuevaDescripcionGenero;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tDescripcion genero actualizada");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ningun genero con id:{0}", idGenero);
                }
            }
        }


        #endregion

        #region CRUD COLECCIONES

        public void insertarColecciones(Colecciones nuevaColeccion)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                nuevaColeccion = new Colecciones
                {
                    nombre_coleccion=nuevaColeccion.nombre_coleccion
                };
                contexto.Colecciones.Add(nuevaColeccion);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tNueva coleccion IdColeccion:{0} NombreColeccion:{1}",nuevaColeccion.id_colecciones,nuevaColeccion.nombre_coleccion);
            }
        }

        public void eliminarColeccionPorId(int idColeccionEliminar)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var coleccionBorrarId=contexto.Colecciones.SingleOrDefault(l=>l.id_colecciones==idColeccionEliminar);

                if (coleccionBorrarId != null)
                {
                    contexto.Colecciones.Remove(coleccionBorrarId);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Se ha eliminado la coleccion : IdColeccion:{0}",coleccionBorrarId);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado la coleccion");
                }
            }
        }

        public List<Colecciones> listaColecciones()
        {
            using(var contexto=new gestorBibliotecaDbContext())
            {
                var listaColecciones = contexto.Colecciones.ToList();

                if (listaColecciones.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ninguna coleccion");
                }
                else
                {
                    foreach(var coleccion in listaColecciones)
                    {
                        Console.WriteLine("\n\n\t{0} {1}",coleccion.id_colecciones,coleccion.nombre_coleccion);
                    }
                }
                return listaColecciones;
            }
        }
        public void modificarNombreColeccion(int idColeccion, string nuevoNombreColeccion)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var nombreColeccionModificar = contexto.Colecciones.FirstOrDefault(c=>c.id_colecciones==idColeccion);

                if(nuevoNombreColeccion!=null)
                {
                    nombreColeccionModificar.nombre_coleccion = nuevoNombreColeccion;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tNombre coleccion actualizado.");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se a encontrado ninguna coleccion con id:{0}", idColeccion);
                }
            }
        }

        #endregion

        #region CRUD PRESTAMOS
        public void insertarPrestamos(Prestamos nuevoPrestamo,int idLibro)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                //Busco el id del libro para guardarlo en la tabla Rel_Libros_Prestamos
                Libros libro = contexto.Libros.Find(idLibro);

                if (libro != null)
                {
                    nuevoPrestamo.collectionLibro.Add(libro);

                    contexto.Prestamos.Add(nuevoPrestamo);

                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun libro con ese id.");
                }

            }
        }

        public void borrarPrestamoId(int idPrestamo)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var idEliminar = contexto.Prestamos.Single(l => l.id_prestamos == idPrestamo);

                if (idEliminar != null)
                {
                    contexto.Prestamos.Remove(idEliminar);
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun prestamo con id:{0}",idEliminar);
                }
            }
        }

        public List<Prestamos> listaPrestamos()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaPrestamo = contexto.Prestamos.ToList();

                if (listaPrestamo.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun prestamo");
                }
                else
                {
                    foreach(var prestamo in listaPrestamo)
                    {
                        Console.WriteLine("\n\n\t{0} {1} {2} {3} {4} {5} {6}",prestamo.id_prestamos,prestamo.id_libro,prestamo.id_usuario,prestamo.fch_inicio_prestamo,prestamo.fch_fin_prestamo,prestamo.fch_entrega_prestamo,prestamo.id_estado_prestamo);
                    }
                }
                return listaPrestamo;
            }
        }

        public void modificarFchInicioPrestamo(int idPrestamo, DateTime nuevaFechaInicioPrestamo)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var fechaInicioPrestamoModificar = contexto.Prestamos.FirstOrDefault(p=>p.id_prestamos==idPrestamo);

                if (fechaInicioPrestamoModificar != null)
                {
                    fechaInicioPrestamoModificar.fch_inicio_prestamo = nuevaFechaInicioPrestamo.ToUniversalTime();
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Fecha inicio prestamo actualizada");

                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun prestamo con el id:{0}",idPrestamo);
                }
            }
        }
        public void modificarFchFinPrestamo(int idPrestamo, DateTime nuevaFchFinPrestamo)
        {

            using (var contexto = new gestorBibliotecaDbContext())
            {
                var fechaFinPrestamoModificar = contexto.Prestamos.FirstOrDefault(p => p.id_prestamos == idPrestamo);
                if (fechaFinPrestamoModificar != null)
                {
                    fechaFinPrestamoModificar.fch_inicio_prestamo = nuevaFchFinPrestamo.ToUniversalTime();
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Fecha fin prestamo actualizada");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun prestamo con el id:{0}", idPrestamo);
                }
            }
        }
        public void modificarFchEntregaPrestamo(int idPrestamo, DateTime nuevaFchEntregaPrestamo)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var fechaEntregaPrestamoModificar = contexto.Prestamos.FirstOrDefault(p => p.id_prestamos == idPrestamo);
                if (fechaEntregaPrestamoModificar != null)
                {
                    fechaEntregaPrestamoModificar.fch_entrega_prestamo = nuevaFchEntregaPrestamo;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Fecha entrega prestamo actualizada");


                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun prestamo con el id:{0}", idPrestamo);
                }
            }

        }

        #endregion

        #region CRUD ESTADO_PRESTAMO

        public void insertarEstadoPrestamo(Estamos_Prestamo nuevaEstado)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                nuevaEstado = new Estamos_Prestamo
                {
                    codigo_estado_prestamo = nuevaEstado.codigo_estado_prestamo,
                    descripcion_estado_prestamo=nuevaEstado.descripcion_estado_prestamo
                };

             
                contexto.estamos_Prestamos.Add(nuevaEstado);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tNuevo estado_prestamo {0} {1} {2}",nuevaEstado.id_estado_prestamo,nuevaEstado.codigo_estado_prestamo,nuevaEstado.descripcion_estado_prestamo);
            }
        }

        public void borrarEstadoPrestamoPorId(int idEstadoPrestamo)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var idEstadoPrestamoBorrar = contexto.estamos_Prestamos.SingleOrDefault(e => e.id_estado_prestamo == idEstadoPrestamo);

                if (idEstadoPrestamo != null)
                {
                    contexto.estamos_Prestamos.Remove(idEstadoPrestamoBorrar);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tEstado prestamo borrado {0}", idEstadoPrestamo);
                }
                else
                {
                    Console.WriteLine("\n\n\t No se ha encontrado el idEstadoPrestamo:{0}",idEstadoPrestamo);
                }
            }
        }
        public List<Estamos_Prestamo> listaEstadoPrestamo()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaEstadoPrestamo = contexto.estamos_Prestamos.ToList();

                if (listaEstadoPrestamo.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun estadoPrestamo.");
                }
                else
                {
                    foreach(var estado in listaEstadoPrestamo)
                    {
                        Console.WriteLine("{0} {1} {2}",estado.id_estado_prestamo,estado.codigo_estado_prestamo,estado.descripcion_estado_prestamo);
                    }
                }

                return listaEstadoPrestamo;

            }
        }

        public void modificarCodigoPrestamo(int idEstadoPrestamo, int nuevocodigoEstadoPrestamo)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var codigoEstadoPrestamoModificar=contexto.estamos_Prestamos.FirstOrDefault(e=>e.id_estado_prestamo==idEstadoPrestamo);

                if (codigoEstadoPrestamoModificar != null)
                {
                    codigoEstadoPrestamoModificar.codigo_estado_prestamo = nuevocodigoEstadoPrestamo;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Codigo estado prestamo actualizada");

                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el id del estado prestamo:{0}",idEstadoPrestamo);
                }
            }
        }
        public void modificarDescripcionEstadoPrestamo(int idEstadoPrestamo, string nuevaDescripcionEstadoPrestamo)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var descripcionEstadoPrestamoModificar = contexto.estamos_Prestamos.FirstOrDefault(e => e.id_estado_prestamo == idEstadoPrestamo);

                if (descripcionEstadoPrestamoModificar != null)
                {
                    descripcionEstadoPrestamoModificar.descripcion_estado_prestamo = nuevaDescripcionEstadoPrestamo;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\t Descripcion estado prestamo actualizada");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el id del estado prestamo:{0}", idEstadoPrestamo);
                }
            }
        }




        #endregion

        #region CRUD USUARIO

        public void insertarUsuario(Usuarios nuevoUsuario)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                nuevoUsuario = new Usuarios
                {
                    dni_usuario = nuevoUsuario.dni_usuario,
                    nombre_usuario=nuevoUsuario.nombre_usuario,
                    apellidos_usuario=nuevoUsuario.apellidos_usuario,
                    tlf_usuario=nuevoUsuario.tlf_usuario,
                    email_usuario=nuevoUsuario.email_usuario,
                    clave_usuario=nuevoUsuario.clave_usuario,
                    id_acceso=nuevoUsuario.id_acceso,
                    estaBloqueado_usuario=nuevoUsuario.estaBloqueado_usuario,
                    fch_fin_bloqueo_usuario=nuevoUsuario.fch_fin_bloqueo_usuario,
                    fch_alta_usuario=nuevoUsuario.fch_alta_usuario,
                    fch_baja_usuario=nuevoUsuario.fch_baja_usuario
                };
                contexto.Usuarios.Add(nuevoUsuario);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tNuevo usuario añadido: {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",nuevoUsuario.id_usuario,nuevoUsuario.dni_usuario,nuevoUsuario.nombre_usuario,nuevoUsuario.apellidos_usuario,nuevoUsuario.tlf_usuario,nuevoUsuario.email_usuario,nuevoUsuario.clave_usuario,nuevoUsuario.id_acceso,nuevoUsuario.estaBloqueado_usuario,nuevoUsuario.fch_fin_bloqueo_usuario,nuevoUsuario.fch_alta_usuario,nuevoUsuario.fch_baja_usuario);
            }
        }

        public void borrarUsuarioPorId(int idUsuario)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var idUsuarioBorrar=contexto.Usuarios.SingleOrDefault(u=>u.id_usuario==idUsuario);
                if (idUsuarioBorrar != null)
                {
                    contexto.Usuarios.Remove(idUsuarioBorrar);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tUsuario eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el idUsuario:{0}",idUsuario);
                }
            }
        }

        public List<Usuarios> listaUsuarios()
        {
            using(var contexto= new gestorBibliotecaDbContext())
            {
                var listaUsuarios=contexto.Usuarios.ToList();
                if (listaUsuarios.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun usuario.");
                }
                else
                {
                    foreach(var usuarios in listaUsuarios)
                    {
                        Console.WriteLine("\n\n\t{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", usuarios.id_usuario, usuarios.dni_usuario, usuarios.nombre_usuario, usuarios.apellidos_usuario, usuarios.tlf_usuario, usuarios.email_usuario, usuarios.clave_usuario, usuarios.id_acceso, usuarios.estaBloqueado_usuario, usuarios.fch_fin_bloqueo_usuario, usuarios.fch_alta_usuario, usuarios.fch_baja_usuario);
                    }
                   
                }
                return listaUsuarios;

            }
        }

        public void modificarDniUsuario(int idUsuario, string nuevoDniUsuario)
        {
            using(var contexto =new gestorBibliotecaDbContext())
            {
                var modificarDniUsuario=contexto.Usuarios.FirstOrDefault(u=>u.id_usuario==idUsuario);

                if (modificarDniUsuario != null)
                {
                    modificarDniUsuario.dni_usuario=nuevoDniUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}",idUsuario);
                }
            }
        }

        public void modificarNombreUsuario(int idUsuario, string nuevoNombreUsuario)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var modificarNombreUsuario = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                if (modificarNombreUsuario != null)
                {
                    modificarNombreUsuario.nombre_usuario = nuevoNombreUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}", idUsuario);
                }
            }
        }

        public void modificarApellidosUsuario(int idUsuario, string nuevoApellidosUsuario)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var modificarApellidosUsuario = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                if (modificarApellidosUsuario != null)
                {
                    modificarApellidosUsuario.apellidos_usuario = nuevoApellidosUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}", idUsuario);
                }
            }
        }

        public void modificarTlfUsuario(int idUsuario, string nuevoTlfUsuario)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var modificarTlfUsuario = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                if (modificarTlfUsuario != null)
                {
                    modificarTlfUsuario.tlf_usuario = nuevoTlfUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}", idUsuario);
                }
            }
        }

        public void modificarClaveUsuario(int idUsuario, string nuevaClaveUsuario)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var modificarClaveUsuario = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                if (modificarClaveUsuario != null)
                {
                    modificarClaveUsuario.clave_usuario = nuevaClaveUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}", idUsuario);
                }
            }
        }

        public void modificarEstaBloqueadoUsuario(int idUsuario, bool nuevoBloqueoUsuario)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var modificarEstaBloqueadoUsuario = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                if (modificarEstaBloqueadoUsuario != null)
                {
                    modificarEstaBloqueadoUsuario.estaBloqueado_usuario = nuevoBloqueoUsuario;
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado usuario con id:{0}", idUsuario);
                }
            }
        }
        #endregion


        #region CRUD ACCESOS

        public void insertarAccesos(Accesos nuevoAcceso)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                nuevoAcceso = new Accesos
                {

                    codigo_acceso = nuevoAcceso.codigo_acceso,
                    descripcion_acceso=nuevoAcceso.descripcion_acceso
                };
                contexto.Accesos.Add(nuevoAcceso);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\t Nuevo acceso: {0} {1} {2}",nuevoAcceso.id_acceso,nuevoAcceso.codigo_acceso,nuevoAcceso.descripcion_acceso);
            }
        }

        public void borrarAccesoPorId(int idAcceso)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var accesoIdEliminar = contexto.Accesos.SingleOrDefault(a => a.id_acceso == idAcceso);

                if (accesoIdEliminar != null)
                {
                    contexto.Accesos.Remove(accesoIdEliminar);
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tAcceso eliminado correctamente");

                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el idAcceso:{0}",idAcceso);
                }
            }

        }

        public List<Accesos> listaAccesos()
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var listaAccesos = contexto.Accesos.ToList();

                if (listaAccesos.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado ningun acceso");
                }
                else
                {
                    foreach(var accesos in listaAccesos)
                    {
                        Console.WriteLine("\n\n\t{0} {1} {2}",accesos.id_acceso,accesos.codigo_acceso,accesos.descripcion_acceso);
                    }
                }

                return listaAccesos;
            }
        }

        public void modificarCodigoAcceso(int idAcceso,string nuevoCodigoAcceso)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var codigoAccesoModificar=contexto.Accesos.FirstOrDefault(c=>c.id_acceso==idAcceso);
                if (codigoAccesoModificar != null)
                {
                    codigoAccesoModificar.codigo_acceso = nuevoCodigoAcceso;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tCodigo acceso actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el idAcceso:{0}",idAcceso);
                }
            }
        }
        public void modificarDescripcionAcceso(int idAcceso,string nuevaDescripcionAcceso)
        {
            using (var contexto = new gestorBibliotecaDbContext())
            {
                var descripcionAccesoModificar = contexto.Accesos.FirstOrDefault(c => c.id_acceso == idAcceso);
                if (descripcionAccesoModificar != null)
                {
                    descripcionAccesoModificar.descripcion_acceso = nuevaDescripcionAcceso;
                    contexto.SaveChanges();
                    Console.WriteLine("\n\n\tDescripcion acceso actualizado");
                }
                else
                {
                    Console.WriteLine("\n\n\tNo se ha encontrado el idAcceso:{0}", idAcceso);
                }
            }
        }


        #endregion
        public void listadoAccesoApi(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Realiza una solicitud GET a la API y obtén la respuesta como una cadena JSON
                    string jsonResponse = client.DownloadString(url);

                    // Deserializa los datos JSON en una lista de objetos Usuario
                    Accesos[] accesos = JsonConvert.DeserializeObject<Accesos[]>(jsonResponse);

                    // Muestra los datos de usuarios en el formato deseado
                    foreach (Accesos acceso in accesos)
                    {
                        Console.WriteLine("Id: " + acceso.id_acceso);
                        Console.WriteLine("Codigo: " + acceso.codigo_acceso);
                        Console.WriteLine("Descripcion: " + acceso.descripcion_acceso);


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void listadoUsuariosApi(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Realiza una solicitud GET a la API y obtén la respuesta como una cadena JSON
                    string jsonResponse = client.DownloadString(url);

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
        }

        public bool loginUsuario(string username, string contraseña,string urlApi)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = urlApi;
                // Construir el endpoint para la solicitud, incluyendo el nombre de usuario y la contraseña proporcionados
                string endpoint = $"/auth?username={username}&password={contraseña}";

                // Realizar una solicitud GET a la API concatenando la URL de la API y el endpoint
                HttpResponseMessage response = client.GetAsync(apiUrl + endpoint).Result;

                // Verificar si la solicitud fue exitosa (código de estado HTTP 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer el cuerpo de la respuesta como una cadena
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    // Interpretar la respuesta (en este caso, la API devuelve "true" si las credenciales son correctas)
                    return responseBody.ToLower() == "true"; // Ejemplo: la API devuelve "true" si las credenciales son correctas
                }
                else
                {
                    // Si la solicitud no fue exitosa, devolver false (autenticación fallida)
                    return false;
                }
            }


        }


    }
}
