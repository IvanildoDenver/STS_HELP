using Microsoft.AspNetCore.Mvc;
using STS_HELP.Filters;
using STS_HELP.Models;

namespace STS_HELP.Controllers
{

    [PaginaUsuarioGestor]
    public class UsuariosController : Controller
    {

        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }




        //METODOS GET
        public IActionResult Index()
        {
            List<UsuariosModel> listaUsuarios = _usuariosRepositorio.ListarUsuarios();

            return View(listaUsuarios);
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuariosModel exibeInfosUsuario =  _usuariosRepositorio.ExibeInfoUsuario(id);

            return View(exibeInfosUsuario);
        }

        public IActionResult InativarUsuario(int id)
        {
            UsuariosModel exibeInfosUsuario = _usuariosRepositorio.ExibeInfoUsuario(id);
            return View(exibeInfosUsuario);
        }


        public IActionResult CriarUsuario()
        {
            return View();
        }



        //METODOS POST
        [HttpPost]
        public IActionResult CriarUsuario(UsuariosModel usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.SituacaoUsuario = true;

                _usuariosRepositorio.Adicionar(usuarios);

                return RedirectToAction("Index");
            }
            return View(usuarios);
        }


        [HttpPost]
        public IActionResult EditarUsuario(UsuariosModel usuarios)
        {
            if (ModelState.IsValid)
            {

                _usuariosRepositorio.EditaUsuario(usuarios);

                return RedirectToAction("Index");
            }
            return View(usuarios);
        }


        [HttpPost]
        public IActionResult Inativar(int id)
        {
            // Chamo repositório passando o ID
            _usuariosRepositorio.Inativar(id);

            return RedirectToAction("Index");
        }

    }
}
