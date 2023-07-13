using SpeedEat.Dominio.Compras.Entidades;
using SpeedEat.Dominio.Compras.Repositorios;
using SpeedEat.Dominio.Compras.Servicos.Interfaces;
using SpeedEat.Dominio.Produtos.Entidades;

namespace SpeedEat.Dominio.Compras.Servicos
{
    internal class ComprasServico : IComprasServico
    {
        private readonly IComprasRepositorio _comprasRepositorio;

        public ComprasServico(IComprasRepositorio comprasRepositorio)
        {
            _comprasRepositorio = comprasRepositorio;
        }

        public Compra Instanciar(Produto produto)
        {
            Compra compra = new(produto);
         
            return compra;
        }

        public Compra Validar(int id)
        {
            Compra compra = _comprasRepositorio.Recuperar(id);

            return compra ?? throw new Exception("Compra não encontrado");
        }
    }
}
