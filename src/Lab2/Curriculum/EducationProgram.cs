using Itmo.ObjectOrientedProgramming.Lab2.Semester;

namespace Itmo.ObjectOrientedProgramming.Lab2.Curriculum;

public class EducationProgram : BaseEntity
{
    public User ProgramManager { get; }

    public int SemesterNumber { get; }

    public IReadOnlyCollection<SubjectSemester> ProgramSubjects => _programSubjects;

    private readonly List<SubjectSemester> _programSubjects;

    public EducationProgram(int id, string name, User programManager, IReadOnlyCollection<SubjectSemester> programSubjects, int semesterNumber)
    {
        Id = id;
        Name = name;
        ProgramManager = programManager;
        _programSubjects = programSubjects?.ToList() ?? new List<SubjectSemester>();
        SemesterNumber = semesterNumber;
    }

    public void AddSubjectToSemester(SubjectSemester subject)
    {
        _programSubjects.Add(subject);
    }
}