using SpeedEat.DataTransfer.Clientes.Requests;
using SpeedEat.DataTransfer.Clientes.Responses;

namespace SpeedEat.Aplicacao.Clientes.Servicos.Interfaces
{
    public interface IClientesAppServico
    {
        ClienteResponse Inserir(ClienteRequest request);
        ClienteResponse Recuperar(int id);
        ClienteResponse Editar(int id, ClienteRequest request);
        IEnumerable<ClienteResponse> Listar(ClienteListarRequest request);
    }
}