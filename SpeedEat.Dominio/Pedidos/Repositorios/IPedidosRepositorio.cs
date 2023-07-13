using SpeedEat.Dominio.Pedidos.Entidades;

namespace SpeedEat.Dominio.Pedidos.Repositorios
{
    public interface IPedidosRepositorio
    {
        void Inserir(Pedido cliente);
        void Editar(Pedido cliente);
        Pedido Recuperar(int idPedido);
        IEnumerable<Pedido> Listar(IQueryable<Pedido> query);
    }
}