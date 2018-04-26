using System.Web.Mvc;

namespace Test.Web.Controllers
{
    public class HomeController : TestControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}