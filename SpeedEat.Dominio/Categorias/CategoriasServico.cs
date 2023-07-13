using SpeedEat.Dominio.Categorias.Entidades;
using SpeedEat.Dominio.Categorias.Repositorios;
using SpeedEat.Dominio.Categorias.Servicos.Interfaces;

namespace SpeedEat.Dominio.Categorias.Servicos
{
    internal class CategoriasServico : ICategoriasServico
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;

        public CategoriasServico(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        public Categoria Instanciar(string nome)
        {
            Categoria categoria = new(nome);
         
            return categoria;
        }

        public Categoria Validar(int id)
        {
            Categoria? categoria = _categoriasRepositorio.Recuperar(id);

            return categoria ?? throw new Exception("Categoria não encontrada");
        }
    }
}
