using ChatGptAppBackend.APIs;
using ChatGptAppBackend.APIs.Common;
using ChatGptAppBackend.APIs.Dtos;
using ChatGptAppBackend.APIs.Errors;
using ChatGptAppBackend.APIs.Extensions;
using ChatGptAppBackend.Infrastructure;
using ChatGptAppBackend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatGptAppBackend.APIs;

public abstract class KernelIntegrationsServiceBase : IKernelIntegrationsService
{
    protected readonly ChatGptAppBackendDbContext _context;

    public KernelIntegrationsServiceBase(ChatGptAppBackendDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one KernelIntegration
    /// </summary>
    public async Task<KernelIntegration> CreateKernelIntegration(
        KernelIntegrationCreateInput createDto
    )
    {
        var kernelIntegration = new KernelIntegrationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            kernelIntegration.Id = createDto.Id;
        }

        _context.KernelIntegrations.Add(kernelIntegration);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<KernelIntegrationDbModel>(kernelIntegration.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one KernelIntegration
    /// </summary>
    public async Task DeleteKernelIntegration(KernelIntegrationWhereUniqueInput uniqueId)
    {
        var kernelIntegration = await _context.KernelIntegrations.FindAsync(uniqueId.Id);
        if (kernelIntegration == null)
        {
            throw new NotFoundException();
        }

        _context.KernelIntegrations.Remove(kernelIntegration);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many KernelIntegrations
    /// </summary>
    public async Task<List<KernelIntegration>> KernelIntegrations(
        KernelIntegrationFindManyArgs findManyArgs
    )
    {
        var kernelIntegrations = await _context
            .KernelIntegrations.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return kernelIntegrations.ConvertAll(kernelIntegration => kernelIntegration.ToDto());
    }

    /// <summary>
    /// Meta data about KernelIntegration records
    /// </summary>
    public async Task<MetadataDto> KernelIntegrationsMeta(
        KernelIntegrationFindManyArgs findManyArgs
    )
    {
        var count = await _context.KernelIntegrations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one KernelIntegration
    /// </summary>
    public async Task<KernelIntegration> KernelIntegration(
        KernelIntegrationWhereUniqueInput uniqueId
    )
    {
        var kernelIntegrations = await this.KernelIntegrations(
            new KernelIntegrationFindManyArgs
            {
                Where = new KernelIntegrationWhereInput { Id = uniqueId.Id }
            }
        );
        var kernelIntegration = kernelIntegrations.FirstOrDefault();
        if (kernelIntegration == null)
        {
            throw new NotFoundException();
        }

        return kernelIntegration;
    }

    /// <summary>
    /// Update one KernelIntegration
    /// </summary>
    public async Task UpdateKernelIntegration(
        KernelIntegrationWhereUniqueInput uniqueId,
        KernelIntegrationUpdateInput updateDto
    )
    {
        var kernelIntegration = updateDto.ToModel(uniqueId);

        _context.Entry(kernelIntegration).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.KernelIntegrations.Any(e => e.Id == kernelIntegration.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
