using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Patchnotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forfeit15.Patchnotes.Controllers;

/// <summary>
/// Acties rondom patchnotes
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class PatchnoteController : ControllerBase
{
    //Services
    private readonly IPatchnoteService _patchnoteService;
    
    public PatchnoteController(IPatchnoteService patchnoteService)
    {
        _patchnoteService = patchnoteService;
    }

    /// <summary>
    /// Gets a collection of patchnotes
    /// </summary>
    /// <returns>Collection of patchnotes</returns>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _patchnoteService.GetAllAsync(cancellationToken));
    }

    [Authorize]
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid Id, CancellationToken cancellationToken)
    {
        return Ok(await _patchnoteService.GetByIdAsync(Id, cancellationToken));
    }


    /// <summary>
    /// Gets a collection of patchnotes
    /// </summary>
    /// <returns>Collection of patchnotes</returns>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PostNewPatchnoteAsync([FromBody] NewPatchNoteRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _patchnoteService.AddNewPatchNoteAsync(request, cancellationToken));
    }
}