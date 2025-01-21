using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratory;

public class LaboratoryWorkUpdater : IUpdater<LaboratoryWork>
{
    private readonly LaboratoryUpdaterBuilder _updaterBuilder;

    public LaboratoryWorkUpdater(LaboratoryUpdaterBuilder updaterBuilder)
    {
        _updaterBuilder = updaterBuilder;
    }

    public ResultType<LaboratoryWork> Update(LaboratoryWork entity, User author)
    {
        if (entity.Author.Id != author.Id)
        {
            return new ResultType<LaboratoryWork>(null, false, "Only the author can update the laboratory works");
        }

        LaboratoryWork updatedEntity = _updaterBuilder.Build();

        return new ResultType<LaboratoryWork>(updatedEntity, true, string.Empty);
    }
}