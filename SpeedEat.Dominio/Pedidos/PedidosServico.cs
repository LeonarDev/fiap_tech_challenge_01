using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Compras.Entidades;
using SpeedEat.Dominio.Pedidos.Entidades;
using SpeedEat.Dominio.Pedidos.Entidades.Enumeradores;
using SpeedEat.Dominio.Pedidos.Repositorios;
using SpeedEat.Dominio.Pedidos.Servicos.Interfaces;

namespace SpeedEat.Dominio.Pedidos.Servicos
{
    internal class PedidosServico : IPedidosServico
    {
        private readonly IPedidosRepositorio _pedidosRepositorio;

        public PedidosServico(IPedidosRepositorio pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }

        public Pedido Instanciar(DateTime dataCriacao, StatusEnum status, Cliente cliente, Compra compra)
        {
            Pedido pedido = new(dataCriacao, status, cliente, compra);
         
            return pedido;
        }

        public Pedido Validar(int id)
        {
            Pedido pedido = _pedidosRepositorio.Recuperar(id);

            return pedido ?? throw new Exception("Pedido não encontrado");
        }
    }
}
