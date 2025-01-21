using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectsUpdaters;

public class SubjectUpdaterWithBuilder : IBuilder<Subject>
{
    private readonly Subject _subjects;
    private IReadOnlyCollection<LectureMaterial> _lectureMaterials;
    private string _description;
    private int _id;
    private string _name;

    public SubjectUpdaterWithBuilder(Subject subject)
    {
        _subjects = subject;
        _description = subject.Description;
        _lectureMaterials = subject.LectureMaterials;
        _id = subject.Id;
        _name = subject.Name ?? throw new ArgumentException("Subject name cannot be null");
    }

    public SubjectUpdaterWithBuilder SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        _id = id;
        return this;
    }

    public SubjectUpdaterWithBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty or whitespace");
        }

        _name = name;
        return this;
    }

    public SubjectUpdaterWithBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public SubjectUpdaterWithBuilder SetLectureMaterials(IReadOnlyCollection<LectureMaterial> lectureMaterials)
    {
        _lectureMaterials = lectureMaterials;
        return this;
    }

    public Subject Build()
    {
        _subjects.Description = _description;
        _subjects.Id = _id;
        _subjects.LectureMaterials = _lectureMaterials;
        _subjects.Name = _name;
        return _subjects;
    }
}