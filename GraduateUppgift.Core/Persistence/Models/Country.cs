using System.Collections.Generic;

namespace GraduateUppgift.Core.Persistence.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
