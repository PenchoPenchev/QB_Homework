using Backend.Data;
using Backend.Data.Models;
using System.Collections.Generic;

namespace Backend.Interfaces
{
    public interface ICalculatePopulation
    {
        /// <summary>
        /// Calculates countries population.
        /// </summary>
        /// <param name="context">The application db context.</param>
        /// <returns>Ilist of CountryPopulation. Returns NULL if the input context is NULL.</returns>
        IList<CountryPopulation> GetCountriesPopulation(IAppContext context);
    }
}
