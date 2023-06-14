using APIMongodbs.Models;
using APIMongodbs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMongodbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteCollection db = new ClienteCollection();

        [HttpGet]

        public async Task<IActionResult> GetAllClientes()
        {
            return Ok(await db.GetAllCliente());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllClientesid(string id)
        {
            return Ok(db.GetClienteById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            if (cliente.firstName == String.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacío");
            }
            await db.InsertCliente(cliente);
            return Created("Creado", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente([FromBody] Cliente cliente, string id)
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            if(cliente.firstName == String.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacío");
            }
            cliente.id= new MongoDB.Bson.ObjectId(id);
            await db.UpdateCliente(cliente);
            return Created("Creado", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            await db.DeleteCliente(id);
            return NoContent();
        }
    }
}
