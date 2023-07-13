using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Compras.Entidades;
using SpeedEat.Dominio.Pedidos.Entidades.Enumeradores;

namespace SpeedEat.Dominio.Pedidos.Entidades
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime? DataFim { get; set; }
        public virtual StatusEnum Status { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Compra Compra { get; set; }

        protected Pedido() { }

        public Pedido(
            DateTime dataCriacao,
            StatusEnum status,
            Cliente cliente,
            Compra compra)
        {
            SetDataCriacao(dataCriacao);
            SetStatus(status);
            SetCliente(cliente);
            SetCompra(compra);
        }

        public virtual void SetDataCriacao(DateTime dataCriacao) => DataCriacao = dataCriacao;

        public virtual void SetDataFim(DateTime dataFim) => DataFim = dataFim;

        public virtual void SetStatus(StatusEnum status) => Status = status;

        public virtual void SetCliente(Cliente cliente) => Cliente = cliente;

        public virtual void SetCompra(Compra compra) => Compra = compra;
    }
}