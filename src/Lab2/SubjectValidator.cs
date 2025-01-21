using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class SubjectValidator
{
    public ResultType<Subject> Validate(Subject subject)
    {
        int totalPoints = subject.LaboratoryWorks.Sum(lw => lw.Points);
        if (totalPoints != 100)
        {
            return new ResultType<Subject>(null, false, "Total points must be 100");
        }

        return new ResultType<Subject>(subject, true, string.Empty);
    }
}
