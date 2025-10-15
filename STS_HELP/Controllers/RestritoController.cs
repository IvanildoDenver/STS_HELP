using Microsoft.AspNetCore.Mvc;
using STS_HELP.Filters;

namespace STS_HELP.Controllers
{
    [PaginaParaUsuariosLogados("Colaborador", "Tecnico", "Gestor")]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
