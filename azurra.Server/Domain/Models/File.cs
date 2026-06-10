namespace azurra.Server.Domain.Models;

public class File
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ReferenceFile { get; set; }

    public string? Desc { get; set; }

    public string? Status { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
