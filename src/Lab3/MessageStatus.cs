using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class MessageStatus
{
    public Message Message { get; }

    public IsStatus IsStatus { get; set; }

    public MessageStatus(Message message)
    {
        Message = message;
        IsStatus = IsStatus.Unread;
    }
}