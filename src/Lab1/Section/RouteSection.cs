using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section;

public abstract class RouteSection
{
    public double Length { get; }

    public double Accuracy { get; }

    public double TimeDistance { get; set; }

    protected RouteSection(double length, double accuracy)
    {
        if (length <= 0) throw new Exception("Length is invalid");

        if (accuracy <= 0) throw new Exception("Accuracy is invalid");

        Length = length;
        Accuracy = accuracy;
    }

    public abstract ResultType Passable(Train train);
}