using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
