using System.Data.Entity.Migrations;

namespace Test.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Test.EntityFramework.TestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Test.EntityFramework.TestDbContext context)
        {
        }
    }
}
