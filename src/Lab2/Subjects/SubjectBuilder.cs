using Itmo.ObjectOrientedProgramming.Lab2.Laboratory;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class SubjectBuilder
{
    private readonly List<LaboratoryWork> _laboratoryWorks = new List<LaboratoryWork>();
    private readonly List<LectureMaterial> _lectureMaterials = new List<LectureMaterial>();

    private int _id;
    private string _name = string.Empty;
    private User? _author;
    private string _description = string.Empty;
    private CreditFormat _creditFormat;
    private int _points;
    private int _minPoints;
    private int _originalId;

    public SubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        _name = name;
        return this;
    }

    public SubjectBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public SubjectBuilder SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty");
        }

        _description = description;
        return this;
    }

    public SubjectBuilder AddLaboratoryWork(LaboratoryWork laboratoryWork)
    {
        _laboratoryWorks.Add(laboratoryWork);
        return this;
    }

    public SubjectBuilder AddLectureMaterial(LectureMaterial lecture)
    {
        _lectureMaterials.Add(lecture);
        return this;
    }

    public SubjectBuilder SetExamFormat(int points)
    {
        _creditFormat = CreditFormat.Exam;

        if (points <= 0)
        {
            throw new ArgumentException("Must be greater than 0");
        }

        _points = points;
        return this;
    }

    public SubjectBuilder SetCreditFormat(int minPoints)
    {
        _creditFormat = CreditFormat.Credit;

        if (minPoints <= 0)
        {
            throw new ArgumentException("MinPoints must be greater than 0");
        }

        _minPoints = minPoints;
        return this;
    }

    public SubjectBuilder SetOriginalId(int originalId)
    {
        _originalId = originalId;
        return this;
    }

    public Subject Build()
    {
        if (_author is null)
        {
            throw new ArgumentException("You must provide a valid author.");
        }

        var subject = new Subject(_id, _name, _author, _description, _laboratoryWorks, _lectureMaterials)
        {
            OriginalId = _originalId,
            CreditFormat = _creditFormat,
        };

        if (_creditFormat == CreditFormat.Exam)
        {
            subject.Points = _points;
        }
        else if (_creditFormat == CreditFormat.Credit)
        {
            subject.MinPoints = _minPoints;
        }

        return subject;
    }
}