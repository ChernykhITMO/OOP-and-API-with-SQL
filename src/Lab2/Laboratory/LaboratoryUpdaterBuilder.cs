using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Laboratory;

public class LaboratoryUpdaterBuilder : IBuilder<LaboratoryWork>
{
    private readonly LaboratoryWork _laboratoryWork;
    private string _description;
    private int _points;
    private CreditFormat _criterion;
    private int _id;
    private string _name;

    public LaboratoryUpdaterBuilder(LaboratoryWork laboratoryWork)
    {
        _laboratoryWork = laboratoryWork;
        _description = laboratoryWork.Description;
        _points = laboratoryWork.Points;
        _criterion = laboratoryWork.Criterion;
        _id = laboratoryWork.Id;
        _name = laboratoryWork.Name ?? throw new ArgumentException("Laboratory work name cannot be null");
    }

    public LaboratoryUpdaterBuilder SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        _id = id;
        return this;
    }

    public LaboratoryUpdaterBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty or whitespace");
        }

        _name = name;
        return this;
    }

    public LaboratoryUpdaterBuilder SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be empty or whitespace");
        }

        _description = description;
        return this;
    }

    public LaboratoryUpdaterBuilder SetPoints(int points)
    {
        if (points <= 0 || points > 100)
        {
            throw new ArgumentException("Points value must be between 1 and 100");
        }

        _points = points;
        return this;
    }

    public LaboratoryUpdaterBuilder SetCriterion(CreditFormat criterion)
    {
        _criterion = criterion;
        return this;
    }

    public LaboratoryWork Build()
    {
        _laboratoryWork.Description = _description;
        _laboratoryWork.Points = _points;
        _laboratoryWork.Criterion = _criterion;
        _laboratoryWork.Id = _id;
        _laboratoryWork.Name = _name;
        return _laboratoryWork;
    }
}
