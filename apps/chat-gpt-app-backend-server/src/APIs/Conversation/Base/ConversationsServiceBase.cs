using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using ChatGptAppBackend.APIs.Extensions;
using ChatGptAppBackend.Infrastructure;
using ChatGptAppBackend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatGptAppBackend.APIs;

public abstract class ConversationsServiceBase : IConversationsService
{
    protected readonly ChatGptAppBackendDbContext _context;

    public ConversationsServiceBase(ChatGptAppBackendDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Conversation
    /// </summary>
    public async Task<Conversation> CreateConversation(ConversationCreateInput createDto)
    {
        var conversation = new ConversationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            conversation.Id = createDto.Id;
        }

        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ConversationDbModel>(conversation.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Conversation
    /// </summary>
    public async Task DeleteConversation(ConversationWhereUniqueInput uniqueId)
    {
        var conversation = await _context.Conversations.FindAsync(uniqueId.Id);
        if (conversation == null)
        {
            throw new NotFoundException();
        }

        _context.Conversations.Remove(conversation);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Conversations
    /// </summary>
    public async Task<List<Conversation>> Conversations(ConversationFindManyArgs findManyArgs)
    {
        var conversations = await _context
            .Conversations.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return conversations.ConvertAll(conversation => conversation.ToDto());
    }

    /// <summary>
    /// Meta data about Conversation records
    /// </summary>
    public async Task<MetadataDto> ConversationsMeta(ConversationFindManyArgs findManyArgs)
    {
        var count = await _context.Conversations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Conversation
    /// </summary>
    public async Task<Conversation> Conversation(ConversationWhereUniqueInput uniqueId)
    {
        var conversations = await this.Conversations(
            new ConversationFindManyArgs { Where = new ConversationWhereInput { Id = uniqueId.Id } }
        );
        var conversation = conversations.FirstOrDefault();
        if (conversation == null)
        {
            throw new NotFoundException();
        }

        return conversation;
    }

    /// <summary>
    /// Update one Conversation
    /// </summary>
    public async Task UpdateConversation(
        ConversationWhereUniqueInput uniqueId,
        ConversationUpdateInput updateDto
    )
    {
        var conversation = updateDto.ToModel(uniqueId);

        _context.Entry(conversation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Conversations.Any(e => e.Id == conversation.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
