using STS_HELP.Data;
using STS_HELP.Models;

namespace STS_HELP.Repositorio
{
    public class ChamadoRepositorio : IChamadoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ChamadoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public List<ChamadosModel> ListarChamados()
        {
            return _bancoContext.Chamados.ToList();
        }


        public ChamadosModel Adicionar(ChamadosModel chamados)
        {
            //throw new NotImplementedException();
            //ADICIONAR NO BANCO DE DADOS
            _bancoContext.Chamados.Add(chamados);
            _bancoContext.SaveChanges();
            return chamados;

        }

        
    }
}
