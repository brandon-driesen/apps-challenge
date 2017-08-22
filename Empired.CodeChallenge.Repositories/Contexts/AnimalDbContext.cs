using System.Data.Entity;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories.Contexts
{
    public class AnimalDbContext : DbContext, IAnimalDbContext
    {
        public AnimalDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new AnimalDbInitialiser());
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().Create();
        }
    }
}
