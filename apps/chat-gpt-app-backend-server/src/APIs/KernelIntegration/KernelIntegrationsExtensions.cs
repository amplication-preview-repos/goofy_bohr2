using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.Infrastructure.Models;

namespace ChatGptAppBackend.APIs.Extensions;

public static class KernelIntegrationsExtensions
{
    public static KernelIntegration ToDto(this KernelIntegrationDbModel model)
    {
        return new KernelIntegration
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static KernelIntegrationDbModel ToModel(
        this KernelIntegrationUpdateInput updateDto,
        KernelIntegrationWhereUniqueInput uniqueId
    )
    {
        var kernelIntegration = new KernelIntegrationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            kernelIntegration.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            kernelIntegration.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return kernelIntegration;
    }
}
