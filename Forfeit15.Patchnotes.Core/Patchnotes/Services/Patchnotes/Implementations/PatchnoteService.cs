using System.Collections.ObjectModel;
using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Patchnotes.Postgres.Repositories;
using Forfeit15.Patchnotes.Postgres.Repositories.PatchNotes;
using Forfeit15.Postgres.Models;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services.Patchnotes.Implementations;

public class PatchnoteService : IPatchnoteService
{
    private readonly IPatchnoteRepository _patchnoteRepository;

    public PatchnoteService(IPatchnoteRepository patchNoteDbContext)
    {
        _patchnoteRepository = patchNoteDbContext;
    }

    public async Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken)
    {
        return new Collection<PatchNote>(await _patchnoteRepository.GetAllAsync(cancellationToken));
    }

    public async Task<GetByIdResponse> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var patchNote =  await _patchnoteRepository.ByIdAsync(Id, cancellationToken);
        return new GetByIdResponse(patchNote);
    }

    public async Task<NewPatchNoteResponse> AddNewPatchNoteAsync(NewPatchNoteRequest request, CancellationToken cancellationToken)
    {
        var response = new NewPatchNoteResponse();
        await _patchnoteRepository.AddAsync(request.PatchNoteToBeAdded, cancellationToken);
        
        response.Result = ResponseResult.Succesful;
        return response;
    }
}