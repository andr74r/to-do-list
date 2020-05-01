using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Web.Controllers
{
    public class ContentController : Controller
    {
        [Authorize]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/login")]
        [Route("/register")]
        public IActionResult Login()
        {
            return View("Index");
        }
    }
}