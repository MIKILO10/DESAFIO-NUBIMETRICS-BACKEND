using Desafios.Nubimetrics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafios.Nubimetrics.Persistence.Context
{
    public class NubimetricsDbContext : DbContext
    {
        public NubimetricsDbContext(DbContextOptions<NubimetricsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NubimetricsDbContext).Assembly);
           
        }
    }
}
