using azurra.Server.Application.DTO;
using azurra.Server.Application.Interfaces;
using azurra.Server.Repository.Interfaces;

namespace azurra.Server.Application;

public class FileService(IFileRepository fileRepository) : IFileService
{
    public Task<IReadOnlyList<Domain.Models.File>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return fileRepository.GetAllAsync(cancellationToken);
    }

    public Task<Domain.Models.File?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return fileRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<Domain.Models.File> CreateAsync(CreateFileRequest request, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        var file = new Domain.Models.File
        {
            Name = request.Name,
            ReferenceFile = request.ReferenceFile,
            Desc = request.Desc,
            Status = request.Status,
            CreateAt = now,
            UpdatedAt = now
        };

        return fileRepository.AddAsync(file, cancellationToken);
    }

    public Task<Domain.Models.File?> UpdateAsync(int id, UpdateFileRequest request, CancellationToken cancellationToken = default)
    {
        var file = new Domain.Models.File
        {
            Id = id,
            Name = request.Name,
            ReferenceFile = request.ReferenceFile,
            Desc = request.Desc,
            Status = request.Status,
            UpdatedAt = DateTime.UtcNow
        };

        return fileRepository.UpdateAsync(file, cancellationToken);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return fileRepository.DeleteAsync(id, cancellationToken);
    }
}
