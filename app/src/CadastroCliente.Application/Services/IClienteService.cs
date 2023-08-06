using CadastroCliente.Application.ViewModels;
using CadastroCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> ObterTodosClientes();

        Task<ClienteViewModel> ObterClientePorId(Guid id);

        Task<bool> Adicionar(ClienteViewModel cliente);
        Task<bool> Atualizar(ClienteViewModel cliente);
        Task<bool> Remover(ClienteViewModel cliente);
        
        void AtualizarEndereco(Endereco endereco);
    }
}
