using Backend.Data.Entities;
using System;
using System.Data.Entity;

namespace Backend.Data
{
    public interface IAppContext : IDisposable
    {
        IDbSet<City> City { get; set; }

        IDbSet<Country> Country { get; set; }

        IDbSet<State> State { get; set; }
    }
}
