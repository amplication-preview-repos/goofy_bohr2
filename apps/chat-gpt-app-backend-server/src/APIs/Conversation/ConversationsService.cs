using ChatGptAppBackend.Infrastructure;

namespace ChatGptAppBackend.APIs;

public class ConversationsService : ConversationsServiceBase
{
    public ConversationsService(ChatGptAppBackendDbContext context)
        : base(context) { }
}
