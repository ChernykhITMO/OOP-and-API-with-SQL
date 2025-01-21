using Itmo.ObjectOrientedProgramming.Lab3.Result;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IMessageOutput
{
    private readonly List<MessageStatus> _statuses = new List<MessageStatus>();

    public void OutputMessage(Message message)
    {
        _statuses.Add(new MessageStatus(message));
    }

    public ResultType MarkAsRead(Message message)
    {
        MessageStatus? messageStatus = _statuses.FirstOrDefault(s => s.Message == message);

        if (messageStatus == null)
            return new ResultType("Message not found");

        if (messageStatus.IsStatus == IsStatus.Read)
            return new ResultType("The message is already read");

        messageStatus.IsStatus = IsStatus.Read;
        return new ResultType();
    }

    public IReadOnlyList<MessageStatus> GetMessages()
    {
        return _statuses.AsReadOnly();
    }
}