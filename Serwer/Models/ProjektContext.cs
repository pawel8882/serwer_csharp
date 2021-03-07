using Microsoft.EntityFrameworkCore;

namespace Serwer.Models
{
    public class ProjektContext : DbContext
    {
        public ProjektContext(DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt> ProjektItems { get; set; }
        public DbSet<ProjektDetails> ProjektDetailsItems { get; set; }

        public DbSet<Person> PersonItems { get; set; }

        public DbSet<PersonProjekty> PersonProjekts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projekt>().ToTable("Projekt");
            modelBuilder.Entity<ProjektDetails>().ToTable("ProjektDetails");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PersonProjekty>().ToTable("PersonProjekty");
        }
    }
    
}
