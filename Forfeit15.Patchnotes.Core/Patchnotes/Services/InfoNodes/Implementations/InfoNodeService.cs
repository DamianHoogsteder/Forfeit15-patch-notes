using Forfeit15.Patchnotes.Postgres.Repositories.InfoNodes;
using Forfeit15.Postgres.Models.Nodes;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services.InfoNodes.Implementations;

public class InfoNodeService : IInfoNodeService
{
    private readonly IInfoNodeRepository _infoNodeRepository;

    public InfoNodeService(IInfoNodeRepository infoNodeRepository)
    {
        _infoNodeRepository = infoNodeRepository;
    }

    public async Task<ICollection<InfoNode>> GetAllTextNodes(string type, CancellationToken cancellationToken)
    {
        return await _infoNodeRepository.GetAllByType(type, cancellationToken);
    }
}