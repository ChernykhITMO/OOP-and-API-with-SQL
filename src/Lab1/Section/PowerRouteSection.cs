using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section;

public class PowerRouteSection : RouteSection
{
    public double Force { get; }

    public PowerRouteSection(double length, double accuracy, double force) : base(length, accuracy)
    {
        Force = force;
    }

    public override ResultType Passable(Train train)
    {
        if (Math.Abs(Force) > train.MaxForce)
            return ResultType.FailedDueToForceLimit;

        train.Acceleration = Force / train.Mass;
        double time = train.Time(Length, Accuracy);

        if (time <= 0.0) return ResultType.FailedDueToStallTime;
        TimeDistance += time;

        return ResultType.Success;
    }
}