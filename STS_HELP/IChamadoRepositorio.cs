using STS_HELP.Models;

namespace STS_HELP
{
    public interface IChamadoRepositorio
    {

        List<ChamadosModel> ListarChamados();

        ChamadosModel Adicionar(ChamadosModel chamados);
       
    }
}
