using ChatGptAppBackend.Infrastructure;

namespace ChatGptAppBackend.APIs;

public class MessagesService : MessagesServiceBase
{
    public MessagesService(ChatGptAppBackendDbContext context)
        : base(context) { }
}
