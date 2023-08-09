using CadastroCliente.Application.Services;
using CadastroCliente.Application.ViewModels;
using CadastroCliente.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroCliente.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {

        private readonly IClienteService _clienteService;
        
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet("Obter-clientes")]
     
        public async Task<IActionResult> ObterTodos()
        {
    
            var clientes = await _clienteService.ObterTodosClientes();

            return CustomResponse(clientes);       
        }

        [HttpGet("Obter-cliente-por-id/{id:guid}")]
        public async Task<IActionResult> ObterClientePorId(Guid id)
        {
          
            var cliente = await _clienteService.ObterClientePorId(id);

            if (cliente == null) return NotFound();

            return CustomResponse(cliente);
        
        }

       
        [HttpPost("Adicionar-cliente")]
            
        public async Task<IActionResult> AdicionarCliente(ClienteViewModel cliente)
        {           

                if (!ModelState.IsValid) return CustomResponse(ModelState);
                
                await _clienteService.Adicionar(cliente);                
                
                return CustomResponse(cliente); 
          
        }

        [HttpPut("Atualizar-cliente/{id:guid}")]        
        public async Task<IActionResult> AtualizarCliente(Guid id, ClienteViewModel cliente)
        {
            
            if (id != cliente.Id) return CustomResponse(cliente);
            
            if (!ModelState.IsValid) CustomResponse(ModelState);

            await _clienteService.Atualizar(cliente);
                
            return CustomResponse(cliente);

        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {   
                var cliente = await _clienteService.ObterClientePorId(id);

                if (cliente == null) return NotFound();

                await _clienteService.Remover(cliente);
                
                return CustomResponse(cliente);       
        }
    }
}
     