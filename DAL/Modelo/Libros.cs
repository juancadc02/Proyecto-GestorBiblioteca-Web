using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Libros
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_libro {  get; set; }
        public string isbn_libro { get; set; }
        public string nombre_libro { get; set; }
        public string edicion_libro { get; set; }
        [ForeignKey("Editoriales")]
        public int id_editorial { get; set; }
        [ForeignKey("Generos")]
        public int id_genero { get; set; }
        [ForeignKey("Colecciones")]
        public int id_coleccion {  get; set; }


        // Propiedad de navegación para la relación rel_autores_libros
       //public ICollection<Rel_Autores_Libros> RelacionesAutoresLibros { get; set; }


        // Propiedad de navegación para la relación con Editorial
        public Editoriales Editoriales { get; set; }
        public Generos Generos { get; set; }
        public Colecciones Colecciones { get; set;}

      
        public Libros( string isbn_libro, string nombre_libro, string edicion_libro, int id_editorial, int id_genero, int id_coleccion)
        {
            
            this.isbn_libro = isbn_libro;
            this.nombre_libro = nombre_libro;
            this.edicion_libro = edicion_libro;
            this.id_editorial = id_editorial;
            this.id_genero = id_genero;
            this.id_coleccion = id_coleccion;
           
        }

        public Libros()
        {
        }
    }
}
