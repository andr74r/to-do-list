using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Web.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}