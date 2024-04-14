using Microsoft.EntityFrameworkCore;

namespace Desafios.Nubimetrics.Persistence.Context
{
    public class NubimetricsDbContext : DbContext
    {
        public NubimetricsDbContext(DbContextOptions<NubimetricsDbContext> options) : base(options)
        {
        }

       // public virtual DbSet<Pais> Pais { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
