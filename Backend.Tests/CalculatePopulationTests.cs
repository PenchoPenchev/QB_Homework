using Backend.Interfaces;
using Backend.Solutions;
using Backend.Tests.Mocks;
using NUnit.Framework;
using System.Linq;

namespace Backend.Tests
{
    [TestFixture]
    public class CalculatePopulationTests
    {
        private ICalculatePopulation calculatePopulation;

        [SetUp]
        public void Setup()
        {
            this.calculatePopulation = new PopulationSolutions();
        }

        [Test]
        public void Sum_TotalPopulationCanada_PopulationMustBe5132794()
        {
            TestContext.WriteLine("Checking total population of all cities in Canada");

            // Arrange
            int expectedPopulation = 5132794;
            var mockContext = new AppContextMock().Create();

            // Act
            var countriesPopulation = this.calculatePopulation.GetCountriesPopulation(mockContext.Object);
            var country = countriesPopulation.Where(x => x.CountryName == "Canada").First();

            // Assert
            TestContext.WriteLine($"Expected population {expectedPopulation} / actual {country.Population}");
            Assert.AreEqual(expectedPopulation, country.Population);
        }

        [Test]
        public void Sum_TotalPopulationUK_PopulationMustBe20890()
        {
            TestContext.WriteLine("Checking total population of all cities in UK");

            // Arrange
            int expectedPopulation = 20890;
            var mockContext = new AppContextMock().Create();

            // Act
            var countriesPopulation = this.calculatePopulation.GetCountriesPopulation(mockContext.Object);
            var country = countriesPopulation.Where(x => x.CountryName == "United Kingdom").First();

            // Assert
            TestContext.WriteLine($"Expected population {expectedPopulation} / actual {country.Population}");
            Assert.AreEqual(expectedPopulation, country.Population);
        }
    }
}
