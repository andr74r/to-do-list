using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Web.Controllers
{
    public class ContentController : Controller
    {
        [Route("")]
        [Route("/login")]
        [Route("/register")]
        public IActionResult Index()
        {
            return View();
        }
    }
}