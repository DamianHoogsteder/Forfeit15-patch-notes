namespace Forfeit15.Patchnotes.Core.Messaging.Contracts;

public class MessageBody
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime TimeStamp { get; set; }
}