using System.Web.Mvc;
using Empired.CodeChallenge.UI.Interfaces;

namespace Empired.CodeChallenge.UI.Web.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly IAnimalService _animalService;

        public HomeController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [Route("")]
        public ActionResult Index()
        {
            var model = _animalService.GetViewModel();
            return View(model);
        }

    }
}