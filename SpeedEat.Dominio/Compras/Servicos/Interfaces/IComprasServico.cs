using SpeedEat.Dominio.Compras.Entidades;
using SpeedEat.Dominio.Produtos.Entidades;

namespace SpeedEat.Dominio.Compras.Servicos.Interfaces
{
    public interface IComprasServico
    {
        Compra Instanciar(Produto produto);
        Compra Validar(int id);
    }
}