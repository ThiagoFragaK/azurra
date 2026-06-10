namespace azurra.Server.Repository.Interfaces;

public interface IFileRepository
{
    Task<IReadOnlyList<Domain.Models.File>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Domain.Models.File?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Domain.Models.File> AddAsync(Domain.Models.File file, CancellationToken cancellationToken = default);

    Task<Domain.Models.File?> UpdateAsync(Domain.Models.File file, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
