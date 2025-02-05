namespace RR.DesignPattern.Creational.AbstractFactory;

public enum CarType
{
    Sedan,
    Coupe,
    Hatchback
}

public enum Location
{
    Default,
    USA,
    Germany
}

public abstract class Car
{
    protected Car(CarType model, Location location)
    {
        Model = model;
        Location = location;
        Construct();
    }
    public abstract void Construct();
    public CarType Model { get; }
    public Location Location { get; }
    public override string ToString()
    {
        return $"Car model: {Model}, manufactured in {Location}";
    }
}

public class SedanCar(Location location) : Car(CarType.Sedan, location)
{
    public override void Construct()
    {
        Console.WriteLine($"Building a sedan car in {Location}");
    }
}

public class CoupeCar(Location location) : Car(CarType.Coupe, location)
{
    public override void Construct()
    {
        Console.WriteLine($"Building a coupe car in {Location}");
    }
}

public class HatchbackCar(Location location) : Car(CarType.Hatchback, location)
{
    public override void Construct()
    {
        Console.WriteLine($"Building a hatchback car in {Location}");
    }
}

public static class CarFactory
{
    public static Car BuildCar(CarType model, Location location)
    {
        return model switch
        {
            CarType.Sedan => new SedanCar(location),
            CarType.Coupe => new CoupeCar(location),
            CarType.Hatchback => new HatchbackCar(location),
            _ => throw new ArgumentException("Invalid car type")
        };
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Console.Title = "Abstract Factory");
        Console.WriteLine(CarFactory.BuildCar(CarType.Sedan, Location.USA));
        Console.WriteLine(CarFactory.BuildCar(CarType.Coupe, Location.Germany));
        Console.WriteLine(CarFactory.BuildCar(CarType.Hatchback, Location.Default));
    }
}
