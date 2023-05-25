using System.Runtime.Serialization;
using Forfeit15.Postgres.Models;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Contracts;

[DataContract]
public class GetByIdResponse
{
    [DataMember]
    public PatchNote PatchNote { get; set; } = null!;
    
    [DataMember]
    public ResponseResult? Result { get; set; } = null!;
    
    public GetByIdResponse(PatchNote patchNote)
    {
        PatchNote = patchNote;
        Result = patchNote != null ? ResponseResult.Succesful : ResponseResult.EntryNotFound;
    }
}