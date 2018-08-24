using System;
using System.Linq;
using System.Threading.Tasks;
using GraduateUppgift.Core.Persistence;
using GraduateUppgift.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraduateUppgift.Controllers
{
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private IForecastService _forecastService;
        private ForecastContext _context;
        
        public ForecastController(IForecastService forecastService, ForecastContext context)
        {
            _forecastService = forecastService;
            _context = context;
        }

        [Route("api/forecast/{cityName}")]
        public async Task<IActionResult> Get(string cityName)
        {
            var cityId = (from c in _context.Countries
                    where c.namecity == cityName
                    select c.id).FirstOrDefault();
            var forecast = await _forecastService.GetForecastForCity(cityId);
            var mappedForecasts =  forecast.Select(f => new ForecastModel
                {
                  Date = f.dt_txt.ToString("dd/MM/yyyy"),
                  Time = f.dt_txt.ToString("HH:mm"),
                  Temperature = (int)Math.Round(f.main.temp)
                });
      
            return Ok(mappedForecasts);
        }

        private class ForecastModel
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public int Temperature { get; set; }
        }
    }
}
