using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Controllers
{
    public class LivroController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
