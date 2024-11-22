using ChatGptAppBackend.Infrastructure;

namespace ChatGptAppBackend.APIs;

public class KernelIntegrationsService : KernelIntegrationsServiceBase
{
    public KernelIntegrationsService(ChatGptAppBackendDbContext context)
        : base(context) { }
}
