using System.Runtime.Serialization;

namespace Forfeit15.Patchnotes.Core.Messaging.Contracts;

[DataContract]
public class UpdateEvent : Message
{
    [DataMember] public Guid PatchId { get; set; }
    
    [DataMember] public string Subscriptor { get; set; }
}