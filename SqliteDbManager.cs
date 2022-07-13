using Backend.Interfaces;
using System;
using System.Data.Common;
using System.Data.SQLite;

namespace Backend
{
    public class SqliteDbManager : IDbManager
    {
        public DbConnection getConnection()
        {
            try
            {
                var connection = new SQLiteConnection("Data Source=citystatecountry.db;Version=3;FailIfMissing=True");
                return connection.OpenAndReturn();
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
