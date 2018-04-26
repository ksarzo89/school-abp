using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace Test
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TestApplicationModule))]
    public class TestWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(TestApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
