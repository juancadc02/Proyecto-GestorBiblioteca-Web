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
        [ForeignKey("editoriales")]
        public int id_editorial { get; set; }
        [ForeignKey("generos")]
        public int id_genero { get; set; }
        [ForeignKey("coleccion")]
        public int id_coleccion {  get; set; }


        // Propiedad de navegación para la relación rel_autores_libros
        public ICollection<Rel_Autores_Libros> RelacionesAutoresLibros { get; set; }


        // Propiedad de navegación para la relación con Editorial
        public Editoriales editoriales { get; set; }


    }
}
