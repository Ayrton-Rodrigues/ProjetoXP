using CadastroCliente.Domain.Entity;
using CadastroCliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastroDbContext _context; 
        public ClienteRepository(CadastroDbContext context)
        {
            _context = context;
        }        
        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await _context.Clientes.AsNoTracking().Include(e => e.Endereco).ToListAsync();
        }
        public async Task<Cliente> ObterClientePorId(Guid id)
        {      
            return await _context.Clientes.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }        
        public Task<bool> Adicionar(Cliente cliente)
        {

            _context.Add(cliente);            
            return _context.Commit();
        }

        public Task<bool> Atualizar(Cliente cliente)
        {
            _context.Update(cliente);
            return _context.Commit();
        }

        public Task<bool> Remover(Cliente cliente)
        {                              
            _context.Remove(cliente);
            return _context.Commit();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}



