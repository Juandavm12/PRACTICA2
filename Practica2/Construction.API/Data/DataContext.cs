using Construction.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProjectConstruction> ProjectConstructions { get; set; }
        public DbSet<ConstructionTeam> ConstructionTeams { get; set; }
        public DbSet<Dutie> Duties { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
