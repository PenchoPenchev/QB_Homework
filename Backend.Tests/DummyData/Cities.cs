using Backend.Data.Entities;
using System.Collections.Generic;

namespace Backend.Tests.DummyData
{
    public static class Cities
    {
        public static List<City> Data()
        {
            var cities = new List<City>
            {
                Toronto163119(),
                Milltimber5(),
                PeterculterUpperAnguston6(),
                Alford17(),
                Aboyne18(),
                Ballater19(),
            };

            return cities;
        }

        // Cities in Canada
        public static City Toronto163119()
        {
            return new City()
            {
                CityId = 163119,
                CityName = "Toronto",
                StateId = 58,
                Population = 5132794,
                State = States.Ontario58()
            };
        }


        // Cities in UK
        public static City Milltimber5()
        {
            return new City()
            {
                CityId = 5,
                CityName = "Milltimber",
                StateId = 66,
                Population = 2725,
                State = States.Aberdeen66()
            };
        }

        public static City PeterculterUpperAnguston6()
        {
            return new City()
            {
                CityId = 6,
                CityName = "Peterculter, Upper Anguston",
                StateId = 66,
                Population = 4881,
                State = States.Aberdeen66()
            };
        }

        public static City Alford17()
        {
            return new City()
            {
                CityId = 17,
                CityName = "Alford",
                StateId = 67,
                Population = 5273,
                State = States.Aberdeenshire67()
            };
        }

        public static City Aboyne18()
        {
            return new City()
            {
                CityId = 18,
                CityName = "Aboyne",
                StateId = 67,
                Population = 5387,
                State = States.Aberdeenshire67()
            };
        }

        public static City Ballater19()
        {
            return new City()
            {
                CityId = 19,
                CityName = "Ballater",
                StateId = 67,
                Population = 2624,
                State = States.Aberdeenshire67()
            };
        }
    }
}
