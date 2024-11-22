using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;

namespace ChatGptAppBackend.APIs;

public interface IMessagesService
{
    /// <summary>
    /// Create one Message
    /// </summary>
    public Task<Message> CreateMessage(MessageCreateInput message);

    /// <summary>
    /// Delete one Message
    /// </summary>
    public Task DeleteMessage(MessageWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Messages
    /// </summary>
    public Task<List<Message>> Messages(MessageFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Message records
    /// </summary>
    public Task<MetadataDto> MessagesMeta(MessageFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Message
    /// </summary>
    public Task<Message> Message(MessageWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Message
    /// </summary>
    public Task UpdateMessage(MessageWhereUniqueInput uniqueId, MessageUpdateInput updateDto);
}
