using SpeedEat.Dominio.Clientes.Entidades;
using NHibernate.Type;
using FluentNHibernate.Mapping;

namespace SpeedEat.Infra.Clientes.Mapeamentos
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("CLIENTE");
            Id(x => x.Id).Column("ID");
            Id(x => x.Nome).Column("NOME");
        }
    }
}