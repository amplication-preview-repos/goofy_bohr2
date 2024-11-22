using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[ApiController()]
public class MessagesController : MessagesControllerBase
{
    public MessagesController(IMessagesService service)
        : base(service) { }
}
