using SpeedEat.Dominio.Categorias.Entidades;

namespace SpeedEat.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriasServico
    {
        Categoria Instanciar(string nome);
        Categoria Validar(int id);
    }
}