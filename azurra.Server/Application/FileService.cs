using azurra.Server.Application.DTO;
using azurra.Server.Application.Interfaces;
using azurra.Server.Domain.Models;
using azurra.Server.Repository.Interfaces;

namespace azurra.Server.Application;

public class FileService(IFileRepository fileRepository) : IFileService
{
    public Task<IReadOnlyList<File>> GetAllAsync()
    {
        return fileRepository.GetAllAsync();
    }

    public Task<File?> GetByIdAsync(int id)
    {
        return fileRepository.GetByIdAsync(id);
    }

    public Task<File> CreateAsync(CreateFileRequest request)
    {
        var now = DateTime.UtcNow;
        var file = new File
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

    public Task<File?> UpdateAsync(int id, UpdateFileRequest request)
    {
        var file = new File
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
