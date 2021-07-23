using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OwnersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetOwners(CancellationToken cancellationToken)
        {
            var owners = await _serviceManager.OwnerService.GetAllAsync(cancellationToken);

            return Ok(owners);
        }

        [HttpGet("{ownerId:guid}")]
        public async Task<IActionResult> GetOwnerById(Guid ownerId, CancellationToken cancellationToken)
        {
            var ownerDto = await _serviceManager.OwnerService.GetByIdAsync(ownerId, cancellationToken);

            return Ok(ownerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto ownerForCreationDto)
        {
            var ownerDto = await _serviceManager.OwnerService.CreateAsync(ownerForCreationDto);

            return CreatedAtAction(nameof(GetOwnerById), new { ownerId = ownerDto.Id }, ownerDto);
        }

        [HttpPut("{ownerId:guid}")]
        public async Task<IActionResult> UpdateOwner(Guid ownerId, [FromBody] OwnerForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.OwnerService.UpdateAsync(ownerId, ownerForUpdateDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{ownerId:guid}")]
        public async Task<IActionResult> DeleteOwner(Guid ownerId, CancellationToken cancellationToken)
        {
            await _serviceManager.OwnerService.DeleteAsync(ownerId, cancellationToken);

            return NoContent();
        }
    }
}
