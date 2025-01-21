using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section;

public class RouteProcess
{
    private readonly IEnumerable<RouteSection> _routeSections;

    public double TimeRoute { get; set; }

    public RouteProcess(IEnumerable<RouteSection> routeSections)
    {
        _routeSections = routeSections;
    }

    public ResultType ProcessRoute(Train train, double limitSpeed)
    {
        if (limitSpeed <= 0) throw new Exception("Limit speed route is invalid");

        foreach (RouteSection section in _routeSections)
        {
            ResultType result = section.Passable(train);
            if (result != ResultType.Success)
                return result;
            TimeRoute += section.TimeDistance;
        }

        if (train.Speed > limitSpeed) return ResultType.FailedDueToSpeedRouteLimit;

        return ResultType.Success;
    }
}