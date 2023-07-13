using SpeedEat.Dominio.Categorias.Entidades;
using SpeedEat.Dominio.Produtos.Entidades;

namespace SpeedEat.Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        Produto Instanciar(string nome, string descricao, string observacao, double preco, byte[] imagem, Categoria categoria);
        Produto Validar(int id);
    }
}