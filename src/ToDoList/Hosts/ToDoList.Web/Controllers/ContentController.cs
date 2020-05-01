using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Web.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}