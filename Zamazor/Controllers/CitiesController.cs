using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Zamazor.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult GetCities(int countryId) // Cities/GetCities/1
        {
            var result = _cityService.List(countryId);
            var model = result.Data;
            return Json(model);
        }

        [HttpPost]
        public IActionResult PostCities(int countryId)
        {
            var result = _cityService.List(countryId);
            var model = result.Data;
            return Json(model);
        }
    }
}