using azurra.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace azurra.Server.Repository;

public class FileRepository(AppDbContext context) : IFileRepository
{
    public async Task<IReadOnlyList<Domain.Models.File>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Files
            .AsNoTracking()
            .OrderByDescending(f => f.UpdatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Models.File?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Files
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }

    public async Task<Domain.Models.File> AddAsync(Domain.Models.File file, CancellationToken cancellationToken = default)
    {
        context.Files.Add(file);
        await context.SaveChangesAsync(cancellationToken);
        return file;
    }

    public async Task<Domain.Models.File?> UpdateAsync(Domain.Models.File file, CancellationToken cancellationToken = default)
    {
        var existing = await context.Files.FirstOrDefaultAsync(f => f.Id == file.Id, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        existing.Name = file.Name;
        existing.ReferenceFile = file.ReferenceFile;
        existing.Desc = file.Desc;
        existing.Status = file.Status;
        existing.UpdatedAt = file.UpdatedAt;

        await context.SaveChangesAsync(cancellationToken);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await context.Files.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (existing is null)
        {
            return false;
        }

        context.Files.Remove(existing);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
