using AutoMapper;
using NHibernate;
using SpeedEat.Aplicacao.Clientes.Servicos.Interfaces;
using SpeedEat.DataTransfer.Clientes.Requests;
using SpeedEat.DataTransfer.Clientes.Responses;
using SpeedEat.Dominio.Clientes.Entidades;
using SpeedEat.Dominio.Clientes.Repositorios;
using SpeedEat.Dominio.Clientes.Repositorios.Filtros;
using SpeedEat.Dominio.Clientes.Servicos.Interfaces;
using SpeedEat.Infra.Clientes.Repositorios;
using System;

namespace SpeedEat.Aplicacao.Clientes.Servico
{
    public class ClientesAppServico : IClientesAppServico
    {
        private readonly IClientesRepositorio _clientesRepositorio;
        private readonly IClientesServico _clientesServico;
        private readonly IMapper _mapper;
        private  ITransaction _transaction;
        private ISession _session;

        public ClientesAppServico(
            IClientesRepositorio clientesRepositorio,
            IClientesServico clientesServico,
            ITransaction transaction,
            ISession session,
            IMapper mapper)
        {
            _clientesRepositorio = clientesRepositorio;
            _clientesServico = clientesServico;
            _transaction = transaction;
            _session = session;
            _mapper = mapper;
        }

        public ClienteResponse Inserir(ClienteRequest request)
        {
            try
            {
                Cliente cliente = _clientesServico.Instanciar(request.Nome);

                BeginTransaction();

                _clientesRepositorio.Inserir(cliente);

                Commit();
                
                ClienteResponse response = _mapper.Map<ClienteResponse>(cliente);

                return response;

            }
            catch (Exception)
            {
                RollBack();
                throw;
            }
        }
        
        public ClienteResponse Recuperar(int id)
        {
            Cliente cliente = _clientesRepositorio.Recuperar(id);

            ClienteResponse response = _mapper.Map<ClienteResponse>(cliente);

            return response;
        }
        
        public ClienteResponse Editar(int id, ClienteRequest request)
        {
            try
            {
                Cliente cliente = _clientesServico.Validar(id);

                BeginTransaction();

                cliente.SetNome(request.Nome);

                _clientesRepositorio.Editar(cliente);

                Commit();

                ClienteResponse response = _mapper.Map<ClienteResponse>(cliente);

                return response;

            }
            catch (Exception)
            {
                RollBack();
                throw;
            }
        }

        public IEnumerable<ClienteResponse> Listar(ClienteListarRequest request)
        {
            ClienteListarFiltro filtro = _mapper.Map<ClienteListarFiltro>(request);

            IEnumerable<Cliente> clientes = _clientesRepositorio.Listar(filtro);

            IEnumerable<ClienteResponse> response = _mapper.Map<IEnumerable<ClienteResponse>>(clientes);

            return response;
        }

        /// <summary>
        /// Métodos de transação
        /// </summary>
        private void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        private void Commit()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Commit();
            }
        }

        private void RollBack()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

    }
}