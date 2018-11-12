using System;
using System.Linq;
using System.Threading.Tasks;
using GraduateUppgift.Core.Persistence;
using GraduateUppgift.Core.Services;
using GraduateUppgift.Models;
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
             return null;
        }
    
    }
}
