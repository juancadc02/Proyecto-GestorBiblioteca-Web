using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Prestamos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_prestamos {  get; set; }
        [ForeignKey("libro")]
        public int id_libro { get; set; }
        [ForeignKey("usuario")]
        public int id_usuario { get; set; }

        public DateTime fch_inicio_prestamo { get; set; }
        public DateTime fch_fin_prestamo { get; set; }
        public DateTime fch_entrega_prestamo { get; set; }
        public int id_estado_prestamo { get; set; }

        //Propiedades tablas 

        public ICollection<Libros> collectionLibro { get; set; } 
       
        public Usuarios usuario {  get; set; }

    }
}
