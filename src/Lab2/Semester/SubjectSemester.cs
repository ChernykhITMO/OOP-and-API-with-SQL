using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Semester;

public class SubjectSemester
{
    public Subject Subject { get; }

    public int SemesterNumber { get; }

    public SubjectSemester(Subject subject, int semesterNumber)
    {
        Subject = subject;
        SemesterNumber = semesterNumber;
    }
}