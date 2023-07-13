using SpeedEat.Dominio.Compras.Entidades;

namespace SpeedEat.Dominio.Compras.Repositorios
{
    public interface IComprasRepositorio
    {
        void Inserir(Compra cliente);
        void Editar(Compra cliente);
        Compra Recuperar(int idCompra);
        IEnumerable<Compra> Listar(IQueryable<Compra> query);
    }
}