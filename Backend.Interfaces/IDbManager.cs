using Backend.Data;
using System.Data.Common;

namespace Backend.Interfaces
{
    public interface IDbManager
    {
        DbConnection getConnection();
    }
}
