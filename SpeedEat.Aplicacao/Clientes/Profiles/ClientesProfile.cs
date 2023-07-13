using AutoMapper;
using SpeedEat.DataTransfer.Clientes.Responses;

namespace SpeedEat.Aplicacao
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
            CreateMap<ClientesProfile, ClienteResponse>();
        }
    }
}