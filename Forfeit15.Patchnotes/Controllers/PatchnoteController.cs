using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forfeit15.Patchnotes.Controllers;

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
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> AllPatchNotes()
    {
        return null;
    }
}