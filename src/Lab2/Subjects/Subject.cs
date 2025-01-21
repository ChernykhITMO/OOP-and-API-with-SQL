using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Laboratory;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class Subject : BaseEntity, IPrototype<Subject>
{
    public User Author { get; }

    public string Description { get; set; }

    public IReadOnlyCollection<LaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<LectureMaterial> LectureMaterials { get; set; }

    public CreditFormat CreditFormat { get; set; }

    public int Points { get; set; }

    public int MinPoints { get; set; }

    public int OriginalId { get; set; }

    public Subject(
        int id,
        string name,
        User author,
        string description,
        IReadOnlyCollection<LaboratoryWork> laboratoryWorks,
        IReadOnlyCollection<LectureMaterial> lectureMaterials)
    {
        if (id < 1)
        {
            throw new ArgumentException("Subject id must be greater than 0");
        }

        Id = id;
        Name = name ?? throw new ArgumentException("Name cannot be null");
        Author = author ?? throw new ArgumentException("Author cannot be null");
        Description = description ?? throw new ArgumentException("Description cannot be null");
        LaboratoryWorks = new List<LaboratoryWork>(laboratoryWorks);
        LectureMaterials = new List<LectureMaterial>(lectureMaterials);
    }

    public Subject Clone()
    {
        if (Name == null)
        {
            throw new ArgumentException("Name cannot be null");
        }

        return new Subject(Id + 1, Name, Author, Description, LaboratoryWorks, LectureMaterials)
        {
            OriginalId = Id,
            CreditFormat = CreditFormat,
            Points = Points,
            MinPoints = MinPoints,
        };
    }
}