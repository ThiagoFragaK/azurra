using System.ComponentModel.DataAnnotations;

namespace azurra.Server.Application.DTO;

public class CreateFileRequest
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? ReferenceFile { get; set; }

    [MaxLength(2000)]
    public string? Desc { get; set; }

    [MaxLength(50)]
    public string? Status { get; set; }
}
