using AtividadePizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadePizzaria.Data
{
    public class PizzariaDbContext : DbContext
    {

        public PizzariaDbContext(DbContextOptions<PizzariaDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PizzaSabor>()
                .HasKey(af => new
            {
                af.PizzaId,
                af.SaborId
            });

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSabor> PizzasSabores { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        
    }
}
