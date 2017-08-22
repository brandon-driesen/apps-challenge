using System.Linq;
using Empired.CodeChallenge.Repositories.Interfaces;
using Empired.CodeChallenge.Repositories.Models;
using Empired.CodeChallenge.UI.Interfaces;
using Empired.CodeChallenge.UI.Models;
using Empired.CodeChallenge.UI.ViewModels;

namespace Empired.CodeChallenge.UI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public AnimalViewModel GetViewModel()
        {
            var animals = _repository.GetAll();
            var model = new AnimalViewModel
            {
                Names = animals.Select(x => x.Name).OrderBy(x => x).ToList(),
                Behaviours = animals.GroupBy(x => x.Behaviour).Select(x => x.Key).OrderBy(x => x).ToList(),
                Colours = animals.GroupBy(x => x.Colour).Select(x => x.Key).OrderBy(x => x).ToList(),
                Uniqueness = animals.GroupBy(x => x.Uniqueness).Select(x => x.Key).OrderBy(x => x).ToList()
            };
            return model;
        }

        public string GetName(AnimalEnquiryModel model)
        {
            var animal = _repository.GetByAttributes(model.Uniqueness, model.Behaviour, model.Colour);
            if (animal == null)
            {
                return null;
            }
            return animal.Name;
        }

        public void Save(AnimalModel model)
        {
            //TODO: Time permitting, automapper would be used
            var animal = new Animal
            {
                Uniqueness = model.Uniqueness,
                Behaviour = model.Behaviour,
                Name = model.Name,
                Colour = model.Colour
            };
            _repository.Save(animal);
        }


    }
}
