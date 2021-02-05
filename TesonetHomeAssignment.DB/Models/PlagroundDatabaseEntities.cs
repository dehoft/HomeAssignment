using System.Data.Entity;
using System.Data.Common;

namespace TesonetHomeAssignment.DB.Models
{
    public class PlaygroundDatabaseEntities : DbContext
    {

        public PlaygroundDatabaseEntities()
            : base(ConnectionName.Connect().Item1)
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<PlaygroundDatabaseEntities>());
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<PlaygroundDatabaseEntities, Migrations.Configuration>());
        }

        public virtual DbSet<Servers> Servers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //All the relations between tables goes here
        }
    }
}
