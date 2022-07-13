using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Extensions
{
    /// <summary>
    /// Contains convert extension methods from one collection to another.
    /// </summary>
    public static class CollectionsConvertersExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>IList<CountryPopulation>. In case the input is empty retun NULL.</returns>
        public static IList<CountryPopulation> ToList(this IList<Tuple<string, int>> collection)
        {
            if (collection == null)
            {
                return null;
            }

            var result = collection.Select(x => new CountryPopulation() 
            { 
                CountryName = x.Item1,
                Population = x.Item2 
            })
            .ToList();

            return result;
        }
    }
}
