using System.Runtime.Serialization;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Contracts;

[DataContract]
public class NewPatchNoteResponse
{
    [DataMember]
    public ResponseResult? Result { get; set; } = null!;
}