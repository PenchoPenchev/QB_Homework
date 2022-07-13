using Backend.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace Backend.Data
{
    public class AppDbContext : DbContext, IAppContext
    {
        public AppDbContext()
            : base(new SQLiteConnection(@"Data Source=citystatecountry.db;Version=3;FailIfMissing=True"), true)
        {

        }

        public virtual IDbSet<City> City { get; set; }

        public virtual IDbSet<Country> Country { get; set; }

        public virtual IDbSet<State> State { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
