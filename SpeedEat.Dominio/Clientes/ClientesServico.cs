using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Clientes.Repositorios;
using SpeedEat.Dominio.Clientes.Servicos.Interfaces;

namespace SpeedEat.Dominio.Clientes.Servicos
{
    public class ClientesServico : IClientesServico
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public ClientesServico(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }

        public Cliente Instanciar(string nome)
        {
            Cliente cliente = new(nome);
         
            return cliente;
        }

        public Cliente Validar(int id)
        {
            Cliente cliente = _clientesRepositorio.Recuperar(id);

            return cliente ?? throw new Exception("Cliente não encontrado");
        }
    }
}
