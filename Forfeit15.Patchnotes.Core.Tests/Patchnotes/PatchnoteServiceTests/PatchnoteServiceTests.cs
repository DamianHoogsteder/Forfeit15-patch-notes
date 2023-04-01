using System.Collections.ObjectModel;
using FluentAssertions;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Implementations;
using Forfeit15.Patchnotes.Postgres.Repositories;
using Forfeit15.Postgres.Models;
using Moq;

namespace Forfeit15.Patchnotes.Core.Tests.Patchnotes.PatchnoteServiceTests;

[TestFixture]
public class PatchNoteServiceTests
{
    private PatchnoteService _patchNoteService;
    private Mock<IPatchnoteRepository> _patchnoteRepository;

    [SetUp]
    public void SetUp()
    {
        _patchnoteRepository = new Mock<IPatchnoteRepository>();
        _patchNoteService = new PatchnoteService(_patchnoteRepository.Object);
    }

    [Test]
    public async Task GetAll_ReturnsCollectionofPatchnotes()
    {
        // Arrange
        var expectedPatchNotes = new Collection<PatchNote>
        {
            new PatchNote { Id = new Guid(), Title = "test" }
        };
        var cancellationToken = new CancellationToken();

        _patchnoteRepository.Setup(x => x.GetAllAsync(cancellationToken)).ReturnsAsync(expectedPatchNotes);
        
        //Act
        var result = await _patchNoteService.GetAllAsync(cancellationToken);
        
        //Assert
        result.Should().BeEquivalentTo(expectedPatchNotes);
    }
}