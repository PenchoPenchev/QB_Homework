using Autofac;
using Backend.Config;
using Backend.Data;
using Backend.Extensions;
using Backend.Interfaces;
using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application starting...");

            Console.WriteLine("Depency injection configuration...");

            var scope = DiConfiguratator.GetLifetimeScope();
            var context = scope.Resolve<IAppContext>();
            var calculatePopulation = scope.Resolve<ICalculatePopulation>();
            var collectionsMerger = scope.Resolve<ICollectionsMerger>();

            Console.WriteLine("Getting DB Connection...");

            try
            {
                var countriesPopulation = calculatePopulation.GetCountriesPopulation(context);
                var statsCountryPopulations = new ConcreteStatService().GetCountryPopulations().ToList();
                var mergedCountryPopulations = collectionsMerger.MergeWithPriority(countriesPopulation, statsCountryPopulations);

                foreach (var item in mergedCountryPopulations)
                {
                    Console.WriteLine($"Country population {item.CountryName} - {item.Population}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Handled Exception has occured.");
                Console.WriteLine("Please contact the support team.");
                Console.ReadLine();
            }
            finally
            {
                scope.Dispose();
            }
        }
    }
}
