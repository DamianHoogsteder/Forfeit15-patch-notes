using Forfeit15.Postgres.Models.Nodes;

namespace Forfeit15.Patchnotes.Postgres.Repositories.InfoNodes;

public interface IInfoNodeRepository
{
    Task<ICollection<InfoNode>> GetAllByType(string type, CancellationToken cancellationToken);
}