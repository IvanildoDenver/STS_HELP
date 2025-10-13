using Microsoft.AspNetCore.Mvc;
using STS_HELP.Filters;

namespace STS_HELP.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
