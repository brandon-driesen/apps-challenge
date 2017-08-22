using System.Data.Entity;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories.Contexts
{
    public interface IAnimalDbContext
    {
        DbSet<Animal> Animals { get; }

        int SaveChanges();

    }
}