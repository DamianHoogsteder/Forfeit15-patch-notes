using System.Collections.ObjectModel;
using System.Net;
using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services.Implementations;

public class PatchnoteService : IPatchnoteService
{
    private readonly PatchNoteDbContext _patchNoteDbContext;

    public PatchnoteService(PatchNoteDbContext patchNoteDbContext)
    {
        _patchNoteDbContext = patchNoteDbContext;
    }

    public async Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken)
    {
        return new Collection<PatchNote>(await _patchNoteDbContext.PatchNotes.ToListAsync(cancellationToken));
    }

    public async Task<GetByIdResponse> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var patchNote =  await _patchNoteDbContext.PatchNotes.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        return new GetByIdResponse(patchNote);
    }

    public async Task<NewPatchNoteResponse> AddNewPatchNoteAsync(NewPatchNoteRequest request, CancellationToken cancellationToken)
    {
        var response = new NewPatchNoteResponse();
        await _patchNoteDbContext.PatchNotes.AddAsync(request.PatchNoteToBeAdded, cancellationToken);
        await _patchNoteDbContext.SaveChangesAsync(cancellationToken);

        response.Result = ResponseResult.Succesful;
        return response;
    }
}