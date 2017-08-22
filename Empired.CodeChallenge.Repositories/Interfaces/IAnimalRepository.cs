using System.Collections.Generic;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Animal GetByAttributes(string uniqueness, string behaviour, string colour);
        ICollection<Animal> GetAll();
        void Save(Animal animal);
      
    }
}