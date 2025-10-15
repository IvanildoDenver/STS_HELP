using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using STS_HELP.Models;
using System.Text.Json;

namespace STS_HELP.Filters
{
    public class PaginaParaUsuariosLogados : ActionFilterAttribute
    {
        private readonly string[] _perfisPermitidos;

        //Construtor aceita um array de perfis permitidos
        public PaginaParaUsuariosLogados(params string[] perfis)
        {
            _perfisPermitidos = perfis;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            // 1. Se não há ninguém logado, manda para a tela de Login
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                return; // Encerra a execução
            }

            UsuariosModel usuario = JsonSerializer.Deserialize<UsuariosModel>(sessaoUsuario);

            // 2. Se a sessão é inválida (raro, mas seguro verificar)
            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                return;
            }

            // 3. VERIFICAÇÃO PRINCIPAL: Checa se o perfil do usuário está na lista de perfis permitidos
            if (!_perfisPermitidos.Contains(usuario.TipoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}