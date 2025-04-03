using API_LLM.Entities.Car;
using Microsoft.EntityFrameworkCore;

namespace API_LLM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carro>().ToTable("carros");
            // Caso queira forçar os nomes das colunas (mesmo que o EF já faça isso automaticamente)
            modelBuilder.Entity<Carro>()
                .Property(c => c.Marca).HasColumnName("marca");
            modelBuilder.Entity<Carro>()
                .Property(c => c.Modelo).HasColumnName("modelo");
            modelBuilder.Entity<Carro>()
                .Property(c => c.Valor).HasColumnName("valor");
            // Garantir que 'id' seja a chave primária
            modelBuilder.Entity<Carro>().HasKey(c => c.Id);
        }
    }
}
