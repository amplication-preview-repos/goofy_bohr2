using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;

namespace ChatGptAppBackend.APIs;

public interface IKernelIntegrationsService
{
    /// <summary>
    /// Create one KernelIntegration
    /// </summary>
    public Task<KernelIntegration> CreateKernelIntegration(
        KernelIntegrationCreateInput kernelintegration
    );

    /// <summary>
    /// Delete one KernelIntegration
    /// </summary>
    public Task DeleteKernelIntegration(KernelIntegrationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many KernelIntegrations
    /// </summary>
    public Task<List<KernelIntegration>> KernelIntegrations(
        KernelIntegrationFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about KernelIntegration records
    /// </summary>
    public Task<MetadataDto> KernelIntegrationsMeta(KernelIntegrationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one KernelIntegration
    /// </summary>
    public Task<KernelIntegration> KernelIntegration(KernelIntegrationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one KernelIntegration
    /// </summary>
    public Task UpdateKernelIntegration(
        KernelIntegrationWhereUniqueInput uniqueId,
        KernelIntegrationUpdateInput updateDto
    );
}
