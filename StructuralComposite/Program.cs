using RR.DesignPattern.Structural.Composite;

IComponent crankshaft = new Part("Crankshaft", (decimal)1543.15);
IComponent cylinderHead = new Part("Cylinder", (decimal)598.45);
IComponent piston = new Part("Piston", (decimal)98.50);

Composite engine = new("Engine");
engine.AddComponent(crankshaft);
engine.AddComponent(cylinderHead);
engine.AddComponent(piston);
engine.AddComponent(piston);
engine.AddComponent(piston);
engine.AddComponent(piston);

IComponent toqueConverter = new Part("Torque Converter", (decimal)23.40);
IComponent oilPump = new Part("Oil Pump", (decimal)37.65);
IComponent planetarySet = new Part("Planetary Gear Set", (decimal)90.00);
IComponent clutchPacks = new Part("Clutch Packs", (decimal)47.50);
IComponent outputShaft = new Part("Output Shaft", (decimal)150.00);
IComponent brakeBand = new Part("Brake Band", (decimal)39.78);
IComponent oilPan = new Part("Oil Pan", (decimal)18.99);
IComponent valveBody = new Part("Valve Body", (decimal)9.99);

Composite gearbox = new("Gearbox");
gearbox.AddComponent(toqueConverter);
gearbox.AddComponent(oilPump);
gearbox.AddComponent(planetarySet);
gearbox.AddComponent(clutchPacks);
gearbox.AddComponent(outputShaft);
gearbox.AddComponent(brakeBand);
gearbox.AddComponent(oilPan);
gearbox.AddComponent(valveBody);

Composite car = new("Car");
car.AddComponent(gearbox);
car.AddComponent(engine);

car.ShowDetails();

namespace RR.DesignPattern.Structural.Composite
{
    public interface IComponent
    {
        void ShowDetails();
    }

    public class Part(string name, decimal price) : IComponent
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;

        public void ShowDetails()
        {
            Console.WriteLine($"\t| {Name,-20} | {Price,15:C} |");
        }
    }

    public class Composite(string name) : IComponent
    {
        public string Name { get; set; } = name;
        private readonly List<IComponent> components = [];

        public void AddComponent(IComponent component) => components.Add(component);

        public void ShowDetails()
        {
            Console.WriteLine($"\t| {Name,-20} | {"Price",-15} |");
            Console.WriteLine($"\t| -------------------- | --------------- |");
            foreach (IComponent component in components)
                component.ShowDetails();
            Console.WriteLine($"\t| -------------------- | --------------- |");
        }
    }
}