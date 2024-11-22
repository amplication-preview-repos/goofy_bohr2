using ChatGptAppBackend.Infrastructure;

namespace ChatGptAppBackend.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(ChatGptAppBackendDbContext context)
        : base(context) { }
}
