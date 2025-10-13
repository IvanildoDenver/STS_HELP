using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using STS_HELP.Models;
using System.Text.Json;

namespace STS_HELP.Filters
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            { 
                context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                {
                    {"controller", "Login"}, {"action", "Index"}
                });
            }
            else
            {
                UsuariosModel usuario = JsonSerializer.Deserialize<UsuariosModel>(sessaoUsuario);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"controller", "Login"}, {"action", "Index"}
                    });
                }
            }

                base.OnActionExecuting(context);
        }

    }


}
