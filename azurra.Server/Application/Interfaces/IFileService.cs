using azurra.Server.Application.DTO;
using FileModel = azurra.Server.Domain.Models.File;

namespace azurra.Server.Application.Interfaces;

public interface IFileService
{
    Task<IReadOnlyList<FileModel>> GetAllAsync();

    Task<FileModel?> GetByIdAsync(int id);

    Task<FileModel> CreateAsync(CreateFileRequest request);

    Task<FileModel?> UpdateAsync(int id, UpdateFileRequest request);

    Task<bool> DeleteAsync(int id);
}
