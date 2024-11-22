using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.Infrastructure.Models;

namespace ChatGptAppBackend.APIs.Extensions;

public static class ConversationsExtensions
{
    public static Conversation ToDto(this ConversationDbModel model)
    {
        return new Conversation
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ConversationDbModel ToModel(
        this ConversationUpdateInput updateDto,
        ConversationWhereUniqueInput uniqueId
    )
    {
        var conversation = new ConversationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            conversation.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            conversation.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return conversation;
    }
}
