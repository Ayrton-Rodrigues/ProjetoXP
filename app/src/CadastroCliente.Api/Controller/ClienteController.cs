using CadastroCliente.Application.Services;
using CadastroCliente.Application.ViewModels;
using CadastroCliente.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroCliente.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
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
            try
            {
                var result = await _clienteService.ObterTodosClientes();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Obter-cliente-por-id/{id:guid}")]
        public async Task<IActionResult> ObterClientePorId(Guid id)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorId(id);

                if (cliente == null) return NotFound();

                return Ok(
                    new { 
                    success = true,
                    data = cliente
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       
        [HttpPost("Adicionar-cliente")]
            
        public async Task<IActionResult> AdicionarCliente(ClienteViewModel cliente)
        {
            try
            {
                var resultado = await _clienteService.Adicionar(cliente);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar-cliente/{id:guid}")]        
        public async Task<IActionResult> AtualizarCliente(Guid id, ClienteViewModel cliente)
        {
            try
            {
                if (id != cliente.Id) return NotFound(cliente);

                var resultado = await _clienteService.Atualizar(cliente);
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorId(id);

                if (cliente == null) return NotFound();

                var resultado = await _clienteService.Remover(cliente);
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
     