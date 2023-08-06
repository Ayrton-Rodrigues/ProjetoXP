using AutoMapper;
using CadastroCliente.Application.ViewModels;
using CadastroCliente.Domain.Entity;
using CadastroCliente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes()
        {
            var clientes =  _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodosClientes());

            return clientes;
        }
        public async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClientePorId(id));

            return cliente;
        }

        public  async Task<bool> Adicionar(ClienteViewModel cliente)
        {
            var clienteSalvar = _mapper.Map<Cliente>(cliente);

            await _clienteRepository.Adicionar(clienteSalvar);

            return true;
        }

        public async Task<bool> Atualizar(ClienteViewModel cliente)
        {
            var clienteAtualizar = _mapper.Map<Cliente>(cliente);

            await _clienteRepository.Atualizar(clienteAtualizar);

            return true;
        }

        public async Task<bool> Remover(ClienteViewModel cliente)
        {
            var clienteExcluir = _mapper.Map<Cliente>(cliente);

            await _clienteRepository.Remover(clienteExcluir);

            return true;
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
