using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratory;

public class LaboratoryWork : BaseEntity, IPrototype<LaboratoryWork>
{
    public string Description { get; set; }

    public int Points { get; set; }

    public CreditFormat Criterion { get; set; }

    public User Author { get; }

    public int? OriginalId { get; set; }

    public LaboratoryWork(int id, string name, User author, string description, int points, CreditFormat criterion)
    {
        Id = id;
        Name = name;
        Author = author;
        Description = description;
        Points = points;
        Criterion = criterion;
    }

    public LaboratoryWork Clone()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name cannot be null");
        }

        return new LaboratoryWork(Id, Name, Author, Description, Points, Criterion)
        {
            OriginalId = this.Id,
        };
    }
}