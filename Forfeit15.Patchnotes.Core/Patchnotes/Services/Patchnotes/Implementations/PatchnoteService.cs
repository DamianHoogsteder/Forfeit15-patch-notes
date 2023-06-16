using System.Collections.ObjectModel;
using Forfeit15.Patchnotes.Core.Messaging;
using Forfeit15.Patchnotes.Core.Messaging.Contracts;
using Forfeit15.Patchnotes.Core.Patchnotes.Contracts;
using Forfeit15.Patchnotes.Postgres.Repositories.PatchNotes;
using Forfeit15.Postgres.Models;
using Microsoft.Extensions.Logging;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Services.Patchnotes.Implementations;

public class PatchnoteService : IPatchnoteService
{
    private readonly IPatchnoteRepository _patchnoteRepository;
    private readonly MessageService _messageService;
    private readonly ILogger<PatchnoteService> _logger;

    public PatchnoteService(IPatchnoteRepository patchNoteDbContext, MessageService messageService,
        ILogger<PatchnoteService> logger)
    {
        _patchnoteRepository = patchNoteDbContext;
        _messageService = messageService;
        _logger = logger;
    }

    public async Task<Collection<PatchNote>> GetAllAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all completed successfully");
        return new Collection<PatchNote>(await _patchnoteRepository.GetAllAsync(cancellationToken));
    }

    public async Task<GetByIdResponse> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var patchNote = await _patchnoteRepository.ByIdAsync(Id, cancellationToken);
        return new GetByIdResponse(patchNote);
    }

    public async Task<NewPatchNoteResponse> AddNewPatchNoteAsync(NewPatchNoteRequest request,
        CancellationToken cancellationToken)
    {
        var response = new NewPatchNoteResponse();
        await _patchnoteRepository.AddAsync(request.PatchNoteToBeAdded, cancellationToken);

        var message = new UpdateMessage
        {
            Type = "new-patch",
            UserId = new Guid(),
            Title = request.PatchNoteToBeAdded.Title,
            Description = request.PatchNoteToBeAdded.Description,
            TimeStamp = DateTime.UtcNow
        };

        _messageService.SendMessage(message);

        response.Result = ResponseResult.Succesful;
        return response;
    }
}