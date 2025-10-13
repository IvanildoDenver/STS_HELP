using Microsoft.AspNetCore.Http;
using STS_HELP.Models;
using System.Text.Json;

namespace STS_HELP.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuariosModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonSerializer.Deserialize<UsuariosModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuariosModel usuario)
        {
            string valor = JsonSerializer.Serialize(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}