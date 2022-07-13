using System;
using System.Collections.Generic;

namespace Backend.Tests.DummyData
{
	public static class CountriesPopulation
	{
		public static List<Tuple<string, int>> GetCountryPopulations()
		{
			// Pretend this calls a REST API somewhere
			return new List<Tuple<string, int>>
			{
				Tuple.Create("India",1182105000),
				Tuple.Create("United Kingdom",62026962),
				Tuple.Create("Chile",17094270)
			};
		}
	}
}
