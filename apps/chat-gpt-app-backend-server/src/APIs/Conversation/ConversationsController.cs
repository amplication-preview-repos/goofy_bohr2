using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[ApiController()]
public class ConversationsController : ConversationsControllerBase
{
    public ConversationsController(IConversationsService service)
        : base(service) { }
}
