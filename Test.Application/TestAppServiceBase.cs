using Abp.Application.Services;

namespace Test
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TestAppServiceBase : ApplicationService
    {
        protected TestAppServiceBase()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}