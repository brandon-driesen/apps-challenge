using System.Collections.Generic;
using System.Data.Entity;
using Empired.CodeChallenge.Repositories.Contexts;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories
{
    public class AnimalDbInitialiser : DropCreateDatabaseAlways<AnimalDbContext>
    {
        protected override void Seed(AnimalDbContext context)
        {
            context.Animals.AddRange(GetDefaultAnimals());
            base.Seed(context);
        }

        private static IEnumerable<Animal> GetDefaultAnimals()
        {
            yield return new Animal
            {
                Name = "Elephant",
                Uniqueness = "Trunk",
                Colour = "Grey",
                Behaviour = "Trumpets"
            };

            yield return new Animal
            {
                Name = "Lion",
                Uniqueness = "Mane",
                Colour = "Yellow",
                Behaviour = "Roars"
            };


        }
    }
}
