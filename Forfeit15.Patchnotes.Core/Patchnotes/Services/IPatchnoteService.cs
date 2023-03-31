using System.Collections.ObjectModel;
using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Postgres.Models;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services;

public interface IPatchnoteService
{
    Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken);
    Task<NewPatchNoteResponse> AddNewPatchNoteAsync(NewPatchNoteRequest request, CancellationToken cancellationToken);
}