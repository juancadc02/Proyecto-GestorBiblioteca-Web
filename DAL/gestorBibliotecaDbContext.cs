using DAL.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class gestorBibliotecaDbContext : DbContext
    {
        public gestorBibliotecaDbContext(DbContextOptions options) : base(options)
        {
        }

        public gestorBibliotecaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=gestorBibliotecaC;User Id=postgres;Password=Juanccaaa1992; SearchPath=public ");


        }
      


        public DbSet<Autores> Autores { get; set; }
        public DbSet<Rel_Autores_Libros> Rel_Autores_Libros { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Colecciones> Colecciones { get;set; }
        public DbSet<Prestamos> Prestamos { get; set;}
        public DbSet<Usuarios> Usuarios { get; set; }   
        public DbSet<Accesos> Accesos { get; set; }

    }
}
