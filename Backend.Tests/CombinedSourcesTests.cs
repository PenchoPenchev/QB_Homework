using Backend.Interfaces;
using Backend.Solutions;
using Backend.Tests.DummyData;
using Backend.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System.Linq;
using Backend.Extensions;

namespace Backend.Tests
{
    [TestFixture]
    public class CombinedSourcesTests
    {
        private ICalculatePopulation calculatePopulation;
        private ICollectionsMerger colletionMerger;

        [SetUp]
        public void Setup()
        {
            this.calculatePopulation = new PopulationSolutions();
            this.colletionMerger = new MergeSolutions();
        }

        [Test]
        public void Merge_DbServiceCountriesAndPopulation_Expected4Records()
        {
            // Arrange
            byte expectedRecords = 4;
            var mockContext = new AppContextMock().Create();
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
                .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var dbCountriesPopulation = this.calculatePopulation.GetCountriesPopulation(mockContext.Object);
            var serviceCountriesPopulation = mockService.Object.GetCountryPopulations().ToList();
            var mergedCountriesPopulation = this.colletionMerger.MergeWithPriority(dbCountriesPopulation, serviceCountriesPopulation);

            // Assert
            if (mergedCountriesPopulation == null)
            {
                Assert.Fail("Expected merged countries population is NULL, but should have value.");
            }

            Assert.AreEqual(expectedRecords, mergedCountriesPopulation.ToList().Count);
        }

        [Test]
        public void Merge_DbNullServiceCountriesAndPopulation_Expected3Records()
        {
            // Arrange
            byte expectedRecords = 3;
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
                .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var serviceCountriesPopulation = mockService.Object.GetCountryPopulations().ToList();
            var mergedCountriesPopulation = this.colletionMerger.MergeWithPriority(null, serviceCountriesPopulation);

            // Assert
            if (mergedCountriesPopulation == null)
            {
                Assert.Fail("Expected merged countries population is NULL, but should have value.");
            }

            Assert.AreEqual(expectedRecords, mergedCountriesPopulation.ToList().Count);
        }

        [Test]
        public void Merge_DbServiceCountriesAndPopulation_ExpectedUKPopulation20890()
        {
            // Arrange
            short expectedUKPopulation = 20890;
            var mockContext = new AppContextMock().Create();
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
                .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var dbCountriesPopulation = this.calculatePopulation.GetCountriesPopulation(mockContext.Object);
            var serviceCountriesPopulation = mockService.Object.GetCountryPopulations().ToList();
            var mergedCountriesPopulation = this.colletionMerger.MergeWithPriority(dbCountriesPopulation, serviceCountriesPopulation);

            // Assert
            if (mergedCountriesPopulation == null)
            {
                Assert.Fail("Expected merged countries population is NULL, but should have value.");
            }

            var country = mergedCountriesPopulation.Where(x => x.CountryName == "United Kingdom").FirstOrDefault();
            if (country == null)
            {
                Assert.Fail($"Test fail because the result was NULL while expected value.");
            }

            Assert.AreEqual(expectedUKPopulation, country.Population);
        }
    }
}
