using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAssessment.Models
{
    public class CountryRepo
    {
        private static List<Country> _countries = new List<Country>
        {
        new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
        new Country { ID = 2, CountryName = "Germany", Capital = "Berlin" },
        new Country { ID = 3, CountryName = "France", Capital = "Paris"},
        new Country { ID = 3, CountryName = "Ukraine", Capital = "Kiev"},
        new Country { ID = 3, CountryName = "Russia", Capital = "Moscow"}
        };

        public IEnumerable<Country> GetAllCountries() => _countries;

        public Country GetCountry(int id) => _countries.FirstOrDefault(c => c.ID == id);

        public void AddCountry(Country country) => _countries.Add(country);

        public void UpdateCountry(Country country)
        {
            var existingCountry = GetCountry(country.ID);
            if (existingCountry != null)
            {
                existingCountry.CountryName = country.CountryName;
                existingCountry.Capital = country.Capital;
            }
        }

        public void DeleteCountry(int id) => _countries.Remove(GetCountry(id));
    }
}