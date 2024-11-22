using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MessagesControllerBase : ControllerBase
{
    protected readonly IMessagesService _service;

    public MessagesControllerBase(IMessagesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Message
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Message>> CreateMessage(MessageCreateInput input)
    {
        var message = await _service.CreateMessage(input);

        return CreatedAtAction(nameof(Message), new { id = message.Id }, message);
    }

    /// <summary>
    /// Delete one Message
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMessage([FromRoute()] MessageWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMessage(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Messages
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Message>>> Messages(
        [FromQuery()] MessageFindManyArgs filter
    )
    {
        return Ok(await _service.Messages(filter));
    }

    /// <summary>
    /// Meta data about Message records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MessagesMeta(
        [FromQuery()] MessageFindManyArgs filter
    )
    {
        return Ok(await _service.MessagesMeta(filter));
    }

    /// <summary>
    /// Get one Message
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Message>> Message([FromRoute()] MessageWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Message(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Message
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMessage(
        [FromRoute()] MessageWhereUniqueInput uniqueId,
        [FromQuery()] MessageUpdateInput messageUpdateDto
    )
    {
        try
        {
            await _service.UpdateMessage(uniqueId, messageUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
