using Microsoft.EntityFrameworkCore;
namespace Entities.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Topico> Topicos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }        
    }

}