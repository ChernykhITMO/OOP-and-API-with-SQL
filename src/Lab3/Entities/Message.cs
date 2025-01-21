namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public string Header { get; }

    public string Body { get; }

    public Level ImportanceLevel { get; set; }

    public Message(string header, string body, Level importanceLevel)
    {
        if (string.IsNullOrWhiteSpace(header) || string.IsNullOrWhiteSpace(body))
            throw new ArgumentNullException(nameof(header), $"{nameof(header)} cannot be null or whitespace");

        Header = header;
        Body = body;
        ImportanceLevel = importanceLevel;
    }
}