using STS_HELP.Models;

namespace STS_HELP
{
    public interface IUsuariosRepositorio
    {

        UsuariosModel BuscarLogin(string eamil);

        List<UsuariosModel> ListarUsuarios();

        UsuariosModel Adicionar(UsuariosModel usuarios);

        UsuariosModel ExibeInfoUsuario(int id);

        UsuariosModel EditaUsuario(UsuariosModel usuarios);

        UsuariosModel Inativar(int id);

    }
}