using STS_HELP.Models;

namespace STS_HELP.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuariosModel usuario);

        void RemoverSessaoUsuario();

        UsuariosModel BuscarSessaoUsuario();
    }
}
