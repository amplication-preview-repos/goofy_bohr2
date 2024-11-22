using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;

namespace ChatGptAppBackend.APIs;

public interface IConversationsService
{
    /// <summary>
    /// Create one Conversation
    /// </summary>
    public Task<Conversation> CreateConversation(ConversationCreateInput conversation);

    /// <summary>
    /// Delete one Conversation
    /// </summary>
    public Task DeleteConversation(ConversationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Conversations
    /// </summary>
    public Task<List<Conversation>> Conversations(ConversationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Conversation records
    /// </summary>
    public Task<MetadataDto> ConversationsMeta(ConversationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Conversation
    /// </summary>
    public Task<Conversation> Conversation(ConversationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Conversation
    /// </summary>
    public Task UpdateConversation(
        ConversationWhereUniqueInput uniqueId,
        ConversationUpdateInput updateDto
    );
}
