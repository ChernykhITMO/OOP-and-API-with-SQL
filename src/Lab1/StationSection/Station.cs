using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Section;

namespace Itmo.ObjectOrientedProgramming.Lab1.StationSection;

public class Station : RouteSection
{
    private readonly double _limitSpeed;

    private readonly int _people;

    public Station(double limitSpeed, double lenght, double accuracy, int people) : base(lenght, accuracy)
    {
        if (limitSpeed <= 0) throw new Exception("Limit speed station is invalid");

        _limitSpeed = limitSpeed;
        _people = people;
    }

    public override ResultType Passable(Train train)
    {
        if (train.Speed > _limitSpeed) return ResultType.FailedDueToSpeedStationLimit;

        TimeDistance += _people;

        return ResultType.Success;
    }
}