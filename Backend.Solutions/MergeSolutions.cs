using Backend.Data.Models;
using Backend.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Solutions
{
    public class MergeSolutions : ICollectionsMerger
    {
        /// <summary>
        /// Merge IEnumerable collection of type CountryPopulation with priority in the first collection.
        /// </summary>
        /// <param name="countryPopulations1">IEnumerable collection of type CountryPopulation.</param>
        /// <param name="countryPopulations2">IEnumerable collection of type CountryPopulation.</param>
        /// <returns>IEnumerable collection of type CountryPopulation. In case of NULL input params returns NULL.</returns>
        public IEnumerable<CountryPopulation> MergeWithPriority(
            IEnumerable<CountryPopulation> countryPopulations1,
            IEnumerable<CountryPopulation> countryPopulations2)
        {
            if (countryPopulations1 == null && countryPopulations2 == null)
            {
                return null;
            }

            if (countryPopulations1 == null && countryPopulations2 != null)
            {
                return countryPopulations2;
            }
            else if (countryPopulations1 != null && countryPopulations2 == null)
            {
                return countryPopulations1;
            }

            var mergedCountryPopulations = countryPopulations1.Concat(countryPopulations2)
                    .GroupBy(x => x.CountryName)
                    .Select(g => g.OrderBy(x => x.CountryName).First())
                    .OrderBy(x => x.CountryName)
                    .ToList();

            return mergedCountryPopulations;
        }
    }
}
