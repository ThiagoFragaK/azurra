using azurra.Server.Application;
using azurra.Server.Application.DTO;
using azurra.Server.Application.Interfaces;
using azurra.Server.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace azurra.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(IFileService fileService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<File>>> GetAll()
    {
        var files = await fileService.GetAllAsync();
        return Ok(files);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<File>> GetById(int id)
    {
        var file = await fileService.GetByIdAsync(id);
        if (file is null)
        {
            return NotFound();
        }

        return Ok(file);
    }

    [HttpPost]
    public async Task<ActionResult<File>> Create([FromBody] CreateFileRequest request)
    {
        var file = await fileService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = file.Id }, file);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<File>> Update(int id, [FromBody] UpdateFileRequest request)
    {
        var file = await fileService.UpdateAsync(id, request);
        if (file is null)
        {
            return NotFound();
        }

        return Ok(file);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await fileService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
