using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class servicioConsultasImpl : servicioConsultas
    {
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

        public void insertarLibro(Libros nuevoLibro)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                
                nuevoLibro = new Libros
                {
                    isbn_libro=nuevoLibro.isbn_libro,
                    nombre_libro=nuevoLibro.nombre_libro,
                    edicion_libro=nuevoLibro.edicion_libro,
                    id_editorial=nuevoLibro.id_editorial,
                    id_genero=nuevoLibro.id_genero,
                    id_coleccion=nuevoLibro.id_coleccion
                };
                contexto.Libros.Add(nuevoLibro);
                contexto.SaveChanges();
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

        public void insertarRelAutoresLibros(Rel_Autores_Libros rel_autores_libros)
        {
            using(var contexto = new gestorBibliotecaDbContext())
            {
                var autor = new Autores();
                var libros = new Libros();
                rel_autores_libros = new Rel_Autores_Libros
                {
                    id_autor=autor.id_autor,
                    id_libro=libros.id_libro
                };
                contexto.Rel_Autores_Libros.Add(rel_autores_libros);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\t Se ha añadido a la tabla Rel_Autores_Libros el idAutor{0} y el idLibro{1}",rel_autores_libros.id_autor,rel_autores_libros.id_libro);
            }
        }
    }
}
