using CRMApplicationAPI.Models;
using CRMApplicationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRMApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ClientService clientService;

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClients()
        {
            return Ok(await clientService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClient(int id)
        {
            var client = await clientService.GetById(id);
            if (client == null)
                return NotFound();
            else
                return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateClient(Cliente client)
        {
            var novoCliente = await clientService.Create(client);
            return CreatedAtAction(nameof(GetClient), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await clientService.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var deletado = await clientService.Delete(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}
