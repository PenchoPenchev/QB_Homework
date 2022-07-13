using Backend.Data.Models;
using System.Collections.Generic;

namespace Backend.Interfaces
{
    public interface ICollectionsMerger
    {
        /// <summary>
        /// Merge IEnumerable collection of type CountryPopulation with priority in the first collection.
        /// </summary>
        /// <param name="countryPopulations1">IEnumerable collection of type CountryPopulation.</param>
        /// <param name="countryPopulations2">IEnumerable collection of type CountryPopulation.</param>
        /// <returns>IEnumerable collection of type CountryPopulation. In case of NULL input params returns NULL.</returns>
        IEnumerable<CountryPopulation> MergeWithPriority(
            IEnumerable<CountryPopulation> countryPopulations1, 
            IEnumerable<CountryPopulation> countryPopulations2);
    }
}
