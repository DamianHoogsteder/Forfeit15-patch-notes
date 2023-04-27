namespace Forfeit15.Patchnotes.Core.Messaging.Contracts;

public class UpdateMessage
{
    public string Type { get; set; } = null!;
    public Guid UserId { get; set; }
    public MessageBody Message { get; set; }
}