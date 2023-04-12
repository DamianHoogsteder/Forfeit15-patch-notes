using Forfeit15.Postgres.Models.Nodes;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services.InfoNodes;

public interface IInfoNodeService
{
    Task<ICollection<InfoNode>> GetAllTextNodes(string type, CancellationToken cancellationToken);
}