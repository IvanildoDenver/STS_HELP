using STS_HELP.Data;
using STS_HELP.Models;

namespace STS_HELP.Repositorio
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {

        private readonly BancoContext _bancoContext;

        public UsuariosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<UsuariosModel> ListarUsuarios()
        {
            return _bancoContext.Usuarios.OrderBy(u => u.Id).ToList();
        }


        public UsuariosModel Adicionar(UsuariosModel usuarios)
        {
            //ADICIONAR NO BANCO DE DADOS
            _bancoContext.Usuarios.Add(usuarios);
            _bancoContext.SaveChanges();
            return usuarios;

        }

        public UsuariosModel ExibeInfoUsuario(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuariosModel EditaUsuario(UsuariosModel usuarios)
        {
            UsuariosModel usuarioDB = ExibeInfoUsuario(usuarios.Id);

            if (usuarioDB == null) throw new Exception("Houve um Erro na Edição do Cadastro do Usuário");
 
            usuarioDB.Nome = usuarios.Nome;
            usuarioDB.Email = usuarios.Email;
            usuarioDB.Senha = usuarios.Senha;
            usuarioDB.TipoUsuario = usuarios.TipoUsuario;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;
        }


        public UsuariosModel Inativar(int id)
        {
            
            UsuariosModel usuarioDB = ExibeInfoUsuario(id);

            if (usuarioDB == null)
            {
                throw new Exception("Erro ao Inativar Usuário: ID não encontrado.");
            }

            // Altere o status do usuário encontrado

            if(usuarioDB.SituacaoUsuario == false)
            {
                usuarioDB.SituacaoUsuario = true;
            }
            else
            {
                usuarioDB.SituacaoUsuario = false;
            }

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }


    }
}

