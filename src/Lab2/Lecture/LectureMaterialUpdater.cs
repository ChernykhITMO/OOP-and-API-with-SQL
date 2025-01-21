using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class LectureMaterialUpdater : IUpdater<LectureMaterial>
{
    private readonly LectureUpdaterBuilder _updaterBuilder;

    public LectureMaterialUpdater(LectureUpdaterBuilder updaterBuilder)
    {
        _updaterBuilder = updaterBuilder;
    }

    public ResultType<LectureMaterial> Update(LectureMaterial entity, User author)
    {
        if (entity.Author.Id != author.Id)
        {
            return new ResultType<LectureMaterial>(null, false, "Only the author can update the lecture materials");
        }

        LectureMaterial updatedEntity = _updaterBuilder.Build();

        return new ResultType<LectureMaterial>(updatedEntity, true, string.Empty);
    }
}