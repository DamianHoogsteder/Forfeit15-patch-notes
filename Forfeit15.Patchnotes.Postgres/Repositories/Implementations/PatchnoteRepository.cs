using System.Collections.ObjectModel;
using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Forfeit15.Patchnotes.Postgres.Repositories.Implementations;

public class PatchnoteRepository : IPatchnoteRepository
{
    private readonly PatchNoteDbContext _patchNoteDbContext;

    public PatchnoteRepository(PatchNoteDbContext patchNoteDbContext)
    {
        _patchNoteDbContext = patchNoteDbContext;
    }

    public async Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken)
    {
        return new Collection<PatchNote>(await _patchNoteDbContext.PatchNotes.ToListAsync(cancellationToken));
    }

    public async Task<PatchNote> ByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var patchNote =  await _patchNoteDbContext.PatchNotes.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        return patchNote;
    }

    public async Task AddAsync(PatchNote request, CancellationToken cancellationToken)
    {
        await _patchNoteDbContext.PatchNotes.AddAsync(request, cancellationToken);
        await _patchNoteDbContext.SaveChangesAsync(cancellationToken);
    }
}