using Backend.Data.Entities;
using System.Collections.Generic;

namespace Backend.Tests.DummyData
{
    public static class States
    {
        public static List<State> Data()
        {
            var states = new List<State>
            {
                Ontario58(),
                Aberdeen66(),
                Aberdeenshire67(),
            };

            return states;
        }

        public static State Ontario58()
        {
            return new State() { StateId = 58, StateName = "Ontario", CountryId = 2, Country = Countries.Canada2() };
        }

        public static State Aberdeen66()
        {
            return new State() { StateId = 66, StateName = "Aberdeen", CountryId = 3, Country = Countries.UK3() };
        }

        public static State Aberdeenshire67()
        {
            return new State() { StateId = 67, StateName = "Aberdeenshire", CountryId = 3, Country = Countries.UK3() };
        }
    }
}
