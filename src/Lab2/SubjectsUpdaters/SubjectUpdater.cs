using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectsUpdaters;

public class SubjectUpdater : IUpdater<Subject>
{
    private readonly SubjectUpdaterWithBuilder _updater;

    public SubjectUpdater(SubjectUpdaterWithBuilder updater)
    {
        _updater = updater;
    }

    public ResultType<Subject> Update(Subject entity, User author)
    {
        if (entity.Author.Id != author.Id)
        {
            return new ResultType<Subject>(null, false, "Author must be the same");
        }

        Subject subject = _updater.Build();

        return new ResultType<Subject>(subject, true, string.Empty);
    }
}