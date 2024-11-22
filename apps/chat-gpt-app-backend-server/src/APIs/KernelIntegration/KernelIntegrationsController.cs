using Microsoft.AspNetCore.Mvc;

namespace ChatGptAppBackend.APIs;

[ApiController()]
public class KernelIntegrationsController : KernelIntegrationsControllerBase
{
    public KernelIntegrationsController(IKernelIntegrationsService service)
        : base(service) { }
}
