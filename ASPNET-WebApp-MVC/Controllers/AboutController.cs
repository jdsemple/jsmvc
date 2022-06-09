using Microsoft.AspNetCore.Mvc;

namespace ASPNET_WebApp_MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
