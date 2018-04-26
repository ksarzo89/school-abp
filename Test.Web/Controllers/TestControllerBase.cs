using Abp.Web.Mvc.Controllers;

namespace Test.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class TestControllerBase : AbpController
    {
        protected TestControllerBase()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}