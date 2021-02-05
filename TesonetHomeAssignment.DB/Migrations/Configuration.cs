using TesonetHomeAssignment.DB.Models;
using System.Data.Entity.Migrations;

namespace TesonetHomeAssignment.DB.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PlaygroundDatabaseEntities>
    {
        public Configuration()
        {
            //Automatic migration when new tables are added
            AutomaticMigrationsEnabled = true;
            //We can prevent dataloss after creating migrations by setting this to false
            AutomaticMigrationDataLossAllowed = true;
            
        }

        public void Update(PlaygroundDatabaseEntities context)
        {
            context.SaveChanges();
        }
    }
}
