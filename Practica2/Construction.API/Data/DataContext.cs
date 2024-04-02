using Microsoft.EntityFrameworkCore;

namespace Construction.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Owner>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
