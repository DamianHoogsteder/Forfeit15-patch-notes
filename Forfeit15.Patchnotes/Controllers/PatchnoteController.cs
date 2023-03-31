using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Patchnotes.Core.Patchnotes.Services;
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
    //[Authorize]
    [HttpGet("all")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AllPatchNotes(CancellationToken cancellationToken)
    {
        return Ok(await _patchnoteService.GetAllAsync(cancellationToken));
    }
    
    /// <summary>
    /// Gets a collection of patchnotes
    /// </summary>
    /// <returns>Collection of patchnotes</returns>
    //[Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PostNewPatchnoteAsync([FromBody] NewPatchNoteRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _patchnoteService.AddNewPatchNoteAsync(request, cancellationToken));
    }
}