using STS_HELP.Data;
using STS_HELP.Models;
using STS_HELP.Views;

namespace STS_HELP.Repositorio
{
    public class ChamadoRepositorio : IChamadoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ChamadoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
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
