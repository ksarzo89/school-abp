using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Test.EntityFramework;

namespace Test
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(TestCoreModule))]
    public class TestDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<TestDbContext>(null);
        }
    }
}
