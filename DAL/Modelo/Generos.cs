using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Generos
    {
        public Generos()
        {
        }

        public Generos(string nombre_genero, string descripcion_genero)
        {
            this.nombre_genero = nombre_genero;
            this.descripcion_genero = descripcion_genero;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_genero {  get; set; }
        public string nombre_genero { get; set; }
        public string descripcion_genero { get; set; }

        public Generos(int id_genero)
        {
            this.id_genero = id_genero;
        }
    }
}
