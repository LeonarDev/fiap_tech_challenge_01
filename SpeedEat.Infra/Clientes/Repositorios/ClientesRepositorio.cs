using NHibernate;
using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Clientes.Repositorios;
using SpeedEat.Dominio.Clientes.Repositorios.Filtros;

namespace SpeedEat.Infra.Clientes.Repositorios
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private readonly ISession _session;

        public ClientesRepositorio(ISession session)
        {
            _session = session;
        }

        public void Inserir(Cliente cliente)
        {
            _session.Save(cliente);
        }

        public void Editar(Cliente cliente)
        {
            _session.Update(cliente);
        }

        public Cliente Recuperar(int idCliente)
        {
            return _session.Get<Cliente>(idCliente);
        }

        public IEnumerable<Cliente> Listar(ClienteListarFiltro filtro)
        {
            IQueryable<Cliente> query = _session.Query<Cliente>();

            if (filtro.Id.HasValue)
            {
                query = query.Where(x => x.Id == filtro.Id);
            }

            if (filtro.Nome != null)
            {
                query = query.Where(x => x.Nome == filtro.Nome);
            }

            return query;
        }
    }
}