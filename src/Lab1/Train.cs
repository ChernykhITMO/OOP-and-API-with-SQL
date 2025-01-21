namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public double Mass { get; }

    public double Speed { get; private set; }

    public double Acceleration { get; set; }

    public double MaxForce { get; }

    public Train(double mass, double maxForce)
    {
        if (mass <= 0) throw new Exception("Mass is invalid");

        Speed = 0;
        Acceleration = 0;
        Mass = mass;
        MaxForce = maxForce;
    }

    public double Time(double length, double accuracy)
    {
        double remainingDistance = length;
        double totalTime = 0;

        while (remainingDistance > 0)
        {
            if (Speed <= 0 && Acceleration == 0) return 0.0;

            Speed += Acceleration * accuracy;

            if (Speed <= 0) return 0.0;

            double distance = Speed * accuracy;
            remainingDistance -= distance;

            totalTime += accuracy;
        }

        return totalTime;
    }
}
