using SpeedEat.Dominio.Categorias.Entidades;
using SpeedEat.Dominio.Produtos.Entidades;
using SpeedEat.Dominio.Produtos.Repositorios;
using SpeedEat.Dominio.Produtos.Servicos.Interfaces;

namespace SpeedEat.Dominio.Produtos.Servicos
{
    internal class ProdutosServico : IProdutosServico
    {
        private readonly IProdutosRepositorio _produtosRepositorio;

        public ProdutosServico(IProdutosRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        public Produto Instanciar(string nome, string descricao, string observacao, double preco, byte[] imagem, Categoria categoria)
        {
            Produto produto = new(nome, descricao, observacao, preco, imagem, categoria);

            return produto;
        }

        public Produto Validar(int id)
        {
            Produto produto = _produtosRepositorio.Recuperar(id);

            return produto ?? throw new Exception("Produto não encontrado");
        }
    }
}
