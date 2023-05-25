using System.Collections.ObjectModel;
using Forfeit15.Postgres.Models;

namespace Forfeit15.Patchnotes.Postgres.Repositories.PatchNotes;

public interface IPatchnoteRepository
{
    Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken);
    Task<PatchNote> ByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task AddAsync(PatchNote request, CancellationToken cancellationToken);
}