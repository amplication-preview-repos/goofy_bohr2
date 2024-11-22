using ChatGptAppBackend.APIs;

namespace ChatGptAppBackend;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IConversationsService, ConversationsService>();
        services.AddScoped<IKernelIntegrationsService, KernelIntegrationsService>();
        services.AddScoped<IMessagesService, MessagesService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
