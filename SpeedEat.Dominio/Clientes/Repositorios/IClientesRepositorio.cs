using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Clientes.Repositorios.Filtros;

namespace SpeedEat.Dominio.Clientes.Repositorios
{
    public interface IClientesRepositorio
    {
        void Inserir(Cliente cliente);
        void Editar(Cliente cliente);
        Cliente Recuperar(int idCliente);
        IEnumerable<Cliente> Listar(ClienteListarFiltro filtro);
    }
}