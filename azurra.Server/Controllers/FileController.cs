using azurra.Server.Application;
using azurra.Server.Application.DTO;
using azurra.Server.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace azurra.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(IFileService fileService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Domain.Models.File>>> GetAll(CancellationToken cancellationToken)
    {
        var files = await fileService.GetAllAsync(cancellationToken);
        return Ok(files);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Domain.Models.File>> GetById(int id, CancellationToken cancellationToken)
    {
        var file = await fileService.GetByIdAsync(id, cancellationToken);
        if (file is null)
        {
            return NotFound();
        }

        return Ok(file);
    }

    [HttpPost]
    public async Task<ActionResult<Domain.Models.File>> Create(
        [FromBody] CreateFileRequest request,
        CancellationToken cancellationToken)
    {
        var file = await fileService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = file.Id }, file);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Domain.Models.File>> Update(
        int id,
        [FromBody] UpdateFileRequest request,
        CancellationToken cancellationToken)
    {
        var file = await fileService.UpdateAsync(id, request, cancellationToken);
        if (file is null)
        {
            return NotFound();
        }

        return Ok(file);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await fileService.DeleteAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
