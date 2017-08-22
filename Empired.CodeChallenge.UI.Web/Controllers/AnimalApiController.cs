using System.Net;
using System.Net.Http;
using System.Web.Http;
using Empired.CodeChallenge.UI.Interfaces;
using Empired.CodeChallenge.UI.Models;

namespace Empired.CodeChallenge.UI.Web.Controllers
{
    [RoutePrefix("api")]
    public class AnimalApiController : ApiController
    {
        private readonly IAnimalService _animalService;

        public AnimalApiController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [Route("get-name", Name = "GetName")]
        [HttpPost]
        public HttpResponseMessage GetName(AnimalEnquiryModel model)
        {
            var name = _animalService.GetName(model);
            if (string.IsNullOrWhiteSpace(name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }

        [Route("save", Name = "Save")]
        [HttpPost]
        public HttpResponseMessage Save(AnimalModel model)
        {
            try
            {
                _animalService.Save(model);
                var viewModel = _animalService.GetViewModel();
                return Request.CreateResponse(HttpStatusCode.OK, viewModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to save record");
            }
        }

      
    }
}
