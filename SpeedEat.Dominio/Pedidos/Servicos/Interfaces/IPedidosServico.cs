using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Compras.Entidades;
using SpeedEat.Dominio.Pedidos.Entidades;
using SpeedEat.Dominio.Pedidos.Entidades.Enumeradores;

namespace SpeedEat.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosServico
    {
        Pedido Instanciar(DateTime dataCriacao, StatusEnum status, Cliente cliente, Compra compra);
        Pedido Validar(int id);
    }
}