using System.Collections.Generic;
using System.Linq;
using Empired.CodeChallenge.Repositories.Contexts;
using Empired.CodeChallenge.Repositories.Interfaces;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IAnimalDbContext _context;

        public AnimalRepository(IAnimalDbContext context)
        {
            _context = context;
        }

        public Animal GetByAttributes(string uniqueness, string behaviour, string colour)
        {
            var animal = _context.Animals.SingleOrDefault(x => x.Uniqueness == uniqueness && x.Behaviour == behaviour && x.Colour == colour);
            return animal;
        }

        public ICollection<Animal> GetAll()
        {
            var animals = _context.Animals.OrderBy(x => x.Name).ToList();
            return animals;
        }

        public void Save(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

    }
}
