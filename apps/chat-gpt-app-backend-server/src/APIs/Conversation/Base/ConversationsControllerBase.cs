using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ConversationsControllerBase : ControllerBase
{
    protected readonly IConversationsService _service;

    public ConversationsControllerBase(IConversationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Conversation
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Conversation>> CreateConversation(ConversationCreateInput input)
    {
        var conversation = await _service.CreateConversation(input);

        return CreatedAtAction(nameof(Conversation), new { id = conversation.Id }, conversation);
    }

    /// <summary>
    /// Delete one Conversation
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteConversation(
        [FromRoute()] ConversationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteConversation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Conversations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Conversation>>> Conversations(
        [FromQuery()] ConversationFindManyArgs filter
    )
    {
        return Ok(await _service.Conversations(filter));
    }

    /// <summary>
    /// Meta data about Conversation records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ConversationsMeta(
        [FromQuery()] ConversationFindManyArgs filter
    )
    {
        return Ok(await _service.ConversationsMeta(filter));
    }

    /// <summary>
    /// Get one Conversation
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Conversation>> Conversation(
        [FromRoute()] ConversationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Conversation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Conversation
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateConversation(
        [FromRoute()] ConversationWhereUniqueInput uniqueId,
        [FromQuery()] ConversationUpdateInput conversationUpdateDto
    )
    {
        try
        {
            await _service.UpdateConversation(uniqueId, conversationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
