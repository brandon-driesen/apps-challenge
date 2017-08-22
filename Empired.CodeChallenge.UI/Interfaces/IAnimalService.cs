using Empired.CodeChallenge.UI.Models;
using Empired.CodeChallenge.UI.ViewModels;

namespace Empired.CodeChallenge.UI.Interfaces
{
    public interface IAnimalService
    {
        AnimalViewModel GetViewModel();
        string GetName(AnimalEnquiryModel model);
        void Save(AnimalModel model);
    }
}