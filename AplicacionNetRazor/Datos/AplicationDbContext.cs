using AplicacionNetRazor.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {            
        }

        //Poner aqui los modelos 
        public DbSet<Curso> Curso { get; set; }

        
         
    }
}
