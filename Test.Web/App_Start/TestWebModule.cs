﻿using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;

namespace Test.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(TestDataModule), 
        typeof(TestApplicationModule), 
        typeof(TestWebApiModule))]
    public class TestWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
        
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("sp", "Spanish", "famfamfam-flag-spain"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    TestConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/Test")
                        )
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<TestNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
