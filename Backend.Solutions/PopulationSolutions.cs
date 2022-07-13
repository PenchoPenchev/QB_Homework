using Backend.Data;
using Backend.Data.Models;
using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Solutions
{
    public class PopulationSolutions : ICalculatePopulation
    {
        /// <summary>
        /// Calculates countries population.
        /// </summary>
        /// <param name="context">The application db context.</param>
        /// <returns>Ilist of CountryPopulation. Returns NULL if the input context is NULL.</returns>
        public IList<CountryPopulation> GetCountriesPopulation(IAppContext context)
        {
            try
            {
                // Set LINQ to SQL Output
                // context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                if (context == null)
                {
                    return null;
                }

                var populationByCountry = context.City
                    .Where(x => x.Population.HasValue && !string.IsNullOrEmpty(x.Population.ToString()) && x.Population.Value > 0)
                    .GroupBy(x => x.State.CountryId)
                    .Select(x => new CountryPopulation()
                    {
                        CountryName = x.FirstOrDefault().State.Country.CountryName,
                        Population = x.Sum(p => p.Population)
                    })
                    .OrderBy(x => x.CountryName)
                    .ToList();

                return populationByCountry;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
