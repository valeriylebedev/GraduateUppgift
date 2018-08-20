using System.Threading.Tasks;
using GraduateUppgift.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraduateUppgift.Controllers
{
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private IForecastService _forecastService;
        
        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [Route("api/forecast/{cityId}")]
        public async Task<IActionResult> Get(int cityId)
        {
            var forecast = await _forecastService.GetForecastForCity(cityId);
      
            return Ok(forecast);
        }
    }
}
