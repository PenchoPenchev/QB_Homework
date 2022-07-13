using Backend.Data;
using Backend.Data.Entities;
using Backend.Tests.DummyData;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Backend.Tests.Mocks
{
    public class AppContextMock
    {
        public Mock<IAppContext> Create()
        {
            var countries = Countries.Data().AsQueryable();
            var countriesMockDbSet = new Mock<DbSet<Country>>();
            countriesMockDbSet.As<IQueryable>().Setup(x => x.Provider).Returns(countries.Provider);
            countriesMockDbSet.As<IQueryable>().Setup(x => x.Expression).Returns(countries.Expression);
            countriesMockDbSet.As<IQueryable>().Setup(x => x.ElementType).Returns(countries.ElementType);
            countriesMockDbSet.As<IQueryable>().Setup(x => x.GetEnumerator()).Returns(countries.GetEnumerator());

            var states = States.Data().AsQueryable();
            var statesMockDbSet = new Mock<DbSet<State>>();
            statesMockDbSet.As<IQueryable>().Setup(x => x.Provider).Returns(states.Provider);
            statesMockDbSet.As<IQueryable>().Setup(x => x.Expression).Returns(states.Expression);
            statesMockDbSet.As<IQueryable>().Setup(x => x.ElementType).Returns(states.ElementType);
            statesMockDbSet.As<IQueryable>().Setup(x => x.GetEnumerator()).Returns(states.GetEnumerator());

            var cities = Cities.Data().AsQueryable();
            var citiesMockDbSet = new Mock<DbSet<City>>();
            citiesMockDbSet.As<IQueryable>().Setup(x => x.Provider).Returns(cities.Provider);
            citiesMockDbSet.As<IQueryable>().Setup(x => x.Expression).Returns(cities.Expression);
            citiesMockDbSet.As<IQueryable>().Setup(x => x.ElementType).Returns(cities.ElementType);
            citiesMockDbSet.As<IQueryable>().Setup(x => x.GetEnumerator()).Returns(cities.GetEnumerator());


            var contextMock = new Mock<IAppContext>();
            contextMock.Setup(x => x.Country).Returns(countriesMockDbSet.Object);
            contextMock.Setup(x => x.State).Returns(statesMockDbSet.Object);
            contextMock.Setup(x => x.City).Returns(citiesMockDbSet.Object);

            return contextMock;
        }
    }
}
