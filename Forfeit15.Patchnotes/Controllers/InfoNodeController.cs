using Forfeit15.Patchnotes.Core.Patchnotes.Services.InfoNodes;
using Microsoft.AspNetCore.Mvc;

namespace Forfeit15.Patchnotes.Controllers;

/// <summary>
/// Acties rondom infoNodes
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class InfoNodeController : ControllerBase
{
    //Services
    private readonly IInfoNodeService _infoNodeService;
    public InfoNodeController(IInfoNodeService infoNodeService)
    {
        _infoNodeService = infoNodeService;
    }
    

    //[Authorize]
    [HttpGet("{type}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAllOfType(string type, CancellationToken cancellationToken)
    {
        return Ok(await _infoNodeService.GetAllTextNodes(type, cancellationToken));
    }
}