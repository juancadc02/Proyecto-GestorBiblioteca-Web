using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Autores
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_autor { get; set; }
        public string nombre_autor { get; set; }
        public string apellidos_autor { get; set; }


        // Propiedad de navegación para la relación
        public ICollection<Rel_Autores_Libros> Rel_Autores_Libros { get; set; }



    }
}
