using Microsoft.AspNetCore.Mvc;
using STS_HELP.Models;
using STS_HELP.Views;

namespace STS_HELP.Controllers
{
    public class Chamados : Controller
    {
        private readonly IChamadoRepositorio _chamadoRepositorio;


        public Chamados(IChamadoRepositorio chamadoRepositorio)
        {
            _chamadoRepositorio = chamadoRepositorio;
        }


        //METODOS GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditarChamado()
        {
            return View();
        }

        public IActionResult FinalizarChamado()
        {
            return View();
        }

        public IActionResult CriarChamado()
        {
            return View();
        }



        //METODOS POST
        [HttpPost]
        public IActionResult CriarChamado(ChamadosModel chamados)
        {
            if (ModelState.IsValid)
            {
                chamados.status = 1;

                // Define a data de abertura como o momento exato da criação do chamado.
                chamados.dt_Abertura = DateTime.UtcNow;

                chamados.Usuario = 1;

                _chamadoRepositorio.Adicionar(chamados);

                return RedirectToAction("Index");
            }
            return View(chamados);
        }

    }
}
