using azurra.Server.Application.DTO;

namespace azurra.Server.Application.Interfaces;

public interface IFileService
{
    Task<IReadOnlyList<Domain.Models.File>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Domain.Models.File?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Domain.Models.File> CreateAsync(CreateFileRequest request, CancellationToken cancellationToken = default);

    Task<Domain.Models.File?> UpdateAsync(int id, UpdateFileRequest request, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
