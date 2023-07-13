using SpeedEat.Dominio.Produtos.Entidades;

namespace SpeedEat.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio
    {
        void Inserir(Produto cliente);
        void Editar(Produto cliente);
        Produto Recuperar(int idProduto);
        IEnumerable<Produto> Listar(IQueryable<Produto> query);
    }
}