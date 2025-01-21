namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User : BaseEntity
{
    public User(int id, string name)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id must be greater than or equal to 1");
        }

        Id = id;
        Name = name ?? throw new ArgumentException("Name cannot be null");
    }
}