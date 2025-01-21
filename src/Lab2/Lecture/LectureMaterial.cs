using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class LectureMaterial : BaseEntity, IPrototype<LectureMaterial>
{
    public string Description { get; set; }

    public string Content { get; set; }

    public User Author { get; }

    public int OriginalId { get; set; }

    public LectureMaterial(int id, string name, User author, string description, string content)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        Id = id;
        Name = name;
        Author = author;
        Description = description;
        Content = content;
    }

    public LectureMaterial Clone()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name cannot be null");
        }

        return new LectureMaterial(Id, Name, Author, Description, Content)
            { OriginalId = this.Id, };
    }
}