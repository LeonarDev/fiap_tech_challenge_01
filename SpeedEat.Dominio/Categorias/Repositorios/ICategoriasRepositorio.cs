using SpeedEat.Dominio.Categorias.Entidades;

namespace SpeedEat.Dominio.Categorias.Repositorios
{
    public interface ICategoriasRepositorio
    {
        void Inserir(Categoria cliente);
        void Editar(Categoria cliente);
        Categoria? Recuperar(int idCategoria);
        IEnumerable<Categoria> Listar(IQueryable<Categoria> query);
    }
}