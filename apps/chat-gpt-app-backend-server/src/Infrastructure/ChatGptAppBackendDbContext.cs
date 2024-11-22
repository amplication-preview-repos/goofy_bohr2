using ChatGptAppBackend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatGptAppBackend.Infrastructure;

public class ChatGptAppBackendDbContext : DbContext
{
    public ChatGptAppBackendDbContext(DbContextOptions<ChatGptAppBackendDbContext> options)
        : base(options) { }

    public DbSet<ConversationDbModel> Conversations { get; set; }

    public DbSet<MessageDbModel> Messages { get; set; }

    public DbSet<KernelIntegrationDbModel> KernelIntegrations { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
