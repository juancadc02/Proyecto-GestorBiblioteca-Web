using DAL.Modelo;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Autores autorModificar = contexto.Autores.FirstOrDefault(a=>a.id_autor==idAutor);

                if (idAutor != null)
                {
                    autorModificar.nombre_autor= nuevoNombre;
                    contexto.SaveChanges();
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
            throw new NotImplementedException();
        }

        public List<Estamos_Prestamo> listaEstadoPrestamo()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Usuarios> listaUsuarios()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Accesos> listaAccesos()
        {
            throw new NotImplementedException();
        }

       
        #endregion






    }
}
