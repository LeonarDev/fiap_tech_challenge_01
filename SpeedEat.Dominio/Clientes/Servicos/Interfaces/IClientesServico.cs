using SpeedEat.Dominio.Clientes.Entidades;

namespace SpeedEat.Dominio.Clientes.Servicos.Interfaces
{
    public interface IClientesServico
    {
        Cliente Instanciar(string nome);
        Cliente Validar(int id);
    }
}