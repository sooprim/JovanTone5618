using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Manage library clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all clients", Description = "Retrieves all clients from the library")]
        [SwaggerResponse(200, "Successfully retrieved all clients")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get client by ID", Description = "Retrieves a specific client by their ID")]
        [SwaggerResponse(200, "Successfully retrieved the client")]
        [SwaggerResponse(404, "Client not found")]
        public async Task<ActionResult<ClientDto>> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new client", Description = "Registers a new client in the library")]
        [SwaggerResponse(201, "Successfully created the client")]
        [SwaggerResponse(400, "Invalid input")]
        public async Task<ActionResult<ClientDto>> Create([FromBody] ClientDto clientDto)
        {
            var createdClient = await _clientService.CreateAsync(clientDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a client", Description = "Updates an existing client's information")]
        [SwaggerResponse(200, "Successfully updated the client")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(400, "Invalid input")]
        public async Task<ActionResult<ClientDto>> Update(int id, [FromBody] ClientDto clientDto)
        {
            var updatedClient = await _clientService.UpdateAsync(id, clientDto);
            if (updatedClient == null)
                return NotFound();

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a client", Description = "Removes a client from the library")]
        [SwaggerResponse(204, "Successfully deleted the client")]
        [SwaggerResponse(404, "Client not found")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
} 