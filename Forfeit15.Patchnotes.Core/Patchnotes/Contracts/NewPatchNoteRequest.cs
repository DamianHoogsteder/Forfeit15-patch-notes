using System.Runtime.Serialization;
using Forfeit15.Postgres.Models;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Contracts;

[DataContract]
public class NewPatchNoteRequest
{
    [DataMember] public PatchNote PatchNoteToBeAdded { get; set; } = null!;
}