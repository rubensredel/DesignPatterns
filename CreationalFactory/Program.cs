namespace RR.DesignPattern.Creational.Factory;

public enum VehicleType
{
    Car,
    Truck,
    Motorcycle
};

public interface IVehicle
{
    void Drive();
}

public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a car");
    }
}

public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a truck");
    }
}

public class Motorcycle : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a motorcycle");
    }
}

public interface IVehicleFactory
{
    IVehicle CreateVehicle(VehicleType vehicleType);
}

public class VehicleFactory : IVehicleFactory
{
    public IVehicle CreateVehicle(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Car => new Car(),
            VehicleType.Truck => new Truck(),
            VehicleType.Motorcycle => new Motorcycle(),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}

public class Client
{
    private readonly IVehicleFactory _vehicleFactory;

    public Client(IVehicleFactory vehicleFactory)
    {
        _vehicleFactory = vehicleFactory;
    }

    public void DriveVehicle(VehicleType vehicleType)
    {
        var vehicle = _vehicleFactory.CreateVehicle(vehicleType);
        vehicle.Drive();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Console.Title = "Factory");
        var vehicleFactory = new VehicleFactory();
        var client = new Client(vehicleFactory);

        client.DriveVehicle(VehicleType.Car);
        client.DriveVehicle(VehicleType.Truck);
        client.DriveVehicle(VehicleType.Motorcycle);
    }
}
