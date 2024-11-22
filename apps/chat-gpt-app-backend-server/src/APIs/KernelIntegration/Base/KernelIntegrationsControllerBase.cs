using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class KernelIntegrationsControllerBase : ControllerBase
{
    protected readonly IKernelIntegrationsService _service;

    public KernelIntegrationsControllerBase(IKernelIntegrationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one KernelIntegration
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<KernelIntegration>> CreateKernelIntegration(
        KernelIntegrationCreateInput input
    )
    {
        var kernelIntegration = await _service.CreateKernelIntegration(input);

        return CreatedAtAction(
            nameof(KernelIntegration),
            new { id = kernelIntegration.Id },
            kernelIntegration
        );
    }

    /// <summary>
    /// Delete one KernelIntegration
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteKernelIntegration(
        [FromRoute()] KernelIntegrationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteKernelIntegration(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many KernelIntegrations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<KernelIntegration>>> KernelIntegrations(
        [FromQuery()] KernelIntegrationFindManyArgs filter
    )
    {
        return Ok(await _service.KernelIntegrations(filter));
    }

    /// <summary>
    /// Meta data about KernelIntegration records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> KernelIntegrationsMeta(
        [FromQuery()] KernelIntegrationFindManyArgs filter
    )
    {
        return Ok(await _service.KernelIntegrationsMeta(filter));
    }

    /// <summary>
    /// Get one KernelIntegration
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<KernelIntegration>> KernelIntegration(
        [FromRoute()] KernelIntegrationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.KernelIntegration(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one KernelIntegration
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateKernelIntegration(
        [FromRoute()] KernelIntegrationWhereUniqueInput uniqueId,
        [FromQuery()] KernelIntegrationUpdateInput kernelIntegrationUpdateDto
    )
    {
        try
        {
            await _service.UpdateKernelIntegration(uniqueId, kernelIntegrationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
