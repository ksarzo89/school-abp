using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;

namespace Test.EntityFramework
{
    public class TestDbContext : AbpDbContext
    {
        public virtual IDbSet<Test.Group.Group> Groups { get; set; }

        public virtual IDbSet<Test.Student.Student> Students { get; set; }

        public TestDbContext()
            : base("Default")
        {

        }

        public TestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public TestDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TestDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
