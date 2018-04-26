using System.Reflection;
using Abp.Modules;

namespace Test
{
    public class TestCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
