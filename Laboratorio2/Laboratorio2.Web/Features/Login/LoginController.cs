using Microsoft.AspNetCore.Mvc;

namespace Laboratorio2.Web.Features.Login
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
