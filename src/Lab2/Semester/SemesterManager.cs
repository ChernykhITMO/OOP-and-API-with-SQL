namespace Itmo.ObjectOrientedProgramming.Lab2.Semester;

public class SemesterManager
{
    private readonly List<SubjectSemester> _subjectSemesters = new List<SubjectSemester>();

    public void AddSubjectSemester(SubjectSemester subjectSemester)
    {
        _subjectSemesters.Add(subjectSemester);
    }
}