using Backend.Interfaces;
using Backend.Tests.DummyData;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Backend.Tests
{
    [TestFixture]
    public class ConcreteStatServiceTests
    {
        [Test]
        public void Find_CountryUK_MustReturnTrue()
        {
            TestContext.WriteLine("Check total population of all cities in UK");

            // Arrange
            var expectedCountry = "United Kingdom";
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
            .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var uk = mockService.Object.GetCountryPopulations()
                .Where(x => x.Item1 == "United Kingdom")
                .FirstOrDefault();

            if (uk == null)
            {
                Assert.Fail($"Test fail because the result was NULL while expected {expectedCountry}");
            }

            // Assert
            TestContext.WriteLine($"Expected country {expectedCountry} / actual {uk.Item1}");
            Assert.AreEqual(expectedCountry, uk.Item1);
        }

        [Test]
        public void Find_CountryBulgaria_MustReturnFalse()
        {
            TestContext.WriteLine("Confirm that Bulgaria is not in the list.");

            // Arrange
            var expectedCountry = "Bulgaria";
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
            .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var bg = mockService.Object.GetCountryPopulations()
                .Where(x => x.Item1 == expectedCountry)
                .FirstOrDefault();

            // Assert
            Assert.IsNull(bg);
        }

        [Test]
        public void Count_AllCountries_MustReturn3()
        {
            TestContext.WriteLine("Count all existing countries.");

            // Arrange
            byte expectedNumber = 3;
            var mockService = new Mock<IStatService>();
            mockService.Setup(x => x.GetCountryPopulations())
            .Returns(CountriesPopulation.GetCountryPopulations());

            // Act
            var bg = mockService.Object.GetCountryPopulations();

            // Assert
            Assert.AreEqual(expectedNumber, bg.Count);
        }
    }
}
