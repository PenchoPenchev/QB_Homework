using Backend.Data.Entities;
using System.Collections.Generic;

namespace Backend.Tests.DummyData
{
    public static class Countries
    {
        public static List<Country> Data()
        {
            var countries = new List<Country>
            {
                Canada2(),
                UK3(),
            };

            return countries;
        }

        public static Country Canada2()
        {
            return new Country() { CountryId = 2, CountryName = "Canada" };
        }

        public static Country UK3()
        {
            return new Country() { CountryId = 3, CountryName = "United Kingdom" };
        }
    }
}
