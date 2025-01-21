using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Section;
using Itmo.ObjectOrientedProgramming.Lab1.StationSection;
using Xunit;

namespace Lab1.Tests;

public class RoutePassTests
{
    [Fact]
    public void Scenario1()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 10);
        Assert.Equal(ResultType.Success, result);
    }

    [Fact]
    public void Scenario2()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 5);
        Assert.Equal(ResultType.FailedDueToSpeedRouteLimit, result);
    }

    [Fact]
    public void Scenario3()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
            new Station(10, 10, 1, 5),
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 10);
        Assert.Equal(ResultType.Success, result);
    }

    [Fact]
    public void Scenario4()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new Station(8, 10, 1, 5),
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 10);
        Assert.Equal(ResultType.FailedDueToSpeedStationLimit, result);
    }

    [Fact]
    public void Scenario5()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
            new Station(30, 10, 1, 5),
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 8);
        Assert.Equal(ResultType.FailedDueToSpeedRouteLimit, result);
    }

    [Fact]
    public void Scenario6()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
            new PowerRouteSection(10, 1, -4),
            new Station(8, 10, 1, 5),
            new NormalRouteSection(10, 1),
            new PowerRouteSection(10, 1, 6),
            new NormalRouteSection(10, 1),
            new PowerRouteSection(10, 1, -4),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 8);
        Assert.Equal(ResultType.Success, result);
    }

    [Fact]
    public void Scenario7()
    {
        var train = new Train(2, 10);
        var path = new List<RouteSection>
        {
            new NormalRouteSection(10, 1),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 8);
        Assert.Equal(ResultType.FailedDueToStallTime, result);
    }

    [Fact]
    public void Scenario8()
    {
        var train = new Train(2, 20);
        var path = new List<RouteSection>
        {
            new PowerRouteSection(10, 1, 5),
            new PowerRouteSection(10, 1, -2 * 5),
        };

        IEnumerable<RouteSection> pathEnumerable = path;
        var routeProcess = new RouteProcess(pathEnumerable);

        ResultType result = routeProcess.ProcessRoute(train, 8);
        Assert.Equal(ResultType.FailedDueToStallTime, result);
    }
}