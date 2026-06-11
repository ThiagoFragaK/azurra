using azurra.Server.Application.DTO;
using azurra.Server.Application.Interfaces;
using azurra.Server.Repository.Interfaces;
using FileModel = azurra.Server.Domain.Models.File;

namespace azurra.Server.Application;

public class FileService(IFileRepository fileRepository) : IFileService
{
    public Task<IReadOnlyList<FileModel>> GetAllAsync()
    {
        return fileRepository.GetAllAsync();
    }

    public Task<FileModel?> GetByIdAsync(int id)
    {
        return fileRepository.GetByIdAsync(id);
    }

    public Task<FileModel> CreateAsync(CreateFileRequest request)
    {
        var now = DateTime.UtcNow;
        var file = new FileModel
        {
            Name = request.Name,
            ReferenceFile = request.ReferenceFile,
            Desc = request.Desc,
            Status = request.Status,
            CreateAt = now,
            UpdatedAt = now
        };

        return fileRepository.AddAsync(file);
    }

    public Task<FileModel?> UpdateAsync(int id, UpdateFileRequest request)
    {
        var file = new FileModel
        {
            Id = id,
            Name = request.Name,
            ReferenceFile = request.ReferenceFile,
            Desc = request.Desc,
            Status = request.Status,
            UpdatedAt = DateTime.UtcNow
        };

        return fileRepository.UpdateAsync(file);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return fileRepository.DeleteAsync(id);
    }
}
