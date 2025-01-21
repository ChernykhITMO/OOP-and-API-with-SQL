using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section;

public class NormalRouteSection : RouteSection
{
    public NormalRouteSection(double length, double accuracy) : base(length, accuracy) { }

    public override ResultType Passable(Train train)
    {
        train.Acceleration = 0;

        double time = train.Time(Length, Accuracy);

        if (time <= 0.0) return ResultType.FailedDueToStallTime;

        TimeDistance += time;

        return ResultType.Success;
    }
}
