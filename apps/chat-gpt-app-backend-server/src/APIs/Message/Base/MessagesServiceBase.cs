using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using ChatGptAppBackend.APIs.Extensions;
using ChatGptAppBackend.Infrastructure;
using ChatGptAppBackend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatGptAppBackend.APIs;

public abstract class MessagesServiceBase : IMessagesService
{
    protected readonly ChatGptAppBackendDbContext _context;

    public MessagesServiceBase(ChatGptAppBackendDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Message
    /// </summary>
    public async Task<Message> CreateMessage(MessageCreateInput createDto)
    {
        var message = new MessageDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            message.Id = createDto.Id;
        }

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MessageDbModel>(message.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Message
    /// </summary>
    public async Task DeleteMessage(MessageWhereUniqueInput uniqueId)
    {
        var message = await _context.Messages.FindAsync(uniqueId.Id);
        if (message == null)
        {
            throw new NotFoundException();
        }

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Messages
    /// </summary>
    public async Task<List<Message>> Messages(MessageFindManyArgs findManyArgs)
    {
        var messages = await _context
            .Messages.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return messages.ConvertAll(message => message.ToDto());
    }

    /// <summary>
    /// Meta data about Message records
    /// </summary>
    public async Task<MetadataDto> MessagesMeta(MessageFindManyArgs findManyArgs)
    {
        var count = await _context.Messages.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Message
    /// </summary>
    public async Task<Message> Message(MessageWhereUniqueInput uniqueId)
    {
        var messages = await this.Messages(
            new MessageFindManyArgs { Where = new MessageWhereInput { Id = uniqueId.Id } }
        );
        var message = messages.FirstOrDefault();
        if (message == null)
        {
            throw new NotFoundException();
        }

        return message;
    }

    /// <summary>
    /// Update one Message
    /// </summary>
    public async Task UpdateMessage(MessageWhereUniqueInput uniqueId, MessageUpdateInput updateDto)
    {
        var message = updateDto.ToModel(uniqueId);

        _context.Entry(message).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Messages.Any(e => e.Id == message.Id))
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
