using Abp.Application.Navigation;
using Abp.Localization;

namespace Test.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class TestNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Groups",
                        new LocalizableString("GroupPage", TestConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Students",
                        new LocalizableString("StudentPage", TestConsts.LocalizationSourceName),
                        url: "#/students",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}
