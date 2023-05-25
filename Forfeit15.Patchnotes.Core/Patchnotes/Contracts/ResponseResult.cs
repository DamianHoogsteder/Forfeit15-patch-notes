using System.Runtime.Serialization;

namespace Forfeit15.Patchnotes.Core.Patchnotes.Contracts;

[DataContract]
public enum ResponseResult
{
    [DataMember]
    Succesful,
    
    [DataMember]
    Unsuccesful,
    
    [DataMember]
    EntryNotFound
}