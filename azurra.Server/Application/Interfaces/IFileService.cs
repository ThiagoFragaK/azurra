using azurra.Server.Application.DTO;
using azurra.Server.Domain.Models;

namespace azurra.Server.Application.Interfaces;

public interface IFileService
{
    Task<IReadOnlyList<File>> GetAllAsync();

    Task<File?> GetByIdAsync(int id);

    Task<File> CreateAsync(CreateFileRequest request);

    Task<File?> UpdateAsync(int id, UpdateFileRequest request);

    Task<bool> DeleteAsync(int id);
}
