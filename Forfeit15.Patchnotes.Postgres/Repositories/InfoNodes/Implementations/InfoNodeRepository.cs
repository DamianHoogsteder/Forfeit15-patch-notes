using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Models.Nodes;
using Microsoft.EntityFrameworkCore;

namespace Forfeit15.Patchnotes.Postgres.Repositories.InfoNodes.Implementations;

public class InfoNodeRepository : IInfoNodeRepository
{
    private readonly PatchNoteDbContext _patchNoteDbContext;

    public InfoNodeRepository(PatchNoteDbContext patchNoteDbContext)
    {
        _patchNoteDbContext = patchNoteDbContext;
    }

    public async Task<ICollection<InfoNode>> GetAllByType(string type, CancellationToken cancellationToken)
    {
        var textNodes = await _patchNoteDbContext.InfoNodes
            .AsQueryable()
            .Where(n => n.NodeType == type)
            .ToListAsync(cancellationToken);
        return textNodes;
    }
}