using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Forfeit15.Patchnotes.Api.Controllers;

/// <summary>
/// Acties rondom patchnotes
/// </summary>
[ApiController]
[Route("[controller]")]
public class PatchnoteController
{
    //Services

    public PatchnoteController()
    {
        
    }

    /// <summary>
    /// Gets a collection of patchnotes
    /// </summary>
    /// <returns>Collection of patchnotes</returns>
    [Authorize]
    [HttpGet("all")]
    [ProducesResponseType(typeof(PatchNote), StatusCodes.Status200OK)]
    public async Task<IActionResult> AllPatchNotes()
    {
        
    }
}