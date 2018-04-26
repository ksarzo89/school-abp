using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Test
{
    [DependsOn(typeof(TestCoreModule), typeof(AbpAutoMapperModule))]
    public class TestApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
