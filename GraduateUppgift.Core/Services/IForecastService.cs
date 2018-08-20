using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static GraduateUppgift.Core.Services.ForecastService;

namespace GraduateUppgift.Core.Services
{
    public interface IForecastService
    {
        Task<IEnumerable<Forecast>> GetForecastForCity(int cityId);
    }
}
