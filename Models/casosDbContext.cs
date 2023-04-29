using Microsoft.EntityFrameworkCore;

namespace P2_2020ZR601_2020MG601.Models
{
    public class casosDbContext : DbContext
    {
        public casosDbContext(DbContextOptions  options): base(options) 
        {

        }

        public DbSet<casos> Casos { get; set; }
        public DbSet<genero> Generos { get; set; }
        public DbSet<departamento> Departamento { get; set;}


    }
}
