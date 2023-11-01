using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Rel_Autores_Libros
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_rel_autores_libros {  get; set; }
        [ForeignKey("autores")]
        public int id_autor {  get; set; }
        [ForeignKey("libros")]
        public int id_libro { get; set; }
        

        //Propiedades de las tablas.
        public Autores autores { get; set; }
        public Libros libros { get; set; }

        public Rel_Autores_Libros(int id_autor, int id_libro)
        {
            this.id_autor = id_autor;
            this.id_libro = id_libro;
        }

        public Rel_Autores_Libros()
        {
        }
    }
}
