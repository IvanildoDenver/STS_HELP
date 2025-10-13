using Microsoft.AspNetCore.Mvc;
using STS_HELP.Models; 
using System.Text.Json;

namespace STS_HELP.ViewComponents
{
    public class Menu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return Content(string.Empty);
            }

            UsuariosModel usuario = JsonSerializer.Deserialize<UsuariosModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
